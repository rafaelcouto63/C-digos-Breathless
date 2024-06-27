using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrocarPatrulha : MonoBehaviour
{
     public GameObject enemy; // Reference the enemy GameObject
    public MonoBehaviour NPCPatroll; // Reference the script you want to disable (NPCPatroll)
    public MonoBehaviour VisaoInimigoSemPulo; // Reference the script you want to enable (VisaoInimigoSemPulo)

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered)
        {
            isTriggered = true;
            NPCPatroll.enabled = false;
            VisaoInimigoSemPulo.enabled = true;

            // Additional logic when entering trigger (optional)
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isTriggered)
        {
            isTriggered = false;
            NPCPatroll.enabled = true;
            VisaoInimigoSemPulo.enabled = false;

            // Additional logic when exiting trigger (optional)
        }
    }
}
