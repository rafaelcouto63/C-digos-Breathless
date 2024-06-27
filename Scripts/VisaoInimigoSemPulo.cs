using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisaoInimigoSemPulo : MonoBehaviour
{
        private float coolDown = 0;
    public GameObject jogador;
    
    public int Distancia = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool JogadorProximo()
    {
        if (Vector3.Distance(transform.position, jogador.transform.position) < 30)
        {

            Vector3 alvo = jogador.transform.position - transform.position;
            
           

            if (Vector3.Angle(transform.forward, alvo) < Distancia)
            {
                
                Ray raio = new Ray(transform.position, alvo);   
                RaycastHit hit;
                if (Physics.Raycast(raio, out hit, 20))
                {
                    
                    if (hit.transform == jogador.transform)
                    {
                       
                        return true;
                    }
                }
            }
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        
        if (JogadorProximo() == true)
        {
            Vector3 olhar = jogador.transform.position;
            olhar.y = 1;
            olhar.x = 0;
            transform.LookAt(olhar);
            
        }
    }
}
