using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public bool isGameOver;
    [SerializeField] private GameObject deadText;

    public static GameManager Instance { get { return instance; } }
    void Awake()
    {
        if (!instance)
        {
           
            instance = this;
           
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGameOver)
        {
            RestartGame();
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        deadText.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
