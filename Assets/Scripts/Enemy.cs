using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool moveRight;
    float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        moveRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        else
            transform.Translate(Vector3.left * Time.deltaTime * speed);


        if (transform.position.x > 3)
            moveRight = false;
        if (transform.position.x < -3)
            moveRight = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
