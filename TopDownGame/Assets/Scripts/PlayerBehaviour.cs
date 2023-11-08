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
    void Start()
    {
        _rb= GetComponent<Rigidbody2D>();
        _camera= Camera.main;
    }

    void Update()
    {
        ProcessInputs();
       
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

        _moveDirection= new Vector2(inputX, inputY).normalized;

        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _lookDirection = _mousePosition - transform.position;
    }
    private void Move()
    {
        _rb.velocity = new Vector2(_moveDirection.x,_moveDirection.y) * _movementSpeed;
    }
    private void Rotate()
    {
        float angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
        angle -= 90; // Correction degrees
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
