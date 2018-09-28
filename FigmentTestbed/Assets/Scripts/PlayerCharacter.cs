using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    // Use this for initialization
    public int lives;
    public bool lightOn;
    public bool lightBar;
    public bool moving; 

	void Start () {
        lives = 3; 
		
	}
	
    void loseLife()//this will be called by the ghost actor
    {
        lives--;
        if(lives <= 0)
        {
            //destroy actor
        }
    }


	// Update is called once per frame
	void Update () {

        
		
	}
}
