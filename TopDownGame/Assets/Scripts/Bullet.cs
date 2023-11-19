using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Vector2 Direction;
    private float _shootForce = 100;
    private void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Direction.x,Direction.y) * _shootForce;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Death();
        }
    }
}
