using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 dir;

    public float playerSpeed = 5;
    public bool invincible = false;
    public Transform flashPoint;
    public SummonerSpell SumSpell;



    bool hexbel = false;
    // Start is called before the first frame update
    void Start()
    {
        SumSpell.GetComponent<SummonerSpell>();
        flashPoint = GameObject.FindObjectOfType<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, playerSpeed, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, playerSpeed, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(playerSpeed, 0, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(playerSpeed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.F) && SumSpell.GetComponent<SummonerSpell>().canUseSum == true)
        {
            if (SumSpell.usingFlash)
            {
                transform.position = flashPoint.position;
                print("using flash");
            }
            else if (SumSpell.usingGhost)
            {
                playerSpeed = 8;
                invincible = true;
                float timer = 0;
                print("using ghost");
            }
            else if (SumSpell.usingHexBelt)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    float distance;

                    distance = Vector2.Distance(transform.position, flashPoint.transform.position);
                    Vector2 direction = flashPoint.transform.position - transform.position;

                    transform.position = Vector2.MoveTowards(this.transform.position, flashPoint.transform.position, 10 * Time.deltaTime);
                    print("using hexbelt");
                }
            }
            SumSpell.canUseSum = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            hexbel = true;
        }
        if (hexbel)
        {
            float distance;

            distance = Vector2.Distance(transform.position, flashPoint.transform.position);
            Vector2 direction = flashPoint.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, flashPoint.transform.position, playerSpeed * Time.deltaTime);
            print("using hexbelt");
        }
    }
}
