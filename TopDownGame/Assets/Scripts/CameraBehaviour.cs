using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private Vector2 _anchorPosition;
    
    [SerializeField] private Transform _anchorTransform;
    private Vector2 _moveToPosition;
    private Vector3 _mousePosition;
    
    private Camera _camera;
    public float _distance;
    private float _cameraMovementAmplify = 1;

    private Vector3 _followPlayerPoint;
    private Vector3 _lookAheadpoint;
    private float _elapsedTime;

    void Start()
    {
        _camera= GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        _elapsedTime = Time.fixedDeltaTime;
        float percentage = _elapsedTime / 0.25f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = Vector3.Lerp(transform.position, LookAhead(), percentage);
        }
        else
        {            
            float returnPercentage;
            if (transform.position != FollowPlayer())
            {
                returnPercentage = _elapsedTime / 0.10f;
            }
            else
            {
                returnPercentage = 1;
            }

            transform.position = Vector3.Lerp(transform.position, FollowPlayer(), returnPercentage);
        }
    }
    private Vector3 FollowPlayer()
    {
        _followPlayerPoint = new Vector3(_anchorTransform.position.x, _anchorTransform.position.y, transform.position.z);
        return _followPlayerPoint;
    }
    private Vector3 LookAhead()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _moveToPosition = new Vector2(_anchorTransform.position.x + _mousePosition.x / 2, _anchorTransform.position.y + _mousePosition.y / 2);
        _lookAheadpoint = Vector3.Lerp(_anchorTransform.position, new Vector3(_moveToPosition.x, _moveToPosition.y, transform.position.z) - new Vector3(transform.position.x/ 2 , transform.position.y /2 , 0), _cameraMovementAmplify);
        return _lookAheadpoint;
    }
}
