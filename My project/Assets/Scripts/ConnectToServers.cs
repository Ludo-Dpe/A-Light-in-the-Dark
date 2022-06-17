using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectToServers : MonoBehaviour
{
     
    void Start()
    {
 
        // D�marre la fonction Wait (coroutine)
        // Wait veut dire attendre
        StartCoroutine(Wait());
 
        // Ex�cution en parall�le
        print("S'affiche avant que Wait soit finie : " + Time.time);
    }
 
   private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("ConnectToServer");
        print("S'affiche apr�s 5 secondes environ : " + Time.time);
    }
}