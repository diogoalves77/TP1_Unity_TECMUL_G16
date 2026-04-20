using UnityEngine;


public class PortaPrincipal : MonoBehaviour , IInteragivel
{

    public string MensagemInteracao()
    {       
       GameINFO gameInfo = FindFirstObjectByType<GameINFO>();
        if (gameInfo.puzzlesCompletos < gameInfo.totalPuzzles)
            return "Encontra todas as chaves para abrires a porta!";
        else
            return "Prima E para sair";
        
    }

   
    public void Interagir()
    {
       GameINFO gameInfo = FindFirstObjectByType<GameINFO>();
        if (gameInfo.puzzlesCompletos >= gameInfo.totalPuzzles)
            gameInfo.VitoriaJogo();
    }
}
