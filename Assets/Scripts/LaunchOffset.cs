using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchOffset : MonoBehaviour
{
    public Transform tm;
    public Player player;

    public bool canRotate;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<Transform>();
        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
