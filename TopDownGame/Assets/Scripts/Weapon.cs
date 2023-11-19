using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public PlayerBehaviour Player { get; set; }
    public Rigidbody2D rb { get; set; }
    public SpriteRenderer _renderer { get; set; }
    public bool canThrow { get; set; }
    public BoxCollider2D _collider { get; set; }
    public Type WeaponType { get; set; }

    public Weapon(Rigidbody2D rigidbody, SpriteRenderer renderer, BoxCollider2D collider, Type type)
    {
        rb = rigidbody;
        _renderer = renderer;
        _collider = collider;
        WeaponType = type;

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player = collision.gameObject.GetComponent<PlayerBehaviour>();
            if (Input.GetMouseButton(1) && Player.CurrentWeapon == null)
            {
                PickUp();
                _collider.enabled= false;
                _renderer.enabled = false;
                canThrow = true;

            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //rb.velocity = Vector3.zero;
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void IdleRotate()
    {
        if (rb.velocity == Vector2.zero)
        {
            transform.Rotate(0, 0, 50 * Time.deltaTime);
            
        }
        else if (rb.velocity != Vector2.zero)
        {
            transform.Rotate(0, 0, 700 * Time.deltaTime);
        }
    }
    public void Throw()
    {
        Player.ThrowWeapon();

    }
    private void PickUp()
    {
        if (Player.CurrentWeapon == null)
        {
            Player.CurrentWeapon = this.gameObject;
            Debug.Log("PICKUP");
        }
    }
    public virtual void Attack()
    {

    }
}
