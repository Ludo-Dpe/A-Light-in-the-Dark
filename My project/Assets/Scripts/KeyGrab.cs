using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGrab : MonoBehaviour
{
    public GameObject GameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            Globals.keyCount++;
            if (Globals.keyCount == 2)
            {
                Debug.Log("Test QUit");
                Application.Quit();
            }
        }

    }

    /*void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Finish")
        {
            Debug.Log("finish");
            Application.Quit();
        }
    }
}*/
}