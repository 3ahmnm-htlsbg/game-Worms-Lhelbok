using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    private Rigidbody player;
    private bool playerNumberOne;
    private GameManager gameManager;
     
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GetComponent<Rigidbody>();
        if (this.transform.position.x < 0)
        {
            playerNumberOne = true;
        }
    }

    void Update()
    {
        if (playerNumberOne == true)
        {
            //move the worm to the right side
            if (Input.GetKey("d") && gameManager.playerOneLife > 0 && gameManager.playerTwoLife > 0)
            {
                player.AddForce(.5f, 0f, 0f, ForceMode.Impulse);
            }

            //move the worm to the left side
            if (Input.GetKey("a") && gameManager.playerOneLife > 0 && gameManager.playerTwoLife > 0)
            {
                player.AddForce(-.5f, 0f, 0f, ForceMode.Impulse);
            }

            //let the worm jump upwards
            if (Input.GetKeyDown("w") && gameManager.playerOneLife > 0 && gameManager.playerTwoLife > 0)
            {
                PlayerJump();
            }
        }
        else
        {
            //move the worm to the right side
            if (Input.GetKey("l") && gameManager.playerOneLife > 0 && gameManager.playerTwoLife > 0)
            {
                player.AddForce(.5f, 0f, 0f, ForceMode.Impulse);
            }

            //move the worm to the left side
            if (Input.GetKey("j") && gameManager.playerOneLife > 0 && gameManager.playerTwoLife > 0)
            {
                player.AddForce(-.5f, 0f, 0f, ForceMode.Impulse);
            }

            //let the worm jump upwards
            if (Input.GetKeyDown("i") && gameManager.playerOneLife > 0 && gameManager.playerTwoLife > 0)
            {
                PlayerJump();
            }
        }
    }

    void PlayerJump()
    {
        //method to let the worm jump in direction y
        player.AddForce(0f, 8f, 0f, ForceMode.Impulse);
    }

    public void AddHealth()
    {
        gameManager.GetComponent<GameManager>().PlayerAddHealthGM(playerNumberOne);
    }

    public void SubtractHealth()
    {
        gameManager.GetComponent<GameManager>().PlayerSubHealthGM(playerNumberOne);
    }
}



