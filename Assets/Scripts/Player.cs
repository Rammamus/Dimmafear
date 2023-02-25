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


    // Start is called before the first frame update
    void Start()
    {
        SumSpell.GetComponent<SummonerSpell>();
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
            }
            else if (SumSpell.usingGhost)
            {
                playerSpeed = 8;
                invincible = true;
            }
            else if (SumSpell.usingHexBelt)
            {
                //add force and whatnot
            }
            SumSpell.canUseSum = false;
        }
    }
}
