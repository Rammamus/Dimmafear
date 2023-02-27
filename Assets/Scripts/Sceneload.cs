using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneload : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gate1"))
        {
            SceneManager.LoadScene("testArea1");
        }
        if (collision.gameObject.CompareTag("Gate2"))
        {
            SceneManager.LoadScene("testArea2");
        }
        if (collision.gameObject.CompareTag("Gate3"))
        {
            SceneManager.LoadScene("testArea3");
        }
        if (collision.gameObject.CompareTag("Gate4"))
        {
            SceneManager.LoadScene("testArea4");
        }
    }
}
