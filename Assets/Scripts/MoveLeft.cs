using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	 }
	
	// Update is called once per frame
	void Update () {
		(this.GetComponent("Rigidbody2D") as Rigidbody2D).AddForce(transform.up*5);
		
	}
}
