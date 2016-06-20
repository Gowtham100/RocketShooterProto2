﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSystem : MonoBehaviour {
    public Text scoreText;
    public int initialNumber;
    public int score;
    public GameObject win;
    public GameObject Asteroid;


	// Use this for initialization
	void Start () {
        win.SetActive(false);
        initialNumber = transform.childCount;
    }
	
	// Update is called once per frame
	void Update () {
        score = initialNumber - transform.childCount;
        scoreText.text = "Score: " + score.ToString();

        winner();

       
    }

    void winner()
    {
        if (score == transform.childCount)
        {
            win.SetActive(true);
            Destroy(Asteroid);
        }
    }
}
