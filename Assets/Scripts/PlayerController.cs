using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public GameObject bullet;

    Rigidbody rb;
    public AudioSource audioSource;
    public AudioClip fire;

    float xBound = 8;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        rb.AddForce(Input.GetAxis("Horizontal") * Vector3.right, ForceMode.Impulse);

        //player boundry
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            rb.velocity = Vector3.zero;
        }
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
            rb.velocity = Vector3.zero;
        }

        //fire bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            audioSource.PlayOneShot(fire);
        }
    }
}
