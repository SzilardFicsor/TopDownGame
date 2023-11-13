using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public PlayerBehaviour Player;
    public Rigidbody2D rb;
    private SpriteRenderer _renderer;
    private bool _weaponOnGround = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (_renderer.enabled == true)
        {
            IdleRotate();
        }
        if(Input.GetMouseButtonDown(1) && !_weaponOnGround)
        {
            Throw();
            _weaponOnGround= true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player = collision.gameObject.GetComponent<PlayerBehaviour>();
            if (Input.GetMouseButton(1) && _weaponOnGround)
            {
                if (Player.CurrentWeapon == null)
                {
                    Player.CurrentWeapon = this.gameObject;
                    Debug.Log("PICKUP");
                    _weaponOnGround = false;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //rb.velocity = Vector3.zero;
        if(collision.gameObject.tag != "Player")
        {
            rb.velocity = Vector3.zero;
        }
        Debug.Log("HIT");
    }

    private void IdleRotate()
    {
        if(rb.velocity == Vector2.zero)
        {
            transform.Rotate(0, 0, 50 * Time.deltaTime);
        }
        else if (rb.velocity != Vector2.zero)
        {
            transform.Rotate(0, 0, 500 * Time.deltaTime);
        }
    }
    private void Throw()
    {
        Player.ThrowWeapon();
        _weaponOnGround = true;
    }
}
