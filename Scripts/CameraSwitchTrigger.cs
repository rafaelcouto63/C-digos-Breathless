using UnityEngine;

public class CameraSwitchTrigger : MonoBehaviour
{
    private Camera mainCamera; // Referência à câmera principal
    public GameObject animationObject; // Referência ao objeto com o componente de animação
    public float destroyDelay = 5f; // Tempo em segundos antes de destruir os objetos

    private void Start()
    {
        // Desative o componente de animação no início (opcional)
        animationObject.SetActive(false);
        mainCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ative a nova câmera e desative a câmera principal
            mainCamera.enabled = false;
            // Ative o componente de animação
            animationObject.SetActive(true);
            // Inicia a contagem para destruir os objetos após o atraso especificado
        Invoke("DestroyObjects", destroyDelay);
        }
    }

    private void DestroyObjects()
    {
        // Ative a câmera principal antes de destruir os objetos
        mainCamera.enabled = true;

        // Destrua os objetos após o atraso especificado
        Destroy(gameObject);
        Destroy(animationObject);
    }
}