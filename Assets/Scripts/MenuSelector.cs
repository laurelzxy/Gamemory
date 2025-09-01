using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuSelector : MonoBehaviour
{
    public RectTransform[] opcoes;  // arraste aqui os bot�es/textos
    public RectTransform barra;     // a barra transparente
    public float velocidade = 10f;

    private int indiceAtual = 0;

    void Start()
    {
        AtualizarBarra();
    }

    void Update()
    {
        // Navega��o com setas
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            indiceAtual = (indiceAtual + 1) % opcoes.Length;
            AtualizarBarra();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            indiceAtual = (indiceAtual - 1 + opcoes.Length) % opcoes.Length;
            AtualizarBarra();
        }

        // Confirmar sele��o
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Selecionado: " + opcoes[indiceAtual].name);
        }

        // Movimento suave da barra at� a op��o
        barra.position = Vector3.Lerp(barra.position, opcoes[indiceAtual].position, Time.deltaTime * velocidade);
    }

    void AtualizarBarra()
    {
        // Posiciona a barra diretamente no in�cio (sem transi��o)
        barra.position = opcoes[indiceAtual].position;
    }
}
