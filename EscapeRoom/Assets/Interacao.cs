using UnityEngine;
using TMPro;

public class Interacao : MonoBehaviour
{
    public float distanciaMaxima = 2.5f;
    public TMP_Text textoInteracao;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanciaMaxima))
        {
            IInteragivel interagivel = hit.collider.GetComponent<IInteragivel>();

            if (interagivel != null)
            {
                textoInteracao.text = interagivel.MensagemInteracao();

                if (Input.GetKeyDown(KeyCode.E))
                    interagivel.Interagir();

                return;
            }
        }

        textoInteracao.text = "";
    }
}