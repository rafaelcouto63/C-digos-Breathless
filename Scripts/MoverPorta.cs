using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPorta : MonoBehaviour
{
     public AbaixarBotao botao1;
    public AbaixarBotao botao2;
    public AbaixarBotao botao3;
    private bool check = true;
    public float valorMovimento = -2.8f;
    public bool isActive = false;

    private void Update()
    {
        if (botao1.check && botao2.check && botao3.check && check == true)
        {
            transform.position = new Vector3(transform.position.x + valorMovimento, transform.position.y, transform.position.z);
            isActive = true;
            check = false;
        }
    }
}
