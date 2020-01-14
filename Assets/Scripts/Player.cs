using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

public float ms = 6;

void FixedUpdate()
{
    if (Input.GetKey(KeyCode.LeftArrow))
    {
        transform.Translate(Vector3.left * ms * Time.deltaTime);
    }

    if (Input.GetKey(KeyCode.RightArrow))
    {
        transform.Translate(Vector3.right * ms * Time.deltaTime);
    }

    Jump();
}

void Jump()
{
    if (Input.GetButtonDown("Jump"))
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
    }
}
}
