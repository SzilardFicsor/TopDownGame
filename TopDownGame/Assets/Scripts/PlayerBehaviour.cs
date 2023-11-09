using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

    private Animator _animator;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _camera = Camera.main;
    }

    void Update()
    {
        ProcessInputs();
        AnimationHandeler();
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


        if (Input.GetMouseButtonDown(1) && !_hasGun)
        {
            _animator.SetBool("IsHoldingGun", true);
            _hasGun = true;
        }
        else if (Input.GetMouseButtonDown(1) && _hasGun)
        {
            _animator.SetBool("IsHoldingGun", false);
            _hasGun = false;
        }
    }
}
