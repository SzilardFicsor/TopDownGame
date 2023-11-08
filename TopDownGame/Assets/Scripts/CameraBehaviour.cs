using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private Vector2 _anchorPosition;
    
    [SerializeField] private Transform _anchorTransform;
    private Vector2 _moveToPosition;
    private Vector2 _mousePosition;
    private Camera _camera;
    public float _distance;
    void Start()
    {
        _camera= GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _moveToPosition = new Vector2(_anchorPosition.x + _mousePosition.x / 2, _anchorPosition.y + _mousePosition.y / 2);
        transform.position = Vector3.Lerp(transform.position, new Vector3(_moveToPosition.x, _moveToPosition.y, transform.position.z), 100);
        Debug.Log(_moveToPosition);
    }
    private void FollowPlayer()
    {
        transform.position = new Vector3(_anchorTransform.position.x, _anchorTransform.position.y, transform.position.z);
    }
}
