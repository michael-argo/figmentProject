using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour {

    public bool chasePlayer;
    public bool isChasing;
    public bool isAlive;
    //startpoint of path
    //endpoint of path


	// Use this for initialization
	void Start () {
        isAlive = true;

        
	}
	
	// Update is called once per frame
	void Update () {
        //this block defines the chasing ghost actions
        if (chasePlayer)
        {

            //if chasePlayer && playerDist < x units, set is chasing to true

            if (isChasing)
            {
                //go straight to player and avoid obstacles
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
