using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyModel _enemyModel;

    public float HP;
    public float Speed;
    public bool CanMove;
    public bool CanFire;
    public float FireInterval;
    public int FireDirection;
    public bool CanFly;
    public bool CanSwell;
    public float SwellSize;

    public Transform _pointA;
    public Transform _pointB;

    private float _timer;
    private GameObject[] _bulletPrefab;
    private Transform _targetPoint;
    private Vector3 initialScale;
    private bool isScaling;

    private void Awake()
    {
        _enemyModel = new EnemyModel();
        _enemyModel.HP = HP;
        _enemyModel.Speed = Speed;
        _enemyModel.CanMove = CanMove;
        _enemyModel.CanFire = CanFire;
        _enemyModel.FireInterval = FireInterval;
        _enemyModel.FireDirection = FireDirection;
        _enemyModel.CanFly = CanFly;
        _enemyModel.CanSwell = CanSwell;
        _enemyModel.SwellSize = SwellSize;
        _timer = 0f;
        _bulletPrefab = Resources.LoadAll<GameObject>("Bullets");
        _targetPoint = _pointA;
        initialScale = transform.localScale;
        isScaling = false;

        if (_enemyModel.CanFly) 
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
        if(_enemyModel.CanSwell)
        {
            StartCoroutine(ScaleOverTime());
        }
    }

    private void Update()
    {
        if (_enemyModel.CanFire)
        {
            _timer += Time.deltaTime;

            if (_timer >= _enemyModel.FireInterval)
            {
                if(_enemyModel.FireDirection == 1)
                {
                    Instantiate(_bulletPrefab[0], transform.position, Quaternion.Euler(0f, 0f, 90));
                }
                else if (_enemyModel.FireDirection == 2)
                {
                    Instantiate(_bulletPrefab[0], transform.position, Quaternion.Euler(0f, 0f, -90f));
                }
                else if (_enemyModel.FireDirection == 3)
                {
                    Instantiate(_bulletPrefab[0], transform.position, Quaternion.Euler(0f, 0f, 0f));
                }
                else
                {
                    Instantiate(_bulletPrefab[0], transform.position, Quaternion.Euler(0f, 0f, -180f));
                }
                _timer = 0f;
            }
        }
        if(_enemyModel.CanMove)
        {
            Vector3 direction = (_targetPoint.position - transform.position).normalized;

            float distance = Vector3.Distance(transform.position, _targetPoint.position);

            if (distance <= 0.1f)
            {
                _targetPoint = (_targetPoint == _pointA) ? _pointB : _pointA;
            }
            else
            {
                transform.position += direction * _enemyModel.Speed * Time.deltaTime;
            }
        }
        if (_enemyModel.CanSwell)
        {
            
        }
    }

    private System.Collections.IEnumerator ScaleOverTime()
    {
        while (true)
        {
            if (!isScaling)
            {
                isScaling = true;
                yield return ScaleTo(new Vector3(_enemyModel.SwellSize, _enemyModel.SwellSize, _enemyModel.SwellSize), 2f);
                yield return ScaleTo(initialScale, 2f);
                isScaling = false;
            }
            yield return new WaitForSeconds(2f);
        }
    }

    private System.Collections.IEnumerator ScaleTo(Vector3 targetSize, float duration)
    {
        float elapsedTime = 0f;
        Vector3 initialSize = transform.localScale;

        while (elapsedTime < duration)
        {
            float progress = elapsedTime / duration;

            transform.localScale = Vector3.Lerp(initialSize, targetSize, progress);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localScale = targetSize;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            _enemyModel.HP -= collision.gameObject.GetComponent<WeaponController>().WeaponModel.Damage;
            if (_enemyModel.HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
