using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    public static MenuUIManager menuUIManager;

    public string playerNameMenu;
    public Text playerNameInput;
    public Text bestScoreMenu;

    private void Awake()
    {
        DataPersistenceManager.instance.LoadHighScore();
    }

    private void Start()
    {
        SetMenuHighScore();
    }

    public void SetPlayerName()
    {
        DataPersistenceManager.instance.playerName = playerNameInput.text;
        DataPersistenceManager.instance.tempPlayerName = playerNameInput.text;
    }

    public void SetMenuHighScore()
    {
        bestScoreMenu.text = "Best Score: " + DataPersistenceManager.instance.playerName + " : " + DataPersistenceManager.instance.hiScore;
    }

    public void StartNew()
    {
        SetPlayerName();
        SceneManager.LoadScene(1);
    }



    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
