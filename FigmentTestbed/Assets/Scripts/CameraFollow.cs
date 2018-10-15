using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	public float zOffset;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
        if(player != null)
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, player.position.z - zOffset);
	}
}
