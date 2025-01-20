using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public float scrollSpeed = 2f; // Velocidad del fondo
    private float spriteWidth;

    void Start()
    {
        // Obtener el tama�o del sprite (usa el SpriteRenderer en lugar del Collider)
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Mover el fondo de forma continua hacia la izquierda
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // Si la imagen ha salido completamente de la pantalla, la reposicionamos justo detr�s de la otra
        if (transform.position.x <= -spriteWidth)
        {
            ReposicionarFondo();
        }
    }

    void ReposicionarFondo()
    {
        // Encuentra la imagen m�s adelantada (la que a�n no ha salido de la pantalla)
        GameObject fondoMasAdelantado = EncontrarFondoMasAdelantado();

        // Reposicionar este fondo exactamente detr�s del otro
        transform.position = new Vector3(fondoMasAdelantado.transform.position.x + spriteWidth, transform.position.y, transform.position.z);
    }

    GameObject EncontrarFondoMasAdelantado()
    {
        // Encuentra todas las im�genes con este script
        Back[] fondos = FindObjectsOfType<Back>();

        // Buscar la imagen que est� m�s a la derecha
        GameObject fondoMasAdelantado = this.gameObject;
        foreach (Back fondo in fondos)
        {
            if (fondo.transform.position.x > fondoMasAdelantado.transform.position.x)
            {
                fondoMasAdelantado = fondo.gameObject;
            }
        }
        return fondoMasAdelantado;
    }
}
