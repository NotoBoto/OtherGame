using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel
{
    private float _damage;
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    private bool _isUsed;
    public bool IsUsed
    {
        get { return _isUsed; }
        set { _isUsed = value; }
    }
}
