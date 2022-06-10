using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour, IPlayerTriggerable
{
    public void OnPlayerTriggered(PlayerController player)
    {
        Debug.Log("Player entered portal");
    }
    /*[SerializeField] int sceneToLoad = -1;*/
    /*private void OnTriggerEnter2D(PlayerController player)
    {
        StartCoroutine(SwitchScene());
    }*/

    /* IEnumerator SwitchScene()
     {
         yield return SceneManager.LoadSceneAsync(sceneToLoad);
     }*/

}