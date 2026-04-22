using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameINFO : MonoBehaviour
{
    [Header("Timer")]
    public float tempoTotal = 900f; // 15 minutos em segundos
    private float tempoRestante;
    private bool jogoAtivo = true;
    

    [Header("Puzzles")]
    public int totalPuzzles = 5;
    public int puzzlesCompletos = 0;

    [Header("UI")]
    public TMP_Text textTimer;
    public TMP_Text textPuzzles;
    public GameObject painelGameOver;
    public GameObject painelVitoria;
    
    [Header("Player")]
    public FirstPersonController playerController;

    [Header("Audio")]
    public AudioSource musicaFundo;
    public AudioClip musicaVitoria;
    
    void Start()
    {
        tempoRestante = tempoTotal;
        painelGameOver.SetActive(false);
        painelVitoria.SetActive(false);
        AtualizarPuzzles();
    
    }

    void Update()
    {
        if (!jogoAtivo) return;

        tempoRestante -= Time.deltaTime;

        if (tempoRestante <= 0)
        {
            tempoRestante = 0;
            GameOver();
        }

        AtualizarTimer();
    }

    void AtualizarTimer()
    {
        int minutos = Mathf.FloorToInt(tempoRestante / 60);
        int segundos = Mathf.FloorToInt(tempoRestante % 60);
        textTimer.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    void AtualizarPuzzles()
    {
        textPuzzles.text = puzzlesCompletos + "/" + totalPuzzles + " Keys Found";
    }

    public void CompletarPuzzle()
    {
        if (puzzlesCompletos < totalPuzzles)
        {
            puzzlesCompletos++;
            AtualizarPuzzles();

            if (puzzlesCompletos == totalPuzzles)
                VitoriaJogo();
        }
    }

   void GameOver()
{
    jogoAtivo = false;
    painelGameOver.SetActive(true);
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    Time.timeScale = 0f;
    playerController.enabled = false; // desativa o movimento
}
    
    public void Reiniciar()
    {
    	Time.timeScale = 1f; // repõe o tempo antes de carregar
   	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VitoriaJogo()
    {
        
        jogoAtivo = false;
        Time.timeScale = 0f;
        painelVitoria.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       
        FindFirstObjectByType<FirstPersonController>().enabled = false;
        musicaFundo.clip = musicaVitoria;
        musicaFundo.Play(); 
    }

   public void VoltarMenu()
    {
    Time.timeScale = 1f;
    SceneManager.LoadScene("MenuPrincipal");
    }
}
