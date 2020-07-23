using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dampTime = 0.15f;

    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;


    private int last_x;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(new Vector3(player.position.x, player.position.y + 0.4f, player.position.z));
            Vector3 delta = new Vector3(player.position.x, player.position.y + 0.4f, player.position.z) - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;

            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
