using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private Vector2 _anchorPosition;
    
    [SerializeField] private Transform _anchorTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //_anchorPosition = new Vector2(_anchorTransform.position.x,_anchorTransform.position.y);
        //transform.position =_anchorPosition;

        transform.position = new Vector3(_anchorTransform.position.x,_anchorTransform.position.y,transform.position.z);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(_anchorTransform.position.x, _anchorTransform.position.y, transform.position.z), 5);
    }
}
