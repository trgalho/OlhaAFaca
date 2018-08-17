using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicou : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButtonUp(0) && !GameControl.control.TheGameIsOver()){
            GameObject faca = GameObject.Find("Faca");
            if(faca != null){
                (faca.GetComponent("JogarFaca") as JogarFaca).Arremessar();
                Invoke("CreateNextKnife", 0.5f);
                
            }
        }
    }    
    void CreateNextKnife(){
        GameObject faca = Instantiate(Resources.Load<GameObject>("Prefabs/Faca"));
        faca.name = "Faca";
    }
}
