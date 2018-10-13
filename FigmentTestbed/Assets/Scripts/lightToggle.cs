using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightToggle : MonoBehaviour {
    private Light myLight;
    public float lightTime;
    private float lightTimer;
    public float lightCooldown;
    private float lightCooldownTimer;
    public Material lightBarMat;
	// Use this for initialization
	void Start () {
        myLight = GetComponent<Light>();
        lightTime = 10;
        lightTimer = lightTime;
        lightCooldown = 3;
        lightCooldownTimer = lightCooldown;
	}
	
	// Update is called once per frame
	void Update () {
        float lightUI = lightTimer / lightTime;
        lightTimer -= Time.deltaTime;
        lightBarMat.SetFloat("_Progress", lightUI);
        if (lightTimer <= 0)
        {
            myLight.enabled = false;
            lightCooldownTimer -= Time.deltaTime;
            if(lightCooldownTimer <= 0)
            {
                lightTimer = lightTime;
                lightCooldownTimer = lightCooldown;//reset the timers after cooldown is over
                myLight.enabled = true;//turn the light back on
            }
        }
        //if (Input.GetKeyUp(KeyCode.Space) && lightTimer >= 0)
        //{
        //    myLight.enabled = !myLight.enabled;
        //}
	}
}
