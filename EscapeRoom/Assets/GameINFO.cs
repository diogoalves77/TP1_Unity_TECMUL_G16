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
    private int puzzlesCompletos = 0;

    [Header("UI")]
    public TMP_Text textTimer;
    public TMP_Text textPuzzles;
    public GameObject painelGameOver;
    
    [Header("Player")]
    public FirstPersonController playerController;
    
    void Start()
    {
        tempoRestante = tempoTotal;
        painelGameOver.SetActive(false);
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
        textPuzzles.text = puzzlesCompletos + "/" + totalPuzzles + " Puzzles" ;
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

    void VitoriaJogo()
    {
        jogoAtivo = false;
        Debug.Log("Vitória!");
        // podes criar um painel de vitória mais tarde
    }

   public void VoltarMenu()
    {
    Time.timeScale = 1f;
    SceneManager.LoadScene("MenuPrincipal");
    }
}
