using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void PickUp()
    {
        SpriteRenderer renderer;
        renderer = GetComponent<SpriteRenderer>();
        renderer.enabled= false;


    }

    public virtual void Attack()
    {

    }

    public void Throw()
    {

    }

}
