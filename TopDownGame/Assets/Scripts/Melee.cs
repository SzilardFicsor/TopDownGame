using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    private Rigidbody2D _rb;
    private SpriteRenderer _rendererShotgun;
    private BoxCollider2D _boxCollider;
    public Type MeleeType;
    // Start is called before the first frame update
    public Melee(Rigidbody2D rigidbody, SpriteRenderer renderer, BoxCollider2D collider, Type type) : base(rigidbody, renderer, collider, type)
    {
        rigidbody = _rb;
        renderer = _rendererShotgun;
        collider = _boxCollider;
        type = MeleeType;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        MeleeType = gameObject.GetType();
        _collider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_renderer.enabled == true)
        {
            IdleRotate();
        }
        if (Input.GetMouseButtonDown(1) && canThrow && Player.CurrentWeapon != null)
        {
            Throw();
            canThrow = false;
            _collider.enabled = true;
            _renderer.enabled = true;
        }
    }
    public override void Attack()
    {
        Debug.Log("Swing");

    }
}
