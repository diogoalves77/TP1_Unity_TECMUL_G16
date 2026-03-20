using UnityEngine;

public class Gaveta : MonoBehaviour
{
    public Vector3 direcaoAbertura = new Vector3(0, 0, 0.4f);
    public float velocidade = 2f;

    private Vector3 posicaoFechada;
    private Vector3 posicaoAberta;
    private bool aberta = false;
    private bool aAnimar = false;

    void Start()
    {
        posicaoFechada = transform.position; // posição mundial
        posicaoAberta = posicaoFechada + direcaoAbertura;
    }

    void Update()
    {
        if (aAnimar)
        {
            Vector3 destino = aberta ? posicaoAberta : posicaoFechada;
            transform.position = Vector3.MoveTowards(
                transform.position, destino, velocidade * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, destino) < 0.001f)
            {
                transform.position = destino;
                aAnimar = false;
            }
        }
    }

    public void Interagir()
    {
        aberta = !aberta;
        aAnimar = true;
        Debug.Log("Gaveta " + (aberta ? "aberta" : "fechada"));
    }
}
