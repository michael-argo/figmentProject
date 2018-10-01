using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    // Use this for initialization
    public int lives;
    public bool lightOn;
    public bool lightBar;
    public bool moving;
    public AudioClip damagedSound; //this is the sound that plays when the player is hit by a ghost
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start () {
        lives = 3; 
		
	}
	
    public void loseLife()//this will be called by the ghost actor
    {
        source.PlayOneShot(damagedSound);
        lives--;
        if(lives <= 0)
        {
            Destroy(this.gameObject);
            //destroy actor
        }
    }


	// Update is called once per frame
	void Update () {

        
		
	}
}
