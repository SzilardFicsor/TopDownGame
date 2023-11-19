using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _movementSpeed;
    private Vector2 _moveDirection;
    private Vector3 _mousePosition;
    private Vector2 _lookDirection;
    private Camera _camera;
    private bool _hasGun = false;
    public bool _hasMelee = false;
    public bool ShootOnce = false;
    public bool SwingOnce = false;
    public GameObject CurrentWeapon;
    public Transform WeaponPosition;

    private float _throwForce = 20;
    //private bool _hasWeapon = false;
    //public SpriteRenderer WeaponRenderer;

    private Animator _animator;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _camera = Camera.main;
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessInputs();
        AnimationHandeler();
        if (CurrentWeapon != null)
        {
            CurrentWeapon.gameObject.transform.position = WeaponPosition.transform.position;
            CurrentWeapon.gameObject.transform.rotation = WeaponPosition.transform.rotation;
            if(CurrentWeapon.tag == "Weapon")
            {
                _hasGun = true;
            }
            if(CurrentWeapon.tag == "Melee")
            {
                _hasMelee = true;
            }
        }
        else
        {
            _hasGun = false;
            _hasMelee= false;
        }
        if(Input.GetMouseButtonDown(0) && CurrentWeapon != null && CurrentWeapon.tag == "Weapon")
        {
            CurrentWeapon.GetComponent<Weapon>().Attack();
            ShootOnce= true;
        }

        if (Input.GetMouseButtonDown(0) && CurrentWeapon != null && CurrentWeapon.tag == "Melee")
        {
            CurrentWeapon.GetComponent<Weapon>().Attack();
            SwingOnce = true;
        }

    }
    private void FixedUpdate()
    {
        Move();
        Rotate();
    }
    private void ProcessInputs()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector2(inputX, inputY).normalized;

        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _lookDirection = _mousePosition - transform.position;
    }
    public void ThrowWeapon()
    {

        Vector2 direction = WeaponPosition.position - transform.position;
        direction = direction.normalized;

        CurrentWeapon.GetComponent<Weapon>().rb.AddForce(direction * _throwForce, ForceMode2D.Impulse);
        Debug.Log("THROW");
        CurrentWeapon = null;
        ShootOnce = false;
        SwingOnce= false;

    }
    private void Move()
    {
        _rb.velocity = new Vector2(_moveDirection.x, _moveDirection.y) * _movementSpeed;
    }
    private void Rotate()
    {
        float angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
        angle -= 90; // Correction degrees
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    private void AnimationHandeler()
    {
        if (_rb.velocity != Vector2.zero)
        {
            _animator.SetBool("Walk", true);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }


        if (!_hasGun)
        {
            _animator.SetBool("IsHoldingGun", false);
        }
        else if (_hasGun)
        {
            _animator.SetBool("IsHoldingGun", true);
        }

        if (!_hasMelee)
        {
            _animator.SetBool("IsHoldingMelee", false);
        }
        else if (_hasMelee)
        {
            _animator.SetBool("IsHoldingMelee", true);
        }

        if (ShootOnce)
        {
            _animator.SetBool("ShootOnce", true);
        }
        if (!ShootOnce)
        {
            _animator.SetBool("ShootOnce", false);
        }

        if (SwingOnce)
        {
            _animator.SetBool("SwingOnce", true);
        }
        if (!SwingOnce)
        {
            _animator.SetBool("SwingOnce", false);
        }
    }
}
