using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    private Rigidbody player;
    public bool playerJumpBool;
    private bool playerNumberOne;
    private GameObject gameManager;

    private bool hasSpawnProt;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
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
            if (Input.GetKey("d"))
            {
                player.AddForce(.5f, 0f, 0f, ForceMode.Impulse);
            }

            //move the worm to the left side
            if (Input.GetKey("a"))
            {
                player.AddForce(-.5f, 0f, 0f, ForceMode.Impulse);
            }

            //let the worm jump upwards
            if (Input.GetKeyDown("w") && playerJumpBool == true)
            {
                PlayerJump();
                playerJumpBool = false;
            }
        }
        else
        {
            //move the worm to the right side
            if (Input.GetKey("l"))
            {
                player.AddForce(.5f, 0f, 0f, ForceMode.Impulse);
            }

            //move the worm to the left side
            if (Input.GetKey("j"))
            {
                player.AddForce(-.5f, 0f, 0f, ForceMode.Impulse);
            }

            //let the worm jump upwards
            if (Input.GetKeyDown("i") && playerJumpBool == true)
            {
                PlayerJump();
                playerJumpBool = false;
            }
        }
    }

    void PlayerJump()
    {
        //method to let the worm jump in direction y
        player.AddForce(0f, 8f, 0f, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "SceneItems")
        {
            playerJumpBool = true;
        }
    }

    public void PlayerDied()
    {
        if (!hasSpawnProt)
        {
            gameManager.GetComponent<GameManager>().PlayerDiedGM(playerNumberOne);
            Destroy(gameObject);
        }
    }

    public void AddHealth()
    {
        gameManager.GetComponent<GameManager>().PlayerAddHealthGM(playerNumberOne);
    }

    public void SubtractHealth()
    {
        gameManager.GetComponent<GameManager>().PlayerSubHealthGM(playerNumberOne);
        Debug.Log("SubtractHealth called");
    }
}



