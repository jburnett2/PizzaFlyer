﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShip : MonoBehaviour {
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (new Vector3 (0, 0, 1000));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
