using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed = 6f; // Velocidade de movimento do inimigo
    public float moveSpeedMin = 3f;
    public int x;
    private Transform player; // Referência ao jogador
    public float minDistanceToBox = 2f; // Distância mínima em relação aos objetos com a tag "box"
    private GameObject[] boxes; // Referência aos objetos com a tag "box"

    private void Start()
    {
        // Encontra o jogador usando a tag "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Encontra todos os objetos com a tag "box"
        boxes = GameObject.FindGameObjectsWithTag("box");

        x = PlayerPrefs.GetInt("count", -1);

        if (x < (moveSpeed - moveSpeedMin))
        {
            x++;
        }
    }

    private void Update()
    {
        // Calcula a direção do jogador em relação ao inimigo
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0f; // Ignora o movimento vertical

        // Move o inimigo na direção do jogador
        transform.Translate(directionToPlayer.normalized * (moveSpeed - x) * Time.deltaTime);

        // Limita a posição do inimigo no eixo x
        if (transform.position.x > 0.1f)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = 0.1f;
            transform.position = newPosition;
        }

        // Calcula a direção para manter distância dos objetos com a tag "box"
        foreach (var box in boxes)
        {
            Vector3 directionToBox = box.transform.position - transform.position;
            directionToBox.y = 0f; // Ignora o movimento vertical

            // Move o inimigo na direção oposta ao objeto com a tag "box"
            if (directionToBox.magnitude < minDistanceToBox)
            {
                transform.Translate(-directionToBox.normalized * moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o inimigo colidiu com uma caixa
        if (collision.gameObject.CompareTag("box"))
        {
            // Move o inimigo na direção negativa do eixo x
            Vector3 newDirection = new Vector3(-9f, 0f, 0f);
            transform.Translate(newDirection * moveSpeed * Time.deltaTime);
        }
    }

    private void OnDestroy()
    {
        // Salve o valor da variável no PlayerPrefs antes de destruir o GameObject
        PlayerPrefs.SetInt("count", x);
        PlayerPrefs.Save();
    }
}
