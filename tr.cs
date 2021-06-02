using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tr : MonoBehaviour
{
	int health = 100;
	int time = 15;
	float ws;
	float ad;

	Rigidbody rb;
	public GameObject flag;
	public Transform hand;
	public GameObject finish;
	public GameObject gun;

	

	bool isHand = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("MyTimer", 1f, 1f);
       
    }

    // Update is called once per frame
    void Update()
    {
    	ws = Input.GetAxis("Vertical");
    	rb.velocity = transform.forward * ws * 10f;

    	ad = ad + Input.GetAxis("Horizontal");
    	transform.rotation = Quaternion.Euler(0,ad,0);

        if(Input.GetKeyDown("space"))
        {
        	health = health - 5;
        	print(health);
        	
        	FindObjectOfType<hb>().changeValue(health);
        	if(health == 0)
        	{
        		Destroy(gameObject);
        		SceneManager.LoadScene("scene2");
        	}
        }
        
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 6f, Color.red);
        if(Physics.Raycast(transform.position, transform.forward, out hit, 6f))
        {
        	if(hit.collider.gameObject.tag == "flag")
        	{
        		flag.SetActive(true);
        		if(Input.GetKeyDown("e"))
        		{
        			print("Поднял Флаг");
        			hit.transform.position = hand.position;
        			hit.transform.SetParent(hand);
        			isHand = true;
        			
        		}
        	}

        	if(hit.collider.gameObject.tag == "gun")
        	{
        		print("Вижу ружье");
        		gun.SetActive(true);
        		if(Input.GetKeyDown("g"))
        		{
        			print("Поднял ружье");
	        		hit.transform.position = hand.position;
	        		hit.transform.SetParent(hand);
	        		isHand = true;
        		}
        	}

        	if(hit.collider.gameObject.tag == "finish")
			    {
			       	
			       	if(isHand == true)
			       	{
			       		finish.SetActive(true);
			       		SceneManager.LoadScene("scene3");
			       	}
			    }

        }
    }

   void MyTimer()
   {

        	time = time - 1;
        	 if(time == 0)
            {
                SceneManager.LoadScene("scene2");
            }
        	FindObjectOfType<tb>().changeValue(time);
   }

    void OnCollisionEnter(Collision collision)
    {
    	if(collision.gameObject.tag == "enemy")
    	{
    		health = health - 5;
        	print(health);
        	
        	FindObjectOfType<hb>().changeValue(health);
    	}
    }

     public void OnClick()
    {
    	 flag.SetActive(false);
    }
    public void Close()
    {
    	gun.SetActive(false);
    }
}
