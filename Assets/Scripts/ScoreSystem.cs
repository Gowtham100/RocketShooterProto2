using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSystem : MonoBehaviour {
    public Text scoreText;
    public int score;
    public GameObject win;
    public GameObject timer;

	// Use this for initialization
	void Start () {
        win.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        score = transform.childCount;
        scoreText.text = "Freedom Count: " + score.ToString();

        winner();
    }

    void winner()
    {
        if (score == 0)
        {
            win.SetActive(true);
            timer.SetActive(false);
        }
    }
}
