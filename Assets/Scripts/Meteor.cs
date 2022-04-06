using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject spawner;
    public GameObject box;
    public float Timespawni;
    public Transform Spawnpos;
    public int trans1;
    public Vector3 spawneer;
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
        trans1 = Random.Range(-10, 11);
        Instantiate(box, Spawnpos.position, Quaternion.identity);
        spawneer = new Vector3(trans1, Spawnpos.position.y, Spawnpos.position.z);
        Spawnpos.position = spawneer;
        Repeat();
    }
}
