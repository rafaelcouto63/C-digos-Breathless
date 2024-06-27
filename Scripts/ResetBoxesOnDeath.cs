using UnityEngine;
using UnityEngine.UI;

public class ResetBoxesOnDeath : MonoBehaviour
{
    private Vector3[] initialParentPositions;
    private Vector3[][] initialChildPositions;
    private GameObject[] boxes;
    public Button meuBotao; // Variável para armazenar a referência ao botão
    public bool botaoClicado = false;

    private void Start()
    {

         meuBotao.onClick.AddListener(OnBotaoClicado);

        // Encontre todos os objetos com a tag "box", incluindo seus filhos
        boxes = GameObject.FindGameObjectsWithTag("box");

        // Armazene as posições iniciais do objeto pai e de seus filhos
        initialParentPositions = new Vector3[boxes.Length];
        initialChildPositions = new Vector3[boxes.Length][];
        for (int i = 0; i < boxes.Length; i++)
        {
            initialParentPositions[i] = boxes[i].transform.position;

            // Armazene as posições iniciais dos filhos
            initialChildPositions[i] = new Vector3[boxes[i].transform.childCount];
            for (int j = 0; j < boxes[i].transform.childCount; j++)
            {
                initialChildPositions[i][j] = boxes[i].transform.GetChild(j).position;
            }
        }
    }
    

    private void Update()
    {
        if (botaoClicado)
        {
            botaoClicado = false;
            // Redefina as posições do objeto pai e de seus filhos
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].transform.position = initialParentPositions[i]; // Redefina a posição do pai
                for (int j = 0; j < boxes[i].transform.childCount; j++)
                {
                    boxes[i].transform.GetChild(j).position = initialChildPositions[i][j]; // Redefina a posição do filho
                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Morte"))
        {
            
            // Redefina as posições do objeto pai e de seus filhos
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].transform.position = initialParentPositions[i]; // Redefina a posição do pai
                for (int j = 0; j < boxes[i].transform.childCount; j++)
                {
                    boxes[i].transform.GetChild(j).position = initialChildPositions[i][j]; // Redefina a posição do filho
                }
            }
        }
    }

    void OnBotaoClicado()
    {
        botaoClicado = true;
    }
}