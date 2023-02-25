using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerSpell : MonoBehaviour
{
    public Player player;

    public float sumSpellCD = 2;
    public float sumSpellTimer = 0;
    public bool canUseSum = false;
    public bool colliding;

    public bool usingFlash;
    public bool usingGhost;
    public bool ghostActive;
    public float ghostDuration = 2;
    public bool usingHexBelt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //flash
        if (usingFlash)
        {
            sumSpellCD = 2;
            if (colliding == false)
            {
                SummonerSpellTimer();
            }
            else if (colliding == true)
            {
                canUseSum = false;
            }
        }
        
        //ghost
        if (usingGhost)
        {
            sumSpellCD = 1.5f;
            SummonerSpellTimer();

            if (ghostActive)
            {
                float timer = 0;
                timer += Time.deltaTime;
                if (timer > ghostDuration)
                {
                    player.playerSpeed = 5;
                    player.invincible = false;
                    ghostActive = false;
                }
            }
        }

        if (usingHexBelt)
        {
            sumSpellCD = 1.5f;
            SummonerSpellTimer();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall"))
        {
            colliding = true;
            print("ow wall");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            colliding = false;
            print("no wall");
        }
    }

    public void SummonerSpellTimer()
    {
        sumSpellTimer += Time.deltaTime;
        if (sumSpellTimer > sumSpellCD)
        {
            canUseSum = true;
            sumSpellTimer = 0;
        }
    }
}
