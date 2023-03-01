using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForward : MonoBehaviour
{
    public float direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 9)
        {
            direction *= -1;
        }
        else if (transform.position.x < -9)
        {
            direction *= -1;
        }
        transform.position += new Vector3(direction, 0, 0) * Time.deltaTime;
    }
}
