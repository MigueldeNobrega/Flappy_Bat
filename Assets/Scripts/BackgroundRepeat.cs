using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{

    private float spriteWidth;


    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
        spriteWidth = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -spriteWidth)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        transform.Translate(new Vector3(2 * spriteWidth, 0f, 0f));
        Debug.Log("TAMAÑO:" + spriteWidth);   
    }


}
