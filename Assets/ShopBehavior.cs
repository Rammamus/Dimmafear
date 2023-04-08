using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehavior : MonoBehaviour
{

    public GameObject shopGUI;

    // Start is called before the first frame update
    void Start()
    {

        shopGUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Open Shop");

            shopGUI.SetActive(true);
        }
    }

    public void CloseShop()
    {
        shopGUI.SetActive(false);
    }

}
