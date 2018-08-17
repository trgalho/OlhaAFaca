using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneModifier : MonoBehaviour {
    private readonly string[] knifes = { "Knife", "HisuKnife", "Ka-BarKnife", "M9Knife", "ShurikenKnife","TrackerKnife" };
    private readonly string[] barrels = {"barrel_closed", "barrel_gold", "barrel_open", "barrel_powder", "barrel_water"};
    private int knifeIndex;
    // Use this for initialization
    void Start () {
        GameObject.Find("Background").GetComponent<RawImage>().texture = GetTexture();
        GameObject alvo = GameObject.Find("Alvo");
        int barrelIndex = Random.Range(0, 5);
        GameObject barrel = Instantiate(Resources.Load<GameObject>("Prefabs/Barrels/" + barrels[barrelIndex]));
        barrel.name = barrels[barrelIndex];
        barrel.transform.SetParent(alvo.transform,true);
        barrel.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        CreateKnife();
	}
    void Update(){
        if (Input.GetMouseButtonUp(0) && !GameControl.control.TheGameIsOver()){
            if (Random.Range(1, 10) < 2) Toasted();
            GameObject faca = GameObject.Find(knifes[knifeIndex]);
            if (faca != null){
                (faca.GetComponent("JogarFaca") as JogarFaca).Arremessar();
                Invoke("CreateKnife", 0.5f);
            }
        }
    }
    public void CreateKnife(){
        knifeIndex = Random.Range(0, 6);
        Instantiate(Resources.Load<GameObject>("Prefabs/Knifes/" + knifes[knifeIndex])).name = knifes[knifeIndex];
    }
    Texture2D GetTexture(){
        int texture = Random.Range(1, 15);
        return Instantiate(Resources.Load<Texture2D>("Images/Backgrounds/" + texture));
    }
    void Toasted() {
        Instantiate(Resources.Load("Prefabs/Toasted"));
    }
}
