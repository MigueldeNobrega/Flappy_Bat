using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public bool isGameOver;

    //Para controlar el texto de muerte y el contador de puntos
    [SerializeField] private GameObject deadText;
    [SerializeField] private TMP_Text scoreCount;


    public AudioClip scoreAudioClip;

    private int score;

    // Propiedad para acceder a la instancia única del GameManager (Singleton)
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


    //Al morir, pulsar para reiniciar
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

    //Activa el texto de muerte 
    public void GameOver()
    {
        isGameOver = true;
        deadText.SetActive(true);
    }

    //Para reiniciar la escena de la partida
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Para controlar el aumento y el sonido de la puntuacion
    public void CountScore()
    {
        score++;
        scoreCount.text = score.ToString();
        AudioManager.instance.PlayAudio(scoreAudioClip, "ScoreSound");

    }
}
