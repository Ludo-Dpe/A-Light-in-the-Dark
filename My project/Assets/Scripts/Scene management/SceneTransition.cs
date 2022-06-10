using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    /*public string sceneToLoad;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player_1") && !other.isTrigger)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }*/
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.tag == "Player")
        {
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
