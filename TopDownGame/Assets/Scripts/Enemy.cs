using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer _renderer;
    [SerializeField] private Sprite _deadSprite;
    private CircleCollider2D _collider;
    private PlayerBehaviour _player;
    private Rigidbody2D _rb;
    private bool _dead = false;
    private Vector2 _distance;
    // Start is called before the first frame update
    void Start()
    {
        _renderer= GetComponentInChildren<SpriteRenderer>();
        _collider= GetComponent<CircleCollider2D>();
        _rb = GetComponentInChildren<Rigidbody2D>();
        _player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_dead)
        {
            Vector2 direction = _player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;
            _rb.rotation = angle;
        }
        _distance = _player.transform.position - transform.position;
        float length = _distance.magnitude;
        if(length < 2 && Input.GetMouseButton(0) && _player._hasMelee)
        {
            Death();
        }

    }
    public void Death()
    {
        _renderer.sprite = _deadSprite;
        _collider.enabled= false;
        _dead = true;
        _rb.rotation += 180;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Weapon" || collision.tag == "Melee")
        {
            Death();
        }
    }
}
