using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public Text countdownDisplay;

    void Start()
    {
        StartCoroutine(CountDownToStar());
    }

    IEnumerator CountDownToStar()
    {
        while (Globals.countTime > 0) {
            countdownDisplay.text = Globals.countTime.ToString();
            yield return new WaitForSeconds(1f);
            Globals.countTime--;
        }
        Debug.Log("Lourd");
        countdownDisplay.gameObject.SetActive(false);
    }
}
