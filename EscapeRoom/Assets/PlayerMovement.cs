using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float jumpForce = 5f;
    
    private CharacterController controller;
    private Camera playerCamera;
    private Vector3 velocity;
    private float xRotation = 0f;
    private bool isGrounded;
    
    void Start()
    {
        // Buscar o componente CharacterController neste GameObject
        controller = GetComponent<CharacterController>();
        
        // Buscar a câmara que está filha deste GameObject
        playerCamera = GetComponentInChildren<Camera>();
        
        // Bloquear o cursor no centro do ecrã
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        // Verificar se está no chão (raio para baixo)
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        
        // ANDAR - WASD
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * walkSpeed * Time.deltaTime);
        
        // OLHAR - Rato
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        // Rodar o corpo (horizontal)
        transform.Rotate(Vector3.up * mouseX);
        
        // Rodar a câmara (vertical)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // SALTAR - Espaço
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
        }
        
        // GRAVIDADE
        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        // Parar gravidade quando no chão
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
}