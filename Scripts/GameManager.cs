using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Needed to restart the game

public class GameManager : MonoBehaviour
{
    [Header("UI Text")]
    public Text txtResult;
    public Text txtScoreYou;
    public Text txtScoreCom;

    [Header("UI Images")]
    public Image imgYou;
    public Image imgCom;

    [Header("Sprites")]
    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorsSprite;
    
    // Internal Variables
    private int scorePlayer = 0;
    private int scoreCpu = 0;
    private bool isGameOver = false; // New flag to stop the game
    private int winningScore = 5;    // The goal

    public void OnButtonClick(GameObject buttonObject)
    {
        // 1. If Game is Over, do nothing when button is clicked
        if (isGameOver == true)
        {
            return; 
        }

        // 2. Get the input
        string firstLetter = buttonObject.name.Substring(0, 1);
        int playerChoice = int.Parse(firstLetter);

        // 3. Play the turn
        PlayGame(playerChoice);
    }

    void PlayGame(int you)
    {
        // Update Images
        if (you == 1) imgYou.sprite = rockSprite;
        if (you == 2) imgYou.sprite = paperSprite;
        if (you == 3) imgYou.sprite = scissorsSprite;

        int com = Random.Range(1, 4);

        if (com == 1) imgCom.sprite = rockSprite;
        if (com == 2) imgCom.sprite = paperSprite;
        if (com == 3) imgCom.sprite = scissorsSprite;

        // Calculate Result
        int k = you - com;

        if (k == 0)
        {
            txtResult.text = "It's a Draw!";
            txtResult.color = Color.black;
        }
        else if (k == 1 || k == -2)
        {
            txtResult.text = "You Win!";
            txtResult.color = Color.green;
            scorePlayer++;
        }
        else
        {
            txtResult.text = "Computer Wins!";
            txtResult.color = Color.red;
            scoreCpu++;
        }

        // Update Score Text
        txtScoreYou.text = scorePlayer.ToString();
        txtScoreCom.text = scoreCpu.ToString();

        // --- NEW: CHECK FOR WINNER ---
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (scorePlayer >= winningScore)
        {
            isGameOver = true;
            txtResult.text = "GAME OVER: YOU WON THE MATCH!";
            txtResult.color = Color.blue;
        }
        else if (scoreCpu >= winningScore)
        {
            isGameOver = true;
            txtResult.text = "GAME OVER: COMPUTER WON!";
            txtResult.color = Color.red;
        }
    }

    // Call this from a button to restart
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}