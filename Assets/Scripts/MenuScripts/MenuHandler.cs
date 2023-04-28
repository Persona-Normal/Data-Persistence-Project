using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    [SerializeField] int mainSceneIndex = 1;
    [SerializeField] Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (DataPersistenceManager.Instance != null) 
        {
            highScoreText.text = $"Best Score : {DataPersistenceManager.Instance.highScore.playerName} : {DataPersistenceManager.Instance.highScore.score}";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(mainSceneIndex);
    }

    // Exit game
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void OnPlayerNameEnter(string playerName) 
    {
        if (DataPersistenceManager.Instance != null) 
        { 
            DataPersistenceManager.Instance.playerName = playerName; 
        }   
    }
}
