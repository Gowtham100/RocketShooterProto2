using UnityEngine;
using System.Collections;

public class StartScnController : MonoBehaviour {
    public GameObject Bullet;
    public float Speed;
    public Controller contrl;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, transform.position, transform.rotation);
        }

        Movement();
      
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

  
}
