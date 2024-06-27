using UnityEngine;

public class DestroyOnDistance : MonoBehaviour
{
    public float maxDistance; // A distância máxima entre o jogador e o objeto

    // Atualizar é chamado uma vez por frame
    void Update()
    {
        // Localiza o jogador pela tag "Player"
        GameObject player = GameObject.FindWithTag("Player");

        // Se o jogador não foi localizado, retorna e não executa o restante do código
        if (player == null)
        {
            return;
        }

        // Verifica se a distância entre o jogador e o objeto é menor ou igual à distância máxima
        if (Vector3.Distance(transform.position, player.transform.position) >= maxDistance)
        {
            // Se a condição for verdadeira, destrói o objeto
            Destroy(gameObject);
        }
    }
}