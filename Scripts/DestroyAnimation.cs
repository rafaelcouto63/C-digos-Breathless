using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimation : MonoBehaviour
{
    public float tempoParaDestruir = 3f; // Tempo em segundos antes de destruir o objeto

    private void Start()
    {
        // Inicia a contagem regressiva para destruir o objeto
        Invoke("DestruirObjeto", tempoParaDestruir);
    }

    private void DestruirObjeto()
    {
        // Destroi o objeto
        Destroy(gameObject);
    }
}
