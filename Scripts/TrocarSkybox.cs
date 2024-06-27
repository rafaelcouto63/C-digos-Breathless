using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocarSkybox : MonoBehaviour
{
    public Material novoSkybox; // O material do Skybox que você deseja definir
    private Material skyboxOriginal; // Material original do Skybox

    private void Start()
    {
        skyboxOriginal = RenderSettings.skybox; // Salva o material original do Skybox
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto que entrou no trigger é o jogador
        {
            RenderSettings.skybox = novoSkybox; // Define o novo material do Skybox
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto que saiu do trigger é o jogador
        {
            RenderSettings.skybox = skyboxOriginal; // Restaura o material original do Skybox
        }
    }
}
