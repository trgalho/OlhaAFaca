using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ImBrazillianIDontGiveUP()
    {
        GameControl.control.Restart();
    }
    public void BackToTheMenu()
    {
        Destroy(GameControl.control);
        SceneManager.LoadScene("StartScreen");
    }
    private void _HereWeGo()
    {
        SceneManager.LoadScene("OlhaAFaca");
    }
    public void HereWeGo()
    {
        Invoke("_HereWeGo", 0.2f);
    }
    private void _GoodByeCruelWorld()
    {
        Application.Quit();
        Debug.Log("Goodbye");
    }
    public void GoodByeCruelWorld()
    {
        Invoke("_GoodByeCruelWorld", 0.3f);
    }
}