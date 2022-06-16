using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    
    // public bool open = false;
    [SerializeField] GameObject doort;

    // Start is called before the first frame update
    
    // public void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.E))
    //     {
    //         if(playerInRange)
    //         {    

    //         }
    //     }
    // }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("momo");
        doort.transform.Translate(new Vector3(1.5f,0,0));
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        doort.transform.Translate(new Vector3(-1.5f,0,0));
    }

}
