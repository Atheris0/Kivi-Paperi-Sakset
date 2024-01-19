using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        resultText.text = "Choose Rock, Paper, or Scissors";
        playerScoreText.text = "Player: 0";
        computerScoreText.text = "Computer: 0";

        rockButton.onClick.AddListener(() => MakeChoice(Choice.Rock));
        paperButton.onClick.AddListener(() => MakeChoice(Choice.Paper));
        scissorsButton.onClick.AddListener(() => MakeChoice(Choice.Scissors));
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
        }
        else if ((player == Choice.Rock && computer == Choice.Scissors) ||
                 (player == Choice.Paper && computer == Choice.Rock) ||
                 (player == Choice.Scissors && computer == Choice.Paper))
        {
            resultText.text = "You win!";
            playerScore++;
        }
        else
        {
            resultText.text = "Computer wins!";
            computerScore++;
        }

        UpdateScore();

        // Check for game end
        if (playerScore == maxScore || computerScore == maxScore)
        {
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
        if (playerScore == maxScore)
        {
            resultText.text = "You win the game!";
        }
        else
        {
            resultText.text = "You lost the game!";
        }
    }
}
