using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatmanPlayer : MonoBehaviour
{
    public float upVel = 300f;
    private Rigidbody2D batmanRb;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        batmanRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            batmanRb.velocity = Vector2.zero;
            batmanRb.AddForce(Vector2.up * upVel);
        }
    }

    private void OnCollisionEnter2D()
    {
        isDead = true;
    }

}
