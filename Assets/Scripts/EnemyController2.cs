using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    private Vector2 _direction;
    private GameObject _player;
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = _player.transform.position - transform.position;
        _direction = distance.normalized;
        _rigidbody2D.velocity = new Vector2(x:-_direction.y, y: _direction.x)*3;
        transform.rotation = Quaternion.Euler(x: 0, y: 0, z: GetAngle(_direction) + 90);
    }
    private float GetAngle(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return angle;
    }
}
