using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumi : MonoBehaviour
{
    public GameObject player; 

    public MoverPorta moverporta; 

    public Vector3 offset; 

    public float speed = 1.0f; // Velocidade da interpolação

    private Vector3 vector;
    
    public float rotationY = 180f;
    void Update() 
    {
        //se move para ojogador quando a jaula se abrir
        if (moverporta.isActive) 
        {
            vector = new Vector3 (player.transform.position.x + offset.x, player.transform.position.y + offset.y, player.transform.position.z+ offset.z);
            transform.position = Vector3.Lerp(transform.position, vector, Time.deltaTime * speed);
        }

        if (transform.position.z > player.transform.position.z)
        {
            // Rotaciona o objeto em 180 graus no eixo Y
            transform.rotation = Quaternion.Euler(-35, rotationY, transform.rotation.z);
        }
        else
        {
            // Volta a rotação do objeto para zero no eixo Y
            transform.rotation = Quaternion.Euler(-35, 180, transform.rotation.z);
        }
    }
}
