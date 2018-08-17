using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicou : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButtonUp(0)){
            JogarFaca jf = (GameObject.Find("Faca").GetComponent("JogarFaca") as JogarFaca);
            if (jf != null) jf.Arremessar();
        }
    }
          
}
