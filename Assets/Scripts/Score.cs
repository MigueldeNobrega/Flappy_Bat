using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    //Script para controlar el trigger de la puntuacion
    private void OnTriggerEnter2D()
    {
        GameManager.Instance.CountScore();
        
    }
}
