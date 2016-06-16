using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    private Rigidbody2D rb;
    public float Speed;

    //public int score;
    //public Text scoreText;

    // Use this for initialization
    void Start () {

        //score = 0;
        //ScoreCounter();

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * Speed);
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Ast")
        { 
            gameObject.SetActive(false);
            //score = score + 1;
            //ScoreCounter();
        }
    }

    /*void ScoreCounter()
    {
        scoreText.text = "Score: " + score.ToString();
    }*/
}
