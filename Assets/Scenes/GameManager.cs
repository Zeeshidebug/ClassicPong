using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;

    public TextMeshProUGUI scoreTextPlayer1;
    public TextMeshProUGUI scoreTextPlayer2;

    public ballMovement ballScript; // Drag objek bola ke sini nanti

    public void Player1Scored()
    {
        scorePlayer1++;
        scoreTextPlayer1.text = scorePlayer1.ToString();
        ballScript.ResetBall();
    }

    public void Player2Scored()
    {
        scorePlayer2++;
        scoreTextPlayer2.text = scorePlayer2.ToString();
        ballScript.ResetBall();
    }
}