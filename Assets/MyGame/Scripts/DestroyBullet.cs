using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    bool destroyedPlayer = false;

    void Update()
    {
        Destroy(gameObject, 1);
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Player")
        {
            target.gameObject.GetComponent<WormController>().SubtractHealth();
            Destroy(gameObject);
        }
    }
}
    