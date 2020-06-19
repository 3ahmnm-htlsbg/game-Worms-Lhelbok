using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    bool destroyedPlayer = false;

    void Update()
    {
        Destroy(gameObject, 4);
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Player")
        {
            /*
            if (destroyedPlayer == false)
            {
                target.gameObject.GetComponent<WormController>().PlayerDied();
                destroyedPlayer = true;
            }
            */
            target.gameObject.GetComponent<WormController>().SubtractHealth();
            Destroy(gameObject);
        }
    }
}
    