using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    bool destroyedPlayer = false;

    void Update()
    {
        //destroy arrow after 1 second when the arrow doesnt hit the other player
        Destroy(gameObject, 1);
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Player")
        {
            target.gameObject.GetComponent<WormController>().SubtractHealth();
            //destroy arrow after colliding with the player
            Destroy(gameObject);
        }
    }
}
    