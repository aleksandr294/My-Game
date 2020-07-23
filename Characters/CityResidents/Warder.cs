using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warder : NPC
{
    
    // Start is called before the first frame update
    void Start()
    {
        wait_time = start_wait_time;
        random_spot = Random.RandomRange(0, move_spots.Count);

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }
}
