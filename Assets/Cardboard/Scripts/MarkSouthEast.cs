﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class MarkSouthEast : MonoBehaviour {

	private GameObject mark;
	private CardboardHead head;
	private Vector3 startingPosition;
	private float delay = 0.0f; 
	
	void Start() {
		mark = GameObject.Find ("RightMark");
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (!isLookedAt) { 
			delay = Time.time + 2.0f;
			Debug.Log("NOT LOOKING");
			mark.GetComponent<Renderer> ().material.color = Color.green;
		} else {
			transform.RotateAround(transform.position, Vector3.forward, Time.deltaTime * 150f);
			Debug.Log("LOOKING");
			mark.GetComponent<Renderer> ().material.color = Color.red;
		}
		if ((Cardboard.SDK.CardboardTriggered && isLookedAt) || (isLookedAt && Time.time>delay)) {
			Application.LoadLevel(1);
		}
	}
	

}