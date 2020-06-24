using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerWorm;
    public Text playerOneText;
    public Text playerTwoText;
    public int playerOneLife;
    public int playerTwoLife;

    private int lifeTotal = 4;
    private int addPoints = 2;

    string playerHasWon;
    bool waitForInput;
    [SerializeField] private Text winnerText;

    Vector3 startPosition1;
    Vector3 startPosition2;
    Vector3 instructionPosition;

    GameObject clone1;
    GameObject clone2;
    public GameObject instructions;

    void Start()
    {
        playerOneLife = lifeTotal;
        playerTwoLife = lifeTotal;
        startPosition1 = new Vector3(-6.35f, 4.615f, 0.119f);
        startPosition2 = new Vector3(+6.35f, 4.615f, 0.119f);
        instructionPosition = new Vector3(0f, 0f, 0f);
        SpawnPlayers(true); //Zeichnet Player 1
        SpawnPlayers(false); //Zeichnet Player 2
        UpdateLife();

        
    }

    private void Update()
    {
        if (Input.GetKey("space"))
        {

            //instructions = GameObject.FindGameObjectWithTag("Instructions");
            instructions.SetActive(true);
        }
        else {
            instructions.SetActive(false);
        }

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
            clone1 = Instantiate(playerWorm, startPosition1, transform.rotation * Quaternion.Euler(0f, 90f, 0f));
        }
        if (playerOne == false)
        {
            //PlayerTwo -> vector defines the spawn position on the right side
            clone2 = Instantiate(playerWorm, startPosition2, transform.rotation * Quaternion.Euler(0f, -90f, 0f));
        }
    }

    void UpdateLife()
    {
        //updates text in the canvas from player one and two
        playerOneText.text = playerOneLife.ToString();
        playerTwoText.text = playerTwoLife.ToString();
    }

    //substracts points from life count when a player is hit by a arrow
    public void PlayerSubHealthGM(bool PlayerOne)
    {
        if (PlayerOne == true)
        {
            playerOneLife -= 1;
            UpdateLife();
        }
        
        if (PlayerOne == false)
        {
            playerTwoLife -= 1;
            UpdateLife();
        }
       PlayerDiedGM(PlayerOne);
     
    }

    //add health points to the life count when player collides with the pumpkin
    public void PlayerAddHealthGM(bool PlayerOne)
    {
       if (PlayerOne == true)
        {
            playerOneLife += addPoints;
            UpdateLife();
        }
        if (PlayerOne == false)
        {
            playerTwoLife += addPoints;
            UpdateLife();
        }
    }

   //check if player died, present winner
    public void PlayerDiedGM(bool PlayerOne)
    {
        if (PlayerOne == true)  //Player 1
        {
            if (playerOneLife <= 0)
            {
                playerHasWon = "Player Two";
                PresentWinner();
            }
            
        }
        if (PlayerOne == false) //Player 2
        {
             if (playerTwoLife <= 0)
            {
                playerHasWon = "Player One";
                PresentWinner();
            }
            
        }

    }


    void PresentWinner()
    {
        //presents the winner 
        winnerText.text = playerHasWon + " is the winner. To restart the game press 'ENTER'.";
        waitForInput = true;
    }

    
    void ResetGame()
       {
           //Resets the entire game
        playerOneLife = lifeTotal;
        playerTwoLife = lifeTotal;
        UpdateLife();
        Destroy(clone1);
        Destroy(clone2);

        SpawnPlayers(true); //Zeichnet Player 1
        SpawnPlayers(false); //Zeichnet Player 2
        //transform.position = m_NewPosition;


        //&Lea Recrerate Pumpkins
    }
}