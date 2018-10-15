using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerCharacter : MonoBehaviour {

    // Use this for initialization
    public int lives;
    public bool lightOn;
    public bool lightBar;
    public bool moving;
    public AudioClip damagedSound; //this is the sound that plays when the player is hit by a ghost
    public GameObject heartA;
    public GameObject heartB;
    public GameObject heartC;
    public AudioMixer mixer;
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
        UpdateHud();
        if(lives <= 0)
        {
            Destroy(this.gameObject);
            //destroy actor
        }
    }

    void UpdateHud()
    {
        switch (lives)
        {
            case 0:
                heartA.SetActive(false);
                break;
            case 1:
                heartB.SetActive(false);
                mixer.SetFloat("MyExposedParam 2", 0f);
                break;
            case 2:
                heartC.SetActive(false);
                mixer.SetFloat("MyExposedParam 1", 0f);
                break;
            case 3:
                break;
        }
    }

	// Update is called once per frame
	void Update () {

        
		
	}
}
