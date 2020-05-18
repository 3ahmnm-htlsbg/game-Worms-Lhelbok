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
        player.AddForce(0f, 5.25f, 0f, ForceMode.Impulse);
    }

    void OnTriggerStay(Collider target)
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
            //get the GameManager
            gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().PlayerDiedGM(playerNumberOne);
            Destroy(gameObject);
        }
    }

    public void AddHealth()
    {
        //get the GameManager
        gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<GameManager>().PlayerAddHealthGM(playerNumberOne);
    }
}



