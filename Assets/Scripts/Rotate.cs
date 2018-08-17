﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    private float speed;
	// Use this for initialization
	void Start () {
        InvokeRepeating("ChangeSpeed",0f,10f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward*speed);		
	}
    void ChangeSpeed() {
        speed = Random.Range(1.5f,5);
        Debug.Log("speed change to: " + speed); 
    }
}
