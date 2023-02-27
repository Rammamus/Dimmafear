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
    Rigidbody2D rb;
    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        SumSpell.GetComponent<SummonerSpell>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

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
            }
            SumSpell.canUseSum = false;
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }
}
