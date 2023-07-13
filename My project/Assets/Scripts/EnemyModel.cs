using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    private float _HP;
    public float HP
    {
        get { return _HP; }
        set { _HP = value; }
    }

    private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private bool _canMove;
    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    private bool _canFire;
    public bool CanFire
    {
        get { return _canFire; }
        set { _canFire = value; }
    }

    private float _fireInterval;
    public float FireInterval
    {
        get { return _fireInterval; }
        set { _fireInterval = value; }
    }
    private int _fireDirection;
    public int FireDirection
    {
        get { return _fireDirection; }
        set { _fireDirection = value; }
    }
    private bool _canFly;
    public bool CanFly
    {
        get { return _canFly; }
        set { _canFly = value; }
    }

    private bool _canSwell;
    public bool CanSwell
    {
        get { return _canSwell; }
        set { _canSwell = value; }
    }
    private float _swellSize;
    public float SwellSize
    {
        get { return _swellSize; }
        set { _swellSize = value; }
    }
}
