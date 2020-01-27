using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    [SerializeField]
    private Player _player;

    //private Animator _animator;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        //_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // move down at 4m/s
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // if position on Y is less than -6
        // Y position = 8
        // X position = random between -8 and 8
        if (transform.position.y < -6)
        {
            float x = Random.Range(-8f, 8f);
            transform.position = new Vector3(x, 8, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if the other is the player
        // damage the player
        // destroy us
        if (other.tag == "Player")
        {
            // Get the player script from the Player object
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }

            OnEnemyDeath();
        }

        // if the other is a laser
        // destroy the laser
        // destroy us
        //if (other.tag == "Laser")
        //{
            // add a point to the player's score
        //    _player.AddScore();
         //   Destroy(other.gameObject);
         //   OnEnemyDeath();
        //}
    }

    void OnEnemyDeath()
    {
        //_animator.SetTrigger("OnEnemyDeath");
        _speed = 0;

        Destroy(this.gameObject, 2.633f);
    }
}
