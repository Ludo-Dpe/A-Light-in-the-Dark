using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCamera : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public GameObject player1;
    public GameObject player2;
    bool switchPlayer = false;
    private void Start()
    {
        player2.GetComponent<PlayerController>().enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (switchPlayer == false)
            {
                ChangeCameraTarget(player2);
                player1.GetComponent<PlayerController>().enabled = false;
                player2.GetComponent<PlayerController>().enabled = true;

            }
            else
            {
                ChangeCameraTarget(player1);
                player1.GetComponent<PlayerController>().enabled = true;
                player2.GetComponent<PlayerController>().enabled = false;
            }
        }
    }
    private void ChangeCameraTarget(GameObject newTarget)
    {
        virtualCamera.Follow = newTarget.transform;
        switchPlayer = !switchPlayer;
    }
}