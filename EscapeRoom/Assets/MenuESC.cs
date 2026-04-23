using UnityEngine;

public class MenuESC : MonoBehaviour
{
    public GameObject painelESC;
    private bool pausado = false;

    void Start()
{
    painelESC.SetActive(false);
}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausado = !pausado;

            if (pausado)
            {
                painelESC.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                FindFirstObjectByType<FirstPersonController>().enabled = false;
            }
            else
            {
                painelESC.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                FindFirstObjectByType<FirstPersonController>().enabled = true;
            }
        }
    }

    public void Continuar()
    {
        pausado = false;
        painelESC.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FindFirstObjectByType<FirstPersonController>().enabled = true;
    }

    public void SairMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuPrincipal");
    }
}