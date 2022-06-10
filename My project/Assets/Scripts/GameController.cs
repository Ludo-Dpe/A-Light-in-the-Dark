using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState { FreeRoam, Dialog }
public class GameController : MonoBehaviour
{
    public Text keyCounter;

    public Canvas Menu_Canvas;

    public static bool isPaused;

    [SerializeField] PlayerController playerController;

    public GameState state;

    public static GameController _instance;

    private void Start()
    {
        Menu_Canvas.gameObject.SetActive(false);
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (!Menu_Canvas.gameObject.activeSelf && isPaused) {
            isPaused = !isPaused;
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            PauseGame();
        }
        keyCounter.text = "Keys : " + Globals.keyCount;
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
            Menu_Canvas.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Menu_Canvas.gameObject.SetActive(false);
        }
    }
}
