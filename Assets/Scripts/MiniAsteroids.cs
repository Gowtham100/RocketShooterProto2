using UnityEngine;
using System.Collections;

public class MiniAsteroids : MonoBehaviour {
    public float minForce = 5f;
    public float maxForce = 10f;
    private Rigidbody2D rb;
    public GameObject Explosion;


    // Use this for initialization
    void Start () {
        float magn = Random.Range(minForce, maxForce);
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(magn * new Vector3(x, y, -1));

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
           
                Instantiate(Explosion, transform.position, transform.rotation);
                Destroy(gameObject);
               

        }
    }
}
