using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public float scrollSpeed = 2f; // Velocidad del fondo
    private float spriteWidth;

    void Start()
    {
        // Obtener el tamaño del sprite del background
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Mover el fondo de forma continua hacia la izquierda
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // Si la imagen ha salido completamente de la pantalla, la reposicionamos justo detrás de la otra
        if (transform.position.x <= -spriteWidth)
        {
            RepositionBackground();
        }
    }

    void RepositionBackground()
    {
        // Encuentra la imagen más adelantada 
        GameObject backFirst = FindBackFirst();

        // Reposicionar este fondo exactamente detrás del otro
        transform.position = new Vector3(backFirst.transform.position.x + spriteWidth, transform.position.y, transform.position.z);
    }

    GameObject FindBackFirst()
    {
        // Encuentra todas las imágenes 
        Back[] backgrounds = FindObjectsOfType<Back>();

        // Buscar la imagen que está más a la derecha
        GameObject backFirst = this.gameObject;
        foreach (Back fondo in backgrounds)
        {
            if (fondo.transform.position.x > backFirst.transform.position.x)
            {
                backFirst = fondo.gameObject;
            }
        }
        return backFirst;
    }
}
