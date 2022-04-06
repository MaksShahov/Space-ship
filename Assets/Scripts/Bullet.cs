using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject boom;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
            StartCoroutine(Fff());
        }
    }
    public IEnumerator Fff()
    {
        boom.SetActive(true);
        yield return new WaitForSeconds(1);
        boom.SetActive(false);
    }
}
