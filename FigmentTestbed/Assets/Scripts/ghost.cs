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
    //startpoint of path
    //endpoint of path


	// Use this for initialization
	void Start () {
        isAlive = true;

        
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "player")
        {
            player.loseLife();
        }
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update () {
        Vector3 vectorToTarget = playerObject.transform.position - transform.position;
        float distanceToTarget = vectorToTarget.magnitude;

        Vector3 desiredDirection = new Vector3();
        desiredDirection = vectorToTarget;
        //this block defines the chasing ghost actions
        if (chasePlayer)
        {
            isChasing = (distanceToTarget < 20.0f);

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
            //follow predefined path
        }

        //if collides with player, call player.loselife and destroy actor
        //if collides with light mesh destroy actor and play sound


    }
}
