using UnityEngine;
using System.Collections;

public class MiniAsteroids : Asteroid {

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            MiniAst.SetActive(false);

        }
    }
}
