using UnityEngine;

public class Interruptor : MonoBehaviour
{
    public Light luzAssociada;
    private bool ligado = true;

    void Start()
    {
        luzAssociada.enabled = ligado;
    }

    public void Interagir()
    {
        ligado = !ligado;
        luzAssociada.enabled = ligado;
        Debug.Log("Luz " + (ligado ? "ligada" : "desligada"));
    }
}
