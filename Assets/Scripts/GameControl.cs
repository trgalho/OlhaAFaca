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
    private GUIStyle style;
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
        if (knifes == 1){
            stage++;
            SceneManager.LoadScene("OlhaAFaca");
        }
        else knifes--;
    }
    private void OnGUI(){
        GUIStyle textStyle = new GUIStyle();
        textStyle.fontSize = 23;
        GUI.backgroundColor = Color.gray;
        GUI.contentColor = Color.red;
        GUI.Label(new Rect(20, 20, 100,20),"Fase: " + stage, textStyle);
        textStyle.fontSize = 12;
        GUI.Label(new Rect(20, 50, 100, 20),"Facas restantes: "+ knifes, textStyle);
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
    public int GetStage() { return stage; }
}
