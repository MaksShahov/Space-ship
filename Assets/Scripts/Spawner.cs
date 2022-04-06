using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawner;
    public GameObject box;
    public float Timespawni;
    public Vector3 spawneer;
    public Transform Spawnpos;
    public float trans;
    public float trans3;
    public AudioSource aud;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnCD());
    }
    void Repeat()
    {

        StartCoroutine(SpawnCD());
    }
    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(Timespawni);
        trans = Random.Range(-10, 11);
        spawneer = new Vector3(trans, trans3, Spawnpos.position.y);
        Instantiate(box, Spawnpos.position, Quaternion.identity);
        Repeat();
    }
}
