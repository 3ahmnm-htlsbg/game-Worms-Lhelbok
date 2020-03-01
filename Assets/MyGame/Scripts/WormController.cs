using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    public float thrust = 1.0f;
    public GameObject spawnPoint;
    public Rigidbody player;
    public Rigidbody bullet;
    public GameObject bazuca;

    /*void Start()
    {

    }*/

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            player.AddForce(-5, 0, thrust, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            player.AddForce(5, 0, thrust, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            player.AddForce(0, 5, thrust, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            player.AddForce(0, -5, thrust, ForceMode.Impulse);
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody hitPlayer;
            hitPlayer = Instantiate(bullet, spawnPoint.transform.position, transform.rotation) as Rigidbody;
            hitPlayer.AddForce(10, 0, thrust, ForceMode.Impulse);
        }*/

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            bazuca.transform.Rotate(2, 0, 20);
        }*/
    }

}

