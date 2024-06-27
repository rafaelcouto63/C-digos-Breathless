using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbaixarBotao : MonoBehaviour
{
    public float descendValue = 0.2f;
    public Vector3 originalPosition;
    public bool check;
    private void Start() 
    {
        originalPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("box"))
        {
            check = true;
            transform.position = new Vector3(transform.position.x, transform.position.y - descendValue, transform.position.z);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("box"))
        {
            check = false;
            transform.position = originalPosition;
        }
    }
}
