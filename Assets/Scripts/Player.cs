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

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 6f;
    }
}
