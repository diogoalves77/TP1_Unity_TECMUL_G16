using UnityEngine;

public class Trofeu : MonoBehaviour, IInteragivel
{
    public string MensagemInteracao()
    {
        return "Prima E para apanhar o troféu";
    }

     public void Interagir()
    {
         FindFirstObjectByType<GameINFO>().CompletarPuzzle();
        gameObject.SetActive(false);
    }
}
