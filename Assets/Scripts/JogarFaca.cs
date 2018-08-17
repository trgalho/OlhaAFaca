using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogarFaca : MonoBehaviour {
    private bool arremessar;
    private readonly int forca = 300;
    private Rigidbody2D ridigbody2D;
    private readonly float posY = -8f;
    private readonly float cravadaY = 4.09f;
    private readonly Quaternion quaternionAngulo45 = Quaternion.AngleAxis(45, Vector3.forward);
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
        gameObject.name += Random.Range(1, 20);
        Invoke("CreateNextKnife",0.5f);
    }
    void CreateNextKnife(){
        GameObject faca = Instantiate(Resources.Load<GameObject>("Prefabs/Faca"));
        faca.name = "Faca";
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        this.arremessar = false;
        AudioSource audioSource = collision.gameObject.GetComponent<AudioSource>() as AudioSource;
        if(audioSource != null) audioSource.Play();
        if (collision.gameObject.name.Equals("CirculoMadeira")){
            this.ridigbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.transform.parent = GameObject.Find("Alvo").transform;
            gameObject.transform.SetPositionAndRotation(Vector3.up * cravadaY, quaternionAngulo45);
            GameControl.control.NextKnife();
        }
        else{
            if(gameObject.name == "Faca") gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject.GetComponent<Collider2D>());
            GameControl.control.GameOver();
        }
        
    }
    
}
    