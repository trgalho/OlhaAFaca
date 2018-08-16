using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    private float speed;
	// Use this for initialization
	void Start () {
        changeSpeed();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.deltaTime % 10 == 0.0f) changeSpeed();
        transform.Rotate(Vector3.forward*speed);
		
	}
    void changeSpeed() {
        speed = Random.Range(0.1f,5);
    }
}
