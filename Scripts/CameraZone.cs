using UnityEngine;

public class CameraZone : MonoBehaviour
{
    public Camera newCamera; // A nova câmera que você deseja ativar
    private Camera mainCamera; // Referência à câmera principal
    public bool isInCollider = false;

    private void Start()
    {
        mainCamera = Camera.main;
        newCamera.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInCollider = true;
            // Ative a nova câmera e desative a câmera principal
            newCamera.enabled = true;
            mainCamera.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInCollider = false;
            // Desative a nova câmera e ative a câmera principal
            newCamera.enabled = false;
            mainCamera.enabled = true;
        }
    }
}