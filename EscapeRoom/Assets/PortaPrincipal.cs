using UnityEngine;

public class PortaPrincipal : MonoBehaviour , IInteragivel
{

    public string MensagemInteracao()
    {
        return "Prima E para Sair";
    }

   
    public void Interagir()
    {
        FindFirstObjectByType<GameINFO>().VitoriaJogo();
    }
}
