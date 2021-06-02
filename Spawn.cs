using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	GameObject bulle;
	public GameObject bullet;
	Rigidbody rb;

	AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("c"))
        {
        	bulle = Instantiate(bullet, transform.position, Quaternion.Euler(90f + transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0));
            rb = bulle.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 1200f);
            audio.Play();
        }
    }
}
