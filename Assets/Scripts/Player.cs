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
    public LaunchOffset launchOffset;
    Rigidbody2D rb;
    Vector2 movement;

    public bool canMove = true;

    public bool hexbelt = false;
    public float hexbeltTimerDontQuestionIt = 0;

    // Start is called before the first frame update
    void Start()
    {
        SumSpell.GetComponent<SummonerSpell>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        if (Input.GetKey(KeyCode.F) && SumSpell.GetComponent<SummonerSpell>().canUseSum == true)
        {
            if (SumSpell.usingFlash)
            {
                transform.position = flashPoint.position;
                SumSpell.canUseSum = false;
            }
            else if (SumSpell.usingGhost)
            {
                playerSpeed = 8;
                invincible = true;
                float timer = 0;
                SumSpell.canUseSum = false;
            }
            else if (SumSpell.usingHexBelt)
            {
                hexbelt = true;
            }
        }
        if (hexbelt == true)
        {
            launchOffset.canRotate = false;
            canMove = false;
            hexbeltTimerDontQuestionIt += Time.deltaTime;
            float distance;
            distance = Vector2.Distance(transform.position, flashPoint.transform.position);
            Vector2 direction = flashPoint.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, flashPoint.transform.position, 20 * Time.deltaTime);
            if (hexbeltTimerDontQuestionIt > 0.15f)
            {
                hexbelt = false;
                SumSpell.canUseSum = false;
                launchOffset.canRotate = true;
                canMove = true;
                hexbeltTimerDontQuestionIt = 0;
                //now make object spawn :D
            }
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }
}
