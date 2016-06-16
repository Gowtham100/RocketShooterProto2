using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Image timer;
    float life = 100;
    float time;
    public float speed;
    public float superSpeed;
    public float regen;
    public float totalLife;

    public bool isMoving;
    public bool isMovingFast;
 
    

	// Use this for initialization
	void Start () {

        timer = GetComponentInChildren<Image>();
        time = life;
        isMoving = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (isMoving)
        {
            if (time > 0)
            {
                timer.fillAmount -= speed / time;
              
                totalLife = timer.fillAmount;

            }
            
        }
        if (!isMoving)
        {
            if (time > 0)
            {
                timer.fillAmount += regen / time;
                
                totalLife = timer.fillAmount;

            }
        }
        if (isMovingFast)
        {
            timer.fillAmount -= superSpeed / time;
           
            totalLife = timer.fillAmount;
        }

        if (totalLife == 0)
        {
            Application.LoadLevel(2);
        }

    }

    }


