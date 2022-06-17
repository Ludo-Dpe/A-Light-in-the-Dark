using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectToServers : MonoBehaviour
{
     
    void Start()
    {
 
        // Démarre la fonction Wait (coroutine)
        // Wait veut dire attendre
        StartCoroutine(Wait());
 
        // Exécution en parallèle
        print("S'affiche avant que Wait soit finie : " + Time.time);
    }
 
   private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("ConnectToServer");
        print("S'affiche après 5 secondes environ : " + Time.time);
    }
}