using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCotroller : MonoBehaviour
{
    private Vector2 _direction;
    private GameObject _player;
    private Rigidbody2D _rigidbody2D;
    public int Time;
    public GameObject box2;
    public float trans5;
    public Animation anm1;
    public Transform spawneer;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Shield());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = _player.transform.position - transform.position;
        _direction = distance.normalized;
        _rigidbody2D.AddForce(_direction);
        transform.rotation = Quaternion.Euler(x: 0, y: 0,z:GetAngle(_direction)-90);
    }
    private float GetAngle(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return angle;
    }
    IEnumerator Shield()
    {
        trans5 = Random.Range(1, 4);
        if (trans5 == 3)
        {
            box2.transform.position = spawneer.transform.position;
            box2.SetActive(true);
            anm1.Play();
            yield return new WaitForSeconds(1);
            box2.SetActive(false);
        }
    }
}
