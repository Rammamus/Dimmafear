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
    private float ghostTimer = 0;
    public bool ghostActive;
    public float ghostDuration = 2;
    public bool usingHexBelt;
    public bool usingSandevistan;

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
            if (canUseSum == false)
            {
                SummonerSpellTimer();
            }

            if (colliding == true)
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
                player.invincible = true;
                player.playerSpeed = 8;
                ghostTimer += Time.deltaTime;
                print(ghostTimer);
                if (ghostTimer > ghostDuration)
                {
                    player.playerSpeed = 5;
                    player.invincible = false;
                    ghostActive = false;
                    ghostTimer = 0;
                    print("ghost no");
                }
            }
        }

        //hexbelt
        if (usingHexBelt)
        {
            sumSpellCD = 1.5f;
            SummonerSpellTimer();
        }

        //sandevistan
        if (usingSandevistan)
        {
            sumSpellCD = 2;
            SummonerSpellTimer();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall"))
        {
            colliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            colliding = false;
        }
    }

    public void SummonerSpellTimer()
    {
        if (canUseSum == false)
        {
            sumSpellTimer += Time.deltaTime;
            if (sumSpellTimer > sumSpellCD)
            {
                canUseSum = true;
                sumSpellTimer = 0;
            }
        }
    }
}
