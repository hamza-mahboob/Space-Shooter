using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    float speed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //bullet moves up
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        //destroy out of bounds
        if (transform.position.y > 10)
            Destroy(gameObject);
    }
}
