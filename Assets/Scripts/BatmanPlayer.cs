using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatmanPlayer : MonoBehaviour
{
    public float upVel = 300f;
    private Rigidbody2D batmanRb;
    private bool isDead;
    private Animator batmanAnimation;

    // Start is called before the first frame update
    void Start()
    {
        batmanRb = GetComponent<Rigidbody2D>();
        batmanAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            Flap(); 
        }
    }

    private void Flap()
    {
        batmanRb.velocity = Vector2.zero;
        batmanRb.AddForce(Vector2.up * upVel);
        batmanAnimation.SetTrigger("Flap");
    }





    private void OnCollisionEnter2D()
    {
        isDead = true;
        batmanAnimation.SetTrigger("Dead");
    }

}
