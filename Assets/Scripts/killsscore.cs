using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killsscore : MonoBehaviour
{
    public GameObject boom;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(boom, collision.gameObject.transform.position, boom.transform.rotation);
            Destroy(collision.gameObject);
        }
    }
}
