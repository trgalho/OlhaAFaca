using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
    public static GameControl control;
    private int knifes;
    private int stage;
    private readonly int MIN_KNIFES = 5;
    private readonly int MAX_KNIFES = 8;
    private bool gameOver;
	// Use this for initialization
	void Start () {
        SeedKnifes();
        gameOver = false;
    }
    void SeedKnifes(){
        knifes = Random.Range(MIN_KNIFES, MAX_KNIFES);
        
    }
    private void Awake(){
        if (control == null)
        {
            control = this;
            stage = 1;
            DontDestroyOnLoad(gameObject);
        }
        else if (control != this){
            Destroy(gameObject);
            control.Start();
        }        
    }
    public void NextKnife(){
        if (knifes == 0){
            stage++;
            SceneManager.LoadScene("OlhaAFaca");
        }
        else knifes--;
    }
    private void OnGUI(){
        GUI.Label(new Rect(10, 10, 100,30), "Fase: " + stage);
        GUI.Label(new Rect(10, 30, 100, 30), "Knifes: " + (knifes + 1));
    }
    public void GameOver() {
        if (!gameOver){
            gameOver = true;
            stage = 1;
            Instantiate(Resources.Load<GameObject>("Prefabs/Canvas"));            
        }
        
    }
    public bool TheGameIsOver() { return gameOver; }
    public void Restart(){
        SceneManager.LoadScene("OlhaAFaca");
        Debug.Log("restart");
    }
    public void Quit(){
        Debug.Log("quit");
        Application.Quit();
        
    }
}
