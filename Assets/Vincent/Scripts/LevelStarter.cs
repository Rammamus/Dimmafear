using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{

    public GameObject hiddenWalls;
    public bool levelStart;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && levelStart == false)
        {

            levelStart = true;
            

            print("prepare thyself.");

        }
        
    }

}
