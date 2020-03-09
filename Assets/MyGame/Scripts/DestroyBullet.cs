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
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            if (destroyedPlayer == false)
            {
                target.gameObject.GetComponent<WormController>().PlayerDied();
                destroyedPlayer = true;
            }
            Destroy(gameObject, 0);
        }
    }
}
    