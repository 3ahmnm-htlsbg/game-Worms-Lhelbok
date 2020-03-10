using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerWorm;
    public Text playerOneText;
    public Text playerTwoText;
    private int playerOneLife;
    private int playerTwoLife;

    public GameObject Health;

    private int lifeTotal = 4;
    private int addPoints = 2;

    [SerializeField] private Text winnerText;

    void Start()
    {
        playerOneLife = lifeTotal;
        playerTwoLife = lifeTotal;
        SpawnPlayers(true);
        SpawnPlayers(false);
        UpdateLife();
    }

    private void Update()
    {
        if (waitForInput == true)
        {
            //if the game is finished the key return can be pressed to restart the game 
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ResetGame();
                waitForInput = false;
                winnerText.text = "";
            }
        }
    }
    void SpawnPlayers(bool playerOne)
    {
        if (playerOne == true)
        {
            //PlayerOne -> vector defines the spawn position on the left side
            Instantiate(playerWorm, new Vector3(-6.57f, 2.7f, 0f), Quaternion.identity);
        }
        if (playerOne == false)
        {
            //PlayerTwo -> vector defines the spawn position on the right side
            Instantiate(playerWorm, new Vector3(6.57f, 2.7f, 0f), Quaternion.identity);
        }
    }
    void UpdateLife()
    {
        //updates text in the canvas from player one and two
        playerOneText.text = playerOneLife.ToString();
        playerTwoText.text = playerTwoLife.ToString();
    }

    //add health points to the life count when player collides with the cube
    public void PlayerAddHealthGM(bool PlayerOne)
    {
       if (PlayerOne == true && playerOneLife < lifeTotal)
        {
            playerOneLife += addPoints;
            UpdateLife();
        }
        if (PlayerOne == false && playerTwoLife < lifeTotal)
        {
            playerTwoLife += addPoints;
            UpdateLife();
        }
    }

    //substracts points from life count when a player is hit by a bullet
    public void PlayerDiedGM(bool PlayerOne)
    {
        if (PlayerOne == true)
        {
            playerOneLife -= 1;
            UpdateLife();
            if (playerOneLife <= 0)
            {
                playerHasWon = "Player Two";
                PresentWinner();
            }
            SpawnPlayers(true);
        }
        if (PlayerOne == false)
        {
            playerTwoLife -= 1;
            UpdateLife();
            if (playerTwoLife <= 0)
            {
                playerHasWon = "Player One";
                PresentWinner();
            }
            SpawnPlayers(false);
        }

    }

    string playerHasWon;
    bool waitForInput;

    void PresentWinner()
    {
        //presents the winner 
        winnerText.text = playerHasWon + " is the winner. To continue, press 'Enter' to restart the game.";
        waitForInput = true;
    }
    void ResetGame()
    {
        //Resets the entire game
        playerOneLife = lifeTotal;
        playerTwoLife = lifeTotal;
        UpdateLife();
    }
}

