using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogarFaca : MonoBehaviour {
    private bool arremessar;
    private readonly int forca = 10;
    private Rigidbody2D ridigbody2D;
    private readonly float posX = 0;
    private readonly float posY = -4.39f;
    // Use this for initialization
    void Start () {
        arremessar = false;
        ridigbody2D = gameObject.GetComponent("Rigidbody2D") as Rigidbody2D;

    }
	
	// Update is called once per frame
	void Update () {
        if (arremessar) {
            ridigbody2D.AddForce(Vector2.up*forca);
        }
	}
    
    public void Arremessar() {
        this.arremessar = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        this.arremessar = false;
        this.gameObject.name += Random.Range(1, 20);
        Instantiate(this, Vector3.right*posX + Vector3.up*posY, Quaternion.identity).name="Faca";
        this.ridigbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        this.gameObject.transform.parent = GameObject.Find("Alvo").transform;
        Debug.Log("colidiu");
        
    }
}
