using UnityEngine;

public class AbrirPorta : MonoBehaviour
{
    public float distanciaMaxima = 2.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distanciaMaxima))
            {
                Debug.Log("Raycast acertou: " + hit.collider.gameObject.name);

                if (hit.collider.CompareTag("Porta"))
                {
                    Porta porta = hit.collider.GetComponent<Porta>();
                    if (porta != null)
                        porta.Interagir();
                }
            }
        }
    }
}
