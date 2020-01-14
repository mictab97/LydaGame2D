using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector3 touchOrigin;
    private Vector3 touchOffset;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            timer = 0f;
            touchStart = true;
            touchOrigin = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0));
            touchOffset = player.position - touchOrigin;

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
            player.position = touchOrigin + touchOffset;

            //Input.mousePosition.y,
        }
        else
        {
            touchStart = false;
            if (timer <= 0.1f)
            {
                // jump
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

    void moveCharacter(Vector2 direction)
    {
        // player.Translate(direction * speed * Time.deltaTime);
    }
}
