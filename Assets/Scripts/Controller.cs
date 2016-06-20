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

    public GameObject engineParticle;

    private Rigidbody2D moving;
    public int thrust;
    private float xAngle;
    private float yAngle;
    private float zAngle;

    private Camera cam;
    private float z_distance;
    private float leftConstraint;
    private float rightConstraint;
    private float bottomConstraint;
    private float topConstraint;
 



    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        z_distance = Mathf.Abs(cam.transform.position.z + transform.position.z);

        moving = GetComponent<Rigidbody2D>();

        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, z_distance)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, z_distance)).x;

        bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, z_distance)).y;
        topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, z_distance)).y;




    }

    // Update is called once per frame
    void Update()
    {
        //Code for speed booster
        if (Input.GetKeyDown("left shift") )
        {
           
            Speed = boostSpeed;
        }
        else if (Input.GetKeyUp("left shift"))
        {
            
            Speed = normalSpeed;
        }
        Movement();

        //Shooting
        

      
        Shoot();
       
        }

    void FixedUpdate()
    {
        if (transform.position.x < leftConstraint)
        {
            transform.position = new Vector3(rightConstraint, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightConstraint)
        {
            transform.position = new Vector3(leftConstraint, transform.position.y, transform.position.z);
        }
        if (transform.position.y < bottomConstraint)
        {
            transform.position = new Vector3(transform.position.x, topConstraint , transform.position.z);
        }
        if (transform.position.y > topConstraint)
        {
            transform.position = new Vector3(transform.position.x, bottomConstraint, transform.position.z);
        }
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, transform.position, transform.rotation);
        }
    }
    

    public void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime;

    

        

        if (Input.GetKey(KeyCode.UpArrow))
        {

            moving.AddForce(transform.up * thrust);
        }


        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.back * normalSpeed /** Time.deltaTime*/);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(-Vector3.back * normalSpeed );


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

