using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    [SerializeField] 
    private bool m_AirControl = true;
    
    [SerializeField]
    private Transform _groundCheck;

    [SerializeField]
    private int _jumpMax = 2;

    private int _currentJump = 0;

    public float velocity = 1;
    private Rigidbody2D rb;
    public bool isOnGround;
    public bool finalPhase = false;


    public Player player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector3 touchOrigin;
    private Vector3 touchOffset;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            timer = 0f;
            touchStart = true;
            touchOrigin = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0));
            touchOffset = player.transform.position - touchOrigin;

            //Input.mousePosition.y,
        }
        else if(Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
            if (timer <= 0.1f)
            {
                return;
            }
            touchOrigin = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0));
            Vector3 positionDrag = new Vector3(touchOrigin.x + touchOffset.x, player.transform.position.y);
            player.SetPosition(positionDrag);

            //Input.mousePosition.y,
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touchStart = false;
            if (timer <= 0.1f)
            {
                //jump
                player.Jump();
            }
        }


    }

    private void FixedUpdate() {
        // if(touchStart)
        // {
        //     Vector2 offset = pointB - pointA;
        //     Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
        //     moveCharacter(direction * 1);
        // }
    }

   // private void OnTriggerEnter2D(Collider2D collision)
    //{
     //   if (collision.tag == "GameOver")
    //    {
    //        gameManager.GameOver();
     //   }
    //}

    void moveCharacter(Vector2 direction)
    {
        // player.Translate(direction * speed * Time.deltaTime);
    }
}
