using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Choice
{
    QuestionMark,
    Rock,
    Paper,
    Scissors
}

public class RPSGame : MonoBehaviour
{
    public Text resultText;
    public Text guidanceText;
    public Text playerScoreText;
    public Text computerScoreText;
    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;

    public ComputerChoiceHandler computerChoiceHandler; // Reference to the ComputerChoiceHandler script

    private int playerScore = 0;
    private int computerScore = 0;

    private const int maxScore = 3;

    // Start is called before the first frame update
    void Start()
    {
        resultText.text = "Choose Rock, Paper or Scissors";
        guidanceText.text = "Press ESC to return to the main menu";
        playerScoreText.text = "Player: 0";
        computerScoreText.text = "Computer: 0";

        rockButton.onClick.AddListener(() => MakeChoice(Choice.Rock));
        paperButton.onClick.AddListener(() => MakeChoice(Choice.Paper));
        scissorsButton.onClick.AddListener(() => MakeChoice(Choice.Scissors));
    }

    void Update()
    {
        // Check for ESC key press to return to the main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }
    }

    public void MakeChoice(Choice playerChoice)
    {
        // Generate a random choice for the computer
        Choice computerChoice = (Choice)Random.Range(1, 4);

        computerChoiceHandler.SetComputerChoice(computerChoice);

        // Compare choices to determine the winner
        DetermineWinner(playerChoice, computerChoice);
    }
    

    void DetermineWinner(Choice player, Choice computer)
    {
        if (player == computer)
        {
            resultText.text = "It's a tie!";
            guidanceText.text = ""; //Guidance text will be invisible during the game
        }
        else if ((player == Choice.Rock && computer == Choice.Scissors) ||
                 (player == Choice.Paper && computer == Choice.Rock) ||
                 (player == Choice.Scissors && computer == Choice.Paper))
        {
            resultText.text = "You win!";
            guidanceText.text = "";
            playerScore++;
        }
        else
        {
            resultText.text = "Computer wins!";
            guidanceText.text = "";
            computerScore++;
        }

        UpdateScore();

        // Check for game end
        if (playerScore == maxScore || computerScore == maxScore)
        {
            // Set guidance text to inform the player to press ESC to return to the main menu
            guidanceText.text = "Press ESC to return to the main menu";
            EndGame();
        }
    }

    void UpdateScore()
    {
        playerScoreText.text = "Player: " + playerScore;
        computerScoreText.text = "Computer: " + computerScore;
    }

    void EndGame()
    {
        // Disable the Rock, Paper, Scissors buttons
        rockButton.interactable = false;
        paperButton.interactable = false;
        scissorsButton.interactable = false;

        if (playerScore == maxScore)
        {
            resultText.text = "You win the game!";
        }
        else
        {
            resultText.text = "You lost the game!";
        }
    }

    void ReturnToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
