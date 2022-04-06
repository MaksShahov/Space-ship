using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction; // напрямок руху гравця
    private float _maxForce = 4; // максимальне значення сили
    private Vector3 _lookDirection; // напрямок на курсор мишки
    [SerializeField] private Ammo ammoPrefab; // префаб снаряду
    public GameObject mine; // префаб снаряду
    [SerializeField] private Transform shootPoint; // точка вильоту снаряду
    private Queue<Ammo> _magazine; // сховище снарядів
    private int _magazineCapacity = 20; // ємність сховища снарядів
    public AudioSource ad;
    public AudioSource ad1;
    public GameObject minee;
    [SerializeField]
    private LineRenderer laserShot;
    public Slider sliderhp;
    public Text txtkills;
    public Text txttime;
    public int time = 60;
    public GameObject oboron;
    public Animation anm1;
    public GameObject box;
    public GameObject player;
    public GameObject lineline;
    public GameObject boom;
    void Start()
    {
        StartCoroutine(Times());
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _magazine = new Queue<Ammo>(); // сховище снарядів - черга
        for (int i = 0; i < _magazineCapacity; i++)
        { // заповнюємо сховище снарядами
          // створюємо снаряд
            var ammo = Instantiate(ammoPrefab, Vector3.zero, Quaternion.identity);
            ammo.gameObject.SetActive(false); // деактивуємо снаряд
            ammo.SetPlayerController(this);
            _magazine.Enqueue(ammo);
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // одиничний вектор в нарямку руху гравця
        _direction = new Vector2(horizontal, vertical).normalized;
        // матриця повороту гравця до вказівника мишки
        transform.rotation = Quaternion.Euler(0, 0, GetAngle() - 90);
        if (Input.GetButtonDown("Fire1"))
        {
            if (_magazine.Count > 0)
            {
                Shoot();
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
                LaserShoot();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (staticcs.bombs > 0)
            {
                MineShoot();
            }
        }
        if (Input.GetButtonDown("Horizontal")){
            ad.Play();

        }
        if (Input.GetButtonDown("Vertical")){
            ad.Play();
        }
        sliderhp.value = staticcs.hp;
        txtkills.text = "Kills: " + staticcs.kills;
        txttime.text = "Time: " + time;
    }

private void Shoot()
    {
        var ammo = _magazine.Dequeue(); // витягуємо снаряд зі сховища
        ammo.gameObject.SetActive(true); // активуємо снаряд
                                         // задаємо точку вильоту
        ad1.Play();
        ammo.GetComponent<Ammo>().SetPosition(shootPoint.position);
        // задаємо швидкість снаряду
        ammo.GetComponent<Ammo>().SetVelocity(_lookDirection);
    }
    private void MineShoot()
    {
        Instantiate(boom, mine.transform.position, boom.transform.rotation);
        Instantiate(minee, mine.transform.position, boom.transform.rotation);
        StartCoroutine(Minee());
    }
    private void LaserShoot()
    {
        laserShot.SetPosition(0, shootPoint.position);
        var point = new Vector3(_lookDirection.x, _lookDirection.y, 0);
            var raycastHit = Physics2D.Raycast(shootPoint.position, point);
            if (raycastHit)
            {
                if (raycastHit.collider.gameObject.CompareTag("Enemy"))
                {
                Instantiate(boom, raycastHit.collider.gameObject.transform.position, boom.transform.rotation);
                Destroy(raycastHit.collider.gameObject);
                }
            }
        laserShot.SetPosition(1, _lookDirection*150);
        StartCoroutine(LaserShotEnable());
    }
    private IEnumerator LaserShotEnable ()
    {
        laserShot.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        laserShot.gameObject.SetActive(false);
    }
    public void ReturnAmmo(Ammo ammo)
    {
        ammo.gameObject.SetActive(false);
        _magazine.Enqueue(ammo);
    }

    private void FixedUpdate()
    {
        // задаємо імпульсну силу, що діє на гравця
        _rigidbody2D.AddForce(_direction * _maxForce * Time.fixedDeltaTime,
        ForceMode2D.Impulse);
    }

private float GetAngle()
    {
        // координати кінця вказівника мишки
        Vector3 mousePosition =
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // одиничний вектор від гравця до кінця вказівника мишки
        _lookDirection = (mousePosition - transform.position).normalized;
        // кут між напрямком _lookDirection та віссю X
        float angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) *

        Mathf.Rad2Deg;

        return angle;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            staticcs.hp -=25;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            Destroy(collision.gameObject);
            StartCoroutine(Shield());
        }
        if (collision.gameObject.tag == "bombe")
        {
            Destroy(collision.gameObject);
            staticcs.bombs++;
        }
    }
    public IEnumerator Times()
    {
        time--;
        staticcs.timee = time;
        yield return new WaitForSeconds(1);
        StartCoroutine(Times());
    }
    public IEnumerator Minee()
    {
        staticcs.bombs--;
        mine.SetActive(true);
        yield return new WaitForSeconds(1);
        mine.SetActive(false);
    }
    public IEnumerator Shield()
    {
        box.SetActive(true);
        anm1.Play();
        yield return new WaitForSeconds(2);
        box.SetActive(false);
    }
}
