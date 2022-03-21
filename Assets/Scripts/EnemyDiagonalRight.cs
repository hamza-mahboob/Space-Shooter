using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiagonalRight : MonoBehaviour
{

    float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, -1, 0) * Time.deltaTime * speed);
    }


}
