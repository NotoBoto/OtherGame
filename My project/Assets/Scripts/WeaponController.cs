using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponModel WeaponModel;
    private PlayerController _player;

    public float Damage;
    public bool ISUsed;
    private void Awake()
    {
        WeaponModel = new WeaponModel();

        _player = FindAnyObjectByType<PlayerController>();

        WeaponModel.Damage = Damage;
        WeaponModel.IsUsed = ISUsed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!ISUsed && !_player.PlayerModel.HasWeapon)
            {
                transform.parent = _player.transform;
                _player.PlayerModel.HasWeapon = true;
                WeaponModel.IsUsed = true;
                _player.PlayerSword = gameObject;
                transform.SetLocalPositionAndRotation(new Vector3(0.2f, 0.2f, 0f), Quaternion.Euler(0f, 0f, 95f));
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
