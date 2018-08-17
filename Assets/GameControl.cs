using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
    public static GameControl control;
    private int knifes;
    private readonly int MIN_KNIFES = 5;
    private readonly int MAX_KNIFES = 8;
	// Use this for initialization
	void Start () {
        SeedKnifes();
    }
    void SeedKnifes(){
        knifes = Random.Range(MIN_KNIFES, MAX_KNIFES);
    }
    private void Awake(){
        if (control == null)
        {
            control = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (control != this){
            Destroy(gameObject);
            control.Start();
        }        
    }
    public void nextKnife(){
        if (knifes == 0) Application.LoadLevel("OlhaAFaca");
        else knifes--;
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Knifes: " + (knifes+1));
    }
}
