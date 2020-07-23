using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : Character
{
    protected float wait_time;
    [SerializeField] protected float start_wait_time;
    protected float next_step = 0f;
    protected float step_rite = 0.5f;
    [SerializeField] protected AudioSource walk_sound;

    [SerializeField] protected List<Transform> move_spots;

    protected int random_spot;

    protected Dictionary<string, int> char_state = new Dictionary<string, int>
    {
        {"idl", 0 },
        {"walk", 1 }
    };

    public override void Run()
    {

        transform.position = Vector3.MoveTowards(transform.position, move_spots[random_spot].position, speed * Time.deltaTime);
        State = char_state["walk"];
        if (Time.time > next_step)
        {
            next_step = Time.time + step_rite;
            walk_sound.pitch = Random.Range(0.7f, 1.1f);
            walk_sound.Play();
        }

        if (move_spots[random_spot].position.x > transform.position.x && !facing_right)
        {
            Flip();
        }

        else if (move_spots[random_spot].position.x < transform.position.x && facing_right)
        {
            Flip();
        }

        if (Vector3.Distance(transform.position, move_spots[random_spot].position) < 0.2f)
        {
            if (wait_time <= 0)
            {
                random_spot = Random.RandomRange(0, move_spots.Count);
                wait_time = start_wait_time;
            }
            else
            {
                walk_sound.Stop();
                State = char_state["idl"];
                wait_time -= Time.deltaTime;
            }
        }
    }
}
