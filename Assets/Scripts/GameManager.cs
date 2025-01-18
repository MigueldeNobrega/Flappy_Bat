using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public bool isGameOver;
    [SerializeField] private GameObject deadText;
    [SerializeField] private TMP_Text scoreCount;
    public AudioClip scoreAudioClip;


    private int score;
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
        if (isGameOver)
        {
#if UNITY_STANDALONE || UNITY_EDITOR  // Para PC o en el editor de Unity
            if (Input.GetMouseButtonDown(0))  // Clic izquierdo
            {
                RestartGame();
            }

#elif UNITY_ANDROID || UNITY_IOS  // Para dispositivos móviles
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)  // Toque en la pantalla
            {
                RestartGame();
            }
#endif
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

    public void CountScore()
    {
        score++;
        scoreCount.text = score.ToString();
        AudioManager.instance.PlayAudio(scoreAudioClip, "ScoreSound");

    }
}
