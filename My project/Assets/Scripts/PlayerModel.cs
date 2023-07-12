using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private float _jumpForce;
    public float JumpForce
    {
        get { return _jumpForce; }
        set { _jumpForce = value; }
    }

    private float _score;
    public float Score
    {
        get { return _score; }
        set { _score = value; }
    }

    private bool _hasWeapon;
    public bool HasWeapon
    {
        get { return _hasWeapon; }
        set { _hasWeapon = value; }
    }

    private bool _isUsingWeapon;
    public bool IsUsingWeapon
    {
        get { return _isUsingWeapon; }
        set { _isUsingWeapon = value; }
    }
}
