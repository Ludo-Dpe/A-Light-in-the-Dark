using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject otherPlayer;

    void OnMouseDown()
    {
        otherPlayer.GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerController>().enabled = true;
    }
}
