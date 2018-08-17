
using UnityEngine;

public class JogarFaca : MonoBehaviour {
    private bool arremessar;
    private readonly int forca = 300;
    // Use this for initialization
    void Start () {
        arremessar = false;
    }	
	// Update is called once per frame
	void Update () {
        if (arremessar) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up*forca);
        }
	}    
    public void Arremessar() {
        this.arremessar = true;           
    }    
    void OnCollisionEnter2D(Collision2D collision){
        this.arremessar = false;
        AudioSource audioSource = collision.gameObject.GetComponent<AudioSource>() as AudioSource;
        if(audioSource != null) audioSource.Play();        
        if (collision.gameObject.name.StartsWith("barrel")){
            Destroy(gameObject.GetComponent<Collider2D>());
            GameObject facaCortada = Instantiate(Resources.Load<GameObject>("Prefabs/StickedKnifes/" + gameObject.name));
            Debug.Log("Knife name: " + gameObject.name);
            facaCortada.name = gameObject.name+ Random.Range(1, 20);
            facaCortada.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            facaCortada.transform.parent = GameObject.Find("Alvo").transform;
            GameControl.control.NextKnife();
            Destroy(this.gameObject);
        }
        else{
            if(gameObject.name == "Faca") gameObject.GetComponent<AudioSource>().Play();
            if(!GameControl.control.TheGameIsOver()) GameControl.control.GameOver();
        }        
    }
}
    