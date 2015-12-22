﻿using UnityEngine;
using System.Collections;

public class South : MonoBehaviour {
	
	private GameObject fade;
	private CardboardHead head;
	private Vector3 startingPosition;
	private float delay = 0.0f; 
	//private Gyroscope gyro;

	void Start() {
		fade = GameObject.Find ("Fade");
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (!isLookedAt) { 
			delay = Time.time + 2.0f;
			gameObject.GetComponent<Renderer>().material.color = Color.white;
		} else {
			gameObject.GetComponent<Renderer>().material.color = Color.green;
		}
		if ((Cardboard.SDK.CardboardTriggered && isLookedAt) || (isLookedAt && Time.time>delay)) {
			float fadeTime = fade.GetComponent<Fade>().BeginFade(1);
			Application.LoadLevel(3); // South
		}
	}

}