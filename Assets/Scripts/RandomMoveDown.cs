using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveDown : MonoBehaviour
{
    float speed = 1.0f;
    float x, y, z;
    // Start is called before the first frame update
    void Start()
    {


        x = Random.Range(-5, 5);
        y = -5;
        z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(x, y, z) * Time.deltaTime * speed);
    }

}
