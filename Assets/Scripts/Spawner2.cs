using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject spawner;
    public ParticleSystem par1;
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
        trans3 = Random.Range(-4, 5);
        Instantiate(box, Spawnpos.position, Quaternion.identity);
        spawneer = new Vector3(trans, trans3, Spawnpos.position.y);
        Spawnpos.position = spawneer;
        Repeat();
    }
}
