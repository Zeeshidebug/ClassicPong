using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;

    public TextMeshProUGUI scoreTextPlayer1;
    public TextMeshProUGUI scoreTextPlayer2;

    [Header("Win UI")]
    public GameObject winPanel;
    public TextMeshProUGUI winText;
    public Button restartButton;

    public ballMovement ballScript;

    void Start()
    {
        // Pastikan panel menang mati pas awal
        winPanel.SetActive(false);

        // Setup tombol buat manggil fungsi RestartGame pas diklik
        restartButton.onClick.AddListener(RestartGame);
    }

    public void Player1Scored()
    {
        scorePlayer1++;
        scoreTextPlayer1.text = scorePlayer1.ToString();
        CheckWinCondition();
    }

    public void Player2Scored()
    {
        scorePlayer2++;
        scoreTextPlayer2.text = scorePlayer2.ToString();
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (scorePlayer1 >= 11)
        {
            GameOver("Player 1 Wins!");
        }
        else if (scorePlayer2 >= 11)
        {
            GameOver("Player 2 Wins!");
        }
        else
        {
            // Kalau belum ada yang 11, baru reset bola buat main lagi
            ballScript.ResetBall();
        }
    }

    void GameOver(string winnerName)
    {
        winPanel.SetActive(true);
        winText.text = winnerName;

        // Berhentikan bola
        ballScript.gameObject.SetActive(false);

        // Opsional: Berhentikan waktu game (Physics)
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        // Balikin waktu ke normal sebelum restart
        Time.timeScale = 1;
        // Reload scene yang sekarang lagi dibuka
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}