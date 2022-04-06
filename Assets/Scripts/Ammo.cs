using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D; // компонента Rigidbody2D прикріплена до снаряду
    [SerializeField] private float _speed = 3; // швидкість снаряду
    PlayerController _playerController;
    public GameObject boom;
    public Animation anm1;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void SetPlayerController(PlayerController player)
    {
        _playerController = player;
    }
    public void SetVelocity(Vector3 direction) // задаємо швидкість снаряду
    {
        _rigidbody2D.velocity = direction * _speed;
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(2);
        _playerController.ReturnAmmo(this);
    }

    public void SetPosition(Vector3 position) // задаємо координати точки вильоту
    {
        transform.position = position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(boom, collision.gameObject.transform.position, boom.transform.rotation);
            anm1.Play();
            Destroy(collision.gameObject);
            staticcs.kills ++;
            _playerController.ReturnAmmo(this);
        }
    }
}
