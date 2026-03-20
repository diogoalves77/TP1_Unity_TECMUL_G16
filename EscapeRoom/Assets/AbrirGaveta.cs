using UnityEngine;

public class AbrirGaveta : MonoBehaviour
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

                if (hit.collider.CompareTag("Gaveta"))
                {
                    Gaveta gaveta = hit.collider.GetComponent<Gaveta>();
                    if (gaveta != null)
                        gaveta.Interagir();
                }
            }
        }
    }
}
