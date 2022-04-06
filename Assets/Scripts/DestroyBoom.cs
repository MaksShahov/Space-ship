using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroye());
    }
    public IEnumerator Destroye()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
