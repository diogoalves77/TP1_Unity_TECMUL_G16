using UnityEngine;

public class PegarObjeto : MonoBehaviour
{
    [Header("Configuração")]
    public float distanciaMaxima = 3f;
    public float distanciaSegura = 2f;
    public float velocidadeSeguir = 10f;

    private Rigidbody objetoAtual = null;

    void Update()
    {
        // Tentar pegar
        if (Input.GetKeyDown(KeyCode.E))
        {
            TentarPegar();
        }

        // Largar ao soltar E
        if (Input.GetKeyUp(KeyCode.E))
        {
            Largar();
        }

        // Mover o objeto com a câmara enquanto está a ser segurado
        if (objetoAtual != null)
        {
            Vector3 destino = transform.position + transform.forward * distanciaSegura;
            Vector3 direcao = destino - objetoAtual.transform.position;
            objetoAtual.linearVelocity = direcao * velocidadeSeguir;
            objetoAtual.angularVelocity = Vector3.zero; // não roda
        }
    }

    void TentarPegar()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanciaMaxima))
        {
            Debug.Log("Raycast acertou: " + hit.collider.gameObject.name);

            if (hit.collider.CompareTag("Pegavel"))
            {
                objetoAtual = hit.collider.GetComponent<Rigidbody>();
                if (objetoAtual != null)
                {
                    objetoAtual.useGravity = false;
                    Debug.Log("Objeto apanhado!");
                }
            }
        }
    }

    void Largar()
    {
        if (objetoAtual != null)
        {
            objetoAtual.useGravity = true;
            objetoAtual.linearVelocity = Vector3.zero;
            objetoAtual = null;
            Debug.Log("Objeto largado!");
        }
    }
}
