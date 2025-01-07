using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
