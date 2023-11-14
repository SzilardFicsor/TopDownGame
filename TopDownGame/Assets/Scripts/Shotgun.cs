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
    
    public Shotgun(Rigidbody2D rigidbody, SpriteRenderer renderer, BoxCollider2D collider): base(rigidbody, renderer, collider)
    {
        rigidbody = _rb;
        renderer = _rendererShotgun;
        collider = _boxCollider;
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
        base.Attack();
    }
}
