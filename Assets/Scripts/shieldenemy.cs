using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldenemy : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
