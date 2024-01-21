using UnityEngine;
using UnityEngine.UI;

public class ComputerChoiceHandler : MonoBehaviour
{
    public Image computerChoiceImage;
    public Sprite questionMarkSprite;
    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorsSprite;

    void Start()
    {
        // Set the initial state to question mark
        SetComputerChoice(Choice.QuestionMark);
    }

    public void SetComputerChoice(Choice newChoice)
    {
        Sprite selectedSprite = questionMarkSprite;

        // Assign the appropriate sprite based on the choice
        switch (newChoice)
        {
            case Choice.Rock:
                selectedSprite = rockSprite;
                break;

            case Choice.Paper:
                selectedSprite = paperSprite;
                break;

            case Choice.Scissors:
                selectedSprite = scissorsSprite;
                break;
        }

        // Set the sprite on the computerChoiceImage
        if (computerChoiceImage != null)
        {
            computerChoiceImage.sprite = selectedSprite;
        }
        else
        {
            Debug.LogError("computerChoiceImage is not assigned!");
        }
    }
}