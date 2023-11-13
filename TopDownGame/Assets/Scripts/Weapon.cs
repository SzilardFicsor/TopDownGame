using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public PlayerBehaviour Player;
    public Rigidbody2D rb;
    private SpriteRenderer _renderer;
    private bool canThrow = false;
    private BoxCollider2D _collider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _collider= GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (_renderer.enabled == true)
        {
            IdleRotate();
        }
        if (Input.GetMouseButtonDown(1) && canThrow && Player.CurrentWeapon != null)
        {
            Throw();
            canThrow= false;
            _collider.enabled = true;
            _renderer.enabled = true;
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player = collision.gameObject.GetComponent<PlayerBehaviour>();
            if (Input.GetMouseButton(1))
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
        if (collision.gameObject.tag == "Wall")
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void IdleRotate()
    {
        if (rb.velocity == Vector2.zero)
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

    }
    private void PickUp()
    {
        if (Player.CurrentWeapon == null)
        {
            Player.CurrentWeapon = this.gameObject;
            Debug.Log("PICKUP");
        }
    }
}
