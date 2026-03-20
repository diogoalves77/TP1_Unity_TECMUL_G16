using UnityEngine;

public class Gaveta : MonoBehaviour
{
    public Vector3 direcaoAbertura = new Vector3(0, 0, 0.4f);
    public float velocidade = 2f;

    private Vector3 posicaoFechada;
    private Vector3 posicaoAberta;
    private bool aberta = false;
    private bool jogadorPerto = false;
    private bool aAnimar = false;

    void Start()
    {
        posicaoFechada = transform.localPosition;
        posicaoAberta = posicaoFechada + direcaoAbertura;
        Debug.Log("Gaveta iniciada: " + gameObject.name);
    }

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressionado — a abrir/fechar gaveta");
            aberta = !aberta;
            aAnimar = true;
        }

        if (aAnimar)
        {
            Vector3 destino = aberta ? posicaoAberta : posicaoFechada;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, destino, velocidade * Time.deltaTime);

            if (Vector3.Distance(transform.localPosition, destino) < 0.001f)
            {
                transform.localPosition = destino;
                aAnimar = false;
            }
        }
    }

   void OnTriggerEnter(Collider other)
{
    Debug.Log("QUALQUER COISA entrou: " + other.gameObject.name);
}

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            Debug.Log("Jogador saiu da gaveta");
        }
    }
}