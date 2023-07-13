using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private BulletModel _bulletModel;

    public float Speed;
    public float Lifetime;
    private float _timer;
    private void Awake()
    {
        _bulletModel = new BulletModel();
        _bulletModel.Speed = Speed;
        _bulletModel.LifeTime = Lifetime;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer <= _bulletModel.LifeTime)
        {
            transform.Translate(Vector2.up * _bulletModel.Speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
