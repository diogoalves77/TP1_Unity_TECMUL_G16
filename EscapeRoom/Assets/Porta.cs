using UnityEngine;

public class Porta : MonoBehaviour
{
	public float anguloAbertura = 90f;
	public float velocidade = 130f;
	
	private bool aberta = false;
	private Quaternion rotacaoFechada;
	private Quaternion rotacaoAberta;
	
	
	
    void Start()
    {
    	rotacaoFechada = transform.rotation;
    	rotacaoAberta = rotacaoFechada * Quaternion.Euler(0, anguloAbertura, 0);
        
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
}
