using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog }
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    public GameState state;
    public void Start()
    {
       /* DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnCloseDialog += () =>
        {
            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
        };*/
    }

    public static GameController _instance;

    void Awake()
    {

        if (_instance == null)
        {

            _instance = this;

            //Rest of your Awake code

        }
        else
        {
            Destroy(this);
        }
    }
}