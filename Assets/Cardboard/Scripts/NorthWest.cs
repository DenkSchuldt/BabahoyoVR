﻿using UnityEngine;
using System.Collections;

public class NorthWest : MonoBehaviour {
	
	private GameObject fade;
	private CardboardHead head;
	private Vector3 startingPosition;
	private float delay;
	private float lerp;
	
	void Start() {
		delay = 0.0f;
		lerp = 0;
		fade = GameObject.Find ("Fade");
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (!isLookedAt) { 
			delay = Time.time + 2.0f;
			lerp = 0;
			gameObject.GetComponent<Renderer>().material.color = Color.white;
		} else {
			lerp += Time.deltaTime;
			gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.green, lerp/2);
		}
		if ((Cardboard.SDK.CardboardTriggered && isLookedAt) || (isLookedAt && Time.time>delay)) {
			float fadeTime = fade.GetComponent<Fade>().BeginFade(1);
			Application.LoadLevel(2); // North West
		}
	}

}
