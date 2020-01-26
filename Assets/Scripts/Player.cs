using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text countText;
    public Text skullText;

    public float ms = 6;
    private int count;

    void Start() 
    {
        count = 0;
        SetCountText ();
    }

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count +1;
            SetCountText ();
        }

        else if (other.gameObject.CompareTag ("Skull"))
        {
            other.gameObject.SetActive (false);
            count = count +1;
            SetSkullText ();
        }
    }

    void SetSkullText ()
    {
        skullText.text = "damage:" + count.ToString ();
    }

    void SetCountText ()
    {
        countText.text = "bug coin:" + count.ToString ();
    }
}
