using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerCheckPoint : MonoBehaviour
{
    public bool TemCarvao = false;
    public GameObject objetoParaSpawnar; // Defina isso no Inspector
    public Vector3 offsetDoSpawn; // Defina isso no Inspector
    public  Vector3 ultimoCheckpoint; // Armazena a posição do último checkpoint

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.tag == "Carvão")
                {
                    TemCarvao = true;
                    Destroy(hitCollider.gameObject);
                }
                else if (hitCollider.tag == "CheckPoint" && TemCarvao)
                {
                    Vector3 posicaoDoSpawn = transform.position + offsetDoSpawn;
                    Quaternion rotacaoDoSpawn = Quaternion.Euler(0, -90, 0); // Rotação de -90 graus no eixo Y
                    Instantiate(objetoParaSpawnar, posicaoDoSpawn, rotacaoDoSpawn);
                    TemCarvao = false;
                    ultimoCheckpoint = new Vector3(0, posicaoDoSpawn.y, posicaoDoSpawn.z); // Atualiza a posição do último checkpoint com X = 0
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Morte")
        {
             // desprender child
             // Encontre todos os filhos com a tag "box"
       Transform[] filhosComTagBox = transform.GetComponentsInChildren<Transform>().Where(t => t.CompareTag("box")).ToArray();
        // Desanexe cada um dos filhos encontrados
        foreach (var filho in filhosComTagBox)
        {
            filho.SetParent(null);
        }

        // Encontre todos os objetos com a tag "Inimigo 2"
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo 2");
        // Destrua cada um dos inimigos encontrados
        foreach (var inimigo in inimigos)
        {
            Destroy(inimigo);
        }
        // Encontre todos os objetos com a tag "Dog"
        GameObject[] Dog = GameObject.FindGameObjectsWithTag("Dog");
        // Destrua cada um dos Dogs encontrados
        foreach (var dog in Dog)
        {
            Destroy(dog);
        }


            transform.position = ultimoCheckpoint; // Move o jogador de volta para o último checkpoint
        }
    }
}
