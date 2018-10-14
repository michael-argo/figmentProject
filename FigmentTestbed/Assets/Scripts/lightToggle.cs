using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightToggle : MonoBehaviour {
    private Light myLight;
    public float lightTime, lightCooldown, doubleTapDelay;
    private float lightTimer, lightCooldownTimer, doubleTapDelayTimer;
    private bool firstButtonPressed, doubleTapReset, lightLock;
    public Material lightBarMat;

	// Use this for initialization
	void Start () {
        myLight = GetComponent<Light>();
        lightTime = 10;
        lightTimer = lightTime;
        lightCooldown = 3;
        lightCooldownTimer = lightCooldown;
        doubleTapDelay = 0.5f;
        doubleTapDelayTimer = doubleTapDelay;
        firstButtonPressed = false;
        doubleTapReset = false;
        lightLock = false;
	}
	
	// Update is called once per frame
	void Update () {
        float lightUI = lightTimer / lightTime;
        lightBarMat.SetFloat("_Progress", lightUI);


        /*This section adjusts the timer for the light. while the 
         light is on drain light life, while off, increase light life
         until it hits the max*/
        if (myLight.enabled)
        {
            //if the light is on, subtract from the light timer
            lightTimer -= Time.deltaTime;
        } else
        {
            if (lightTimer <= lightTime && !lightLock)
            {
                lightTimer += Time.deltaTime;
            }
        }


        if (lightTimer <= 0f)
        {
            myLight.enabled = false;//turn off light
            lightCooldownTimer -= Time.deltaTime;
            lightLock = true;
            //if the light is completely drained, start the cooldown
            if(lightCooldownTimer <= 0f)
            {
                lightLock = false;
                lightTimer = lightTime;
                lightCooldownTimer = lightCooldown;//reset the timers after cooldown is over
            }
        }



        //double tap spacebar to trigger light
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (firstButtonPressed)
            {
                //DOUBLE CLICK FUNCTIONALITY
                if ((Time.time - doubleTapDelayTimer < 0.5f) && !lightLock)
                {
                    myLight.enabled = !myLight.enabled;//turn light on/off
                    Debug.Log("double clicked");
                }
                else
                {
                    Debug.Log("too slow");
                }
                doubleTapReset = true;
            } else
            {
                firstButtonPressed = true;
                doubleTapDelayTimer = Time.time;
            }
        }
        if (doubleTapReset)
        {
            firstButtonPressed = false;
            doubleTapReset = false;
        }




        //if (Input.GetKeyUp(KeyCode.Space) && lightTimer >= 0)
        //{
        //    myLight.enabled = !myLight.enabled;
        //}
	}
}
