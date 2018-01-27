﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttach : MonoBehaviour {

	public GameObject Hero;

	private Vector3 offset;


	// Use this for initialization
	void Start () {

		offset = transform.position - Hero.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {

		transform.position = Hero.transform.position + offset;
		
	}
}
