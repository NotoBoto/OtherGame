using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyModel _enemyModel;

    public float HP;

    private void Awake()
    {
        _enemyModel = new EnemyModel();
        _enemyModel.HP = HP;
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
