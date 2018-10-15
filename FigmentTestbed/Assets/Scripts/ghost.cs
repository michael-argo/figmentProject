using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour {

    public bool chasePlayer;
    private bool isChasing;
    public bool isAlive;
    public float speed = 4.0f;
    public GameObject playerObject;
    public PlayerCharacter player;
    public float chaseDistance = 20.0f; //this is just a test value, adjust as needed in prefab
    //startpoint of path
    private int cur;
    public Transform[] target;//targets to move between 
    public AudioClip ghostSound;
    public AudioClip ghostDamagedSound;
    private AudioSource source;
    //endpoint of path
    public float soundInterval;
    private float soundTimer;

    //this determines how close to the targets the ghost will get on the path
    public float deviationToTarget;

    //reference to spot light on character
    private Light spot;

	// Use this for initialization
	void Start () {
        isAlive = true;
        soundInterval = Random.Range(7, 24);//will play ghost noise every x seconds
        soundTimer = soundInterval;
        deviationToTarget = 1;
        spot = GameObject.Find("Spot Light").GetComponent<Light>();
	}
    private void Awake()
    {
        Debug.Log("awake");
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "flashlight")//lowercase tags
        {
            if (collision.gameObject.tag == "Player")
            {
                player.loseLife();
            }
            
            //Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "flashlight" && spot.enabled)
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
        if (playerObject == null)
            return;
        Vector3 vectorToTarget = playerObject.transform.position - transform.position;
        float distanceToTarget = vectorToTarget.magnitude;

        Vector3 desiredDirection = new Vector3();
        desiredDirection = vectorToTarget;

        if (soundTimer <= 0)
        {
            soundTimer = soundInterval;
            source.PlayOneShot(ghostSound);

        }
        else {
            soundTimer -= Time.deltaTime;
        }

        //this block defines the chasing ghost actions
        if (chasePlayer)
        {
            isChasing = (distanceToTarget < chaseDistance);

            if (isChasing)
            {//go straight to player
                desiredDirection.Normalize();
                transform.position += desiredDirection * speed * Time.deltaTime;

            } else
            {
                desiredDirection = Vector3.zero;
                //the player is too far, do nothing
            }
            

            //if distance to player is > x units set isChasing to false

        }
        else
        {
            if (Vector3.Distance(transform.position, target[cur].position) > deviationToTarget)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target[cur].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);

            }
            else {
                cur = (cur + 1) % target.Length;
            }
            //move between gameobject point1 and gameobject point2
        }
        
        //if collides with light mesh destroy actor and play sound

    }
}
