using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool move_on_x;
    public bool move_on_y;
    private bool move_right = true;
    private bool move_up = true;

    public float speed;
    public float moving_from;
    public float moving_to;

    private float dirX;
    private float dirY;

    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if(move_on_x)
        {
            if(transform.position.x > moving_to)
            {
                move_right = false;
            }

            else if (transform.position.x < moving_from)
            {
                move_right = false;
            }

            if (move_right)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }

        }

        if(move_on_y)
        {
            if (transform.position.y > moving_from)
            {
                move_up = false;
            }

            else if (transform.position.y < moving_to)
            {
                move_up = true;
            }

            if (move_up)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
        }
    }
}
