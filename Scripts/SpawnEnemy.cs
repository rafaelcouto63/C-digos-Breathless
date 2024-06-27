using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    FieldOfView See ;
    public GameObject player;
    public GameObject enemyPrefab; // O objeto de inimigo que será instanciado
    public float spawnInterval = 5f; // Intervalo de tempo para instanciar inimigos

    public Transform spawnLocation; // Local onde o inimigo será instanciado

    private bool canSeePlayer = false;
    private float lastSpawnTime = 0f;

     public int check = 0;  // spawnar apenas um inimigo

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        See = GetComponent<FieldOfView>();
    }

    private void Update()
    {
        FieldOfViewCheck();

        // Verifica se o jogador está visível e se já passou o intervalo de tempo
        if (canSeePlayer && Time.time - lastSpawnTime >= spawnInterval)
        {
            InstantiateEnemy();
            lastSpawnTime = Time.time;
        }

         // Encontre todos os objetos com a tag "Inimigo 2"
            GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo 2");
        
            if (inimigos.Length == 0)
            {
                check = 0;
            }
        
    }

    private void FieldOfViewCheck()
    {
        if(See.canSeePlayer !=null){
        if(See.canSeePlayer == true)
        {
            canSeePlayer = true;

        } else{

            canSeePlayer = false;

        }
        }
    }

    private void InstantiateEnemy()
    {
        // Instancia o objeto de inimigo na posição atual do SpawnEnemy
         if (enemyPrefab != null && spawnLocation != null && check == 0)
        {
            check = 1;
            Instantiate(enemyPrefab, spawnLocation.position, Quaternion.identity);
        }
    }
}
