using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    //Script para mover el background y las tuberias continuamente

    private Rigidbody2D rb;
    [SerializeField] private float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left*speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
