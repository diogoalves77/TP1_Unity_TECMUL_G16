using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;
    public float forcaSalto = 5f;

    [Header("Camera")]
    public Transform cameraPrincipal;
    public float sensibilidade = 2f;
    public float limiteVertical = 80f;

    private Rigidbody rb;
    private float rotacaoVertical = 0f;
    private bool noChao = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // esconde o cursor
        Cursor.visible = false;
    }

    void Update()
    {
        // --- Rotação com o rato ---
        float mouseX = Input.GetAxis("Mouse X") * sensibilidade;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidade;

        // Roda o corpo na horizontal
        transform.Rotate(Vector3.up * mouseX);

        // Roda só a câmara na vertical (com limite)
        rotacaoVertical -= mouseY;
        rotacaoVertical = Mathf.Clamp(rotacaoVertical, -limiteVertical, limiteVertical);
        cameraPrincipal.localRotation = Quaternion.Euler(rotacaoVertical, 0f, 0f);

        // --- Salto ---
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.AddForce(Vector3.up * forcaSalto, ForceMode.Impulse);
        }

        // Soltar cursor com Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void FixedUpdate()
    {
        // --- Movimento WASD ---
        float x = Input.GetAxisRaw("Horizontal"); // A/D
        float z = Input.GetAxisRaw("Vertical");   // W/S

        Vector3 direcao = transform.right * x + transform.forward * z;
        direcao = direcao.normalized;

        // Mantém a velocidade vertical (gravidade) e aplica o movimento horizontal
        Vector3 velocidadeAlvo = direcao * velocidade;
        velocidadeAlvo.y = rb.linearVelocity.y;
        rb.linearVelocity = velocidadeAlvo;
    }

    void OnCollisionStay(Collision collision)
    {
        noChao = true;
    }

    void OnCollisionExit(Collision collision)
    {
        noChao = false;
    }
}
