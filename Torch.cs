using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public float minimum_light_spread;
    public float maximum_light_spread;
    public float speed;
    [SerializeField] private float lifetime;

    

    private Rigidbody2D rigidbody2D;

    bool is_burns = true;

    void Start()
    {
       
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.velocity = (transform.right + transform.up) * speed;

    }

    // Update is called once per frame
    void Update()
    {
        //ambient_light.range = Random.Range(minimum_light_spread, maximum_light_spread);
       
        Destroy(this.gameObject, lifetime);
    }
}
