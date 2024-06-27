using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] public GameObject painelMenuInicial;
    [SerializeField] public GameObject painelOpcoes;
    // Start is called before the first frame update
    public void Jogar()
    {
       SceneManager.LoadScene("Jogo");
    }
    public void AbrirOpcoes()
    {
         painelMenuInicial.SetActive(false);
         painelOpcoes.SetActive(true);
    }
    public void FecharJogar()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void SairJogo()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    
}
