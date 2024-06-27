using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buraco : MonoBehaviour
{
    public GameObject Palyer;
    public PlayerCheckPoint playerCheckPoint;
    public Vector3 UltimoCheckpoint;
    private void Update()
    {
        UltimoCheckpoint = playerCheckPoint.ultimoCheckpoint;
    }
    
    private void OnTriggerEnter(Collider Player)
    {
        Palyer.transform.position = UltimoCheckpoint;
    }
}
