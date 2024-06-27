using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalJogo : MonoBehaviour
{
    public float t = 2f; // Tempo de espera para ativar o Canva (em segundos)
    public float n = 5f; // Tempo de espera para encerrar o jogo (em segundos)
    public GameObject canvasObject; // Referência ao objeto Canva

    private Collider _collider;

    void Start()
    {
        _collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") // Verifique se o collider que acionou foi o player
        {
            Invoke("ActivateCanvas", t); // Ativa o Canva após o tempo de espera
            Invoke("EndGame", n); // Encerra o jogo após n segundos
        }
    }

    void ActivateCanvas()
    {
        canvasObject.SetActive(true); // Ativa o objeto Canva
    }

    void EndGame()
    {
        Application.Quit(); // Encerra o aplicativo
        Debug.Log("Encerrou");
    }
}
