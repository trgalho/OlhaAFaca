using System.Collections;
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
        int direction =1;
        if (GameControl.control.GetStage() > 3) {
            direction = Random.Range(0, 1) > 0.5f ? -1 : 1;
        }        
        speed = Random.Range(2, 5) * direction;
        Debug.Log("speed change to: " + speed);
    }
}
