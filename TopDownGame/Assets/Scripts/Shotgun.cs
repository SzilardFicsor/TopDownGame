using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public PlayerBehaviour Player;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
           
    }
    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player = collision.gameObject.GetComponent<PlayerBehaviour>();
            if(Player.CurrentWeapon ==null)
            {
                PickUp();
                transform.SetParent(Player.WeaponPosition);

                
            }                   
        }
    }
}
