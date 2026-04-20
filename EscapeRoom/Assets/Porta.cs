using UnityEngine;

public class Porta : MonoBehaviour , IInteragivel
{
	public float anguloAbertura = 90f;
	public float velocidade = 130f;
	
	private bool aberta = false;
	private Quaternion rotacaoFechada;
	private Quaternion rotacaoAberta;
	
	
	
void Awake()
{
    rotacaoFechada = transform.rotation;
    rotacaoAberta = rotacaoFechada * Quaternion.Euler(0, anguloAbertura, 0);
    Debug.Log("PORTA AWAKE");
}

     void Update()
    {
            Quaternion destino = aberta ? rotacaoAberta : rotacaoFechada;
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, destino, velocidade * Time.deltaTime
            );

            
    }

    public void Interagir()
    {
        aberta = !aberta;
    }

     public string MensagemInteracao()
    {
        return "Prima E para " + (aberta ? "fechar" : "abrir") + " a porta";
    }
    
}
