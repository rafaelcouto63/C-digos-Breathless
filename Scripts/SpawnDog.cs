using UnityEngine;

public class SpawnDog : MonoBehaviour
{
    public GameObject objectPrefab; // O prefab do objeto que você quer instanciar
    public Transform spawnLocation; // A localização onde o objeto será instanciado
    
    public bool check = true;

    private void Update()
    {
     // Encontre todos os objetos com a tag "Dog"
            GameObject[] Dog = GameObject.FindGameObjectsWithTag("Dog");
        
            if (Dog.Length == 0)
            {
                check = true;
            }
    }
    // Esta função é chamada quando outro collider entra em contato com o collider deste objeto
    void OnTriggerEnter(Collider other)
    {
        if (check)
        {
        check = false;
        // Instancia o objeto na posição desejada
        Instantiate(objectPrefab, spawnLocation.position, Quaternion.identity);
        }
    }
}