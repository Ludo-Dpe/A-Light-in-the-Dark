using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGrab : MonoBehaviour
{
    public GameObject GameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            Destroy(gameObject);
            Globals.stoneCount++;
        }

        if (Globals.stoneCount == 6)
        {
            Application.Quit();
        }
    }
}
