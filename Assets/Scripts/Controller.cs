using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Vector3 mousePosition;

    public float Speed;
    private float normalSpeed = 5f;
    public GameObject engine;
    private float boostSpeed = 17f;
    public GameObject Bullet;
    public GameObject Explosion;
    public Timer move;
    public GameObject engineParticle;

    private Rigidbody2D moving;


    // Use this for initialization
    void Start()
    {
        moving = GetComponent<Rigidbody2D>();
       
       
       
    }

    // Update is called once per frame
    void Update()
    {
        //Code for speed booster
        if (Input.GetKeyDown("left shift") )
        {
            move.isMovingFast = true;
            Speed = boostSpeed;
        }
        else if (Input.GetKeyUp("left shift"))
        {
            move.isMovingFast = false;
            Speed = normalSpeed;
        }
        Movement();

        //Shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, transform.position, transform.rotation);
        }

        if (moving.IsSleeping())
        {
            move.isMoving = false;
            engineParticle.SetActive(false);

        }
        else
        {
            move.isMoving = true;
            engineParticle.SetActive(true);
        }
        }
    

    public void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        transform.position = new Vector3(transform.position.x + (Speed * x), transform.position.y + (Speed * y), -1f);

        if (x != 0 || y != 0)
        {
            Quaternion newRotation = transform.rotation;
            newRotation.SetLookRotation(new Vector3(x, y, 1f).normalized, Vector3.back);

            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, .1f);
        }
    }
    
    void OnTriggerEnter2D (Collider2D col)
    {
       
        if (col.gameObject.tag=="Ast")
        {

           
           
                 Debug.Log("Ouch");
                 StartCoroutine("Delay");
                 Destroy(gameObject);
                 Instantiate(Explosion, transform.position, transform.rotation);
                 Application.LoadLevel(2);
            
            
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
       
       
    }
   


    }

