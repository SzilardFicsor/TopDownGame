using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private Vector2 _mousePosition;
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = _mousePosition;
    }
}
