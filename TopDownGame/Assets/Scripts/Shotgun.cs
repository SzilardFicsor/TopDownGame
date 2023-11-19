using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shotgun : Weapon
{
    // Start is called before the first frame update
    private Rigidbody2D _rb;
    private SpriteRenderer _rendererShotgun;
    private BoxCollider2D _boxCollider;
    public Transform Barrel;
    public Transform Barrel2;
    public Transform Barrel3;
    public Bullet Bullet;
    public Type Guntype;

    private void Awake()
    {
        Guntype = gameObject.GetType();
    }
    public Shotgun(Rigidbody2D rigidbody, SpriteRenderer renderer, BoxCollider2D collider, Type type): base(rigidbody, renderer, collider, type)
    {
        rigidbody = _rb;
        renderer = _rendererShotgun;
        collider = _boxCollider;
        type = WeaponType;
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
        Bullet bullet =Instantiate(Bullet, Barrel.position, transform.rotation);
        bullet.Direction = bullet.transform.position - transform.position;
        Bullet bullet2 = Instantiate(Bullet, Barrel.position, transform.rotation);
        bullet2.Direction = Barrel2.transform.position - transform.position;
        Bullet bullet3 = Instantiate(Bullet, Barrel.position, transform.rotation);
        bullet3.Direction = Barrel3.transform.position - transform.position;
    }
}
