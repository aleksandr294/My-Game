using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private Transform camera_transform;
    private Transform[] layers;

    public float background_size;
    [SerializeField] private float view_zone = 10.0f;
    public float paralax_speed;
    private float last_camera_x;

    private int left_index;
    private int right_index;

    public bool scroling;
    public bool paralax;

    void Start()
    {
        camera_transform = Camera.main.transform;
        layers = new Transform[transform.childCount];
        last_camera_x = camera_transform.position.x;

        for(int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        left_index = 0;
        right_index = layers.Length - 1;
    }

    void Update()
    {   if (paralax)
        {
            float delta_x = camera_transform.position.x - last_camera_x;
            transform.position += Vector3.right * (delta_x * paralax_speed);
        }

        last_camera_x = camera_transform.position.x;

        if (scroling)
        {
            if (camera_transform.position.x < (layers[left_index].transform.position.x + view_zone))
            {
                scroll_left();
            }

            if (camera_transform.position.x > (layers[right_index].transform.position.x - view_zone))
            {
                scroll_right();
            }
        }
    }

    private void scroll_left()
    {
        int last_right = right_index;
        layers[right_index].position = Vector3.right * (layers[left_index].position.x - background_size);
        left_index = right_index;
        right_index--;

        if (right_index < 0)
        {
            right_index = layers.Length - 1;
        }
    }

    private void scroll_right()
    {
        int last_left = left_index;
        layers[left_index].position = Vector3.right * (layers[right_index].position.x + background_size);
        right_index = left_index;
        left_index++;

        if (left_index == layers.Length)
        {
            left_index = 0;
        }
    }

    
}
