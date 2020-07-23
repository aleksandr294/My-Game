using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Enemy
{
    public GameObject health_bar;
    //private float next_step = 0f;
    //private float step_rite = 0.6f;
    //public AudioSource walk_sound;


    private void Awake()
    {
        EventAggregator.kick_event.Subscribe(TakeDamage);
    }

    void Start()
    {
        wait_time = start_wait_time;
        random_spot = Random.RandomRange(0, move_spots.Count);

        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        char_state.Add("dead", 2);
        char_state.Add("attack", 3);
        char_state.Add("hurt", 4);
        char_state.Add("recover", 5);


    }

    // Update is calld once per frame
    void Update()
    {
        if (health <= 0)
        {
            angry = false;
            attack = false;
            run = false;
            Invoke("Dead", 0.1f);
        }

        if (Vector3.Distance(transform.position, player.position) < stopping_distance)
        {
            //State = char_state["walk"];
            //Angry();
            angry = true;
            run = false;
            attack = false;
        }

        if (Vector3.Distance(transform.position, player.position) > stopping_distance)
        {
            //Run();
            run = true;
            angry = false;
            attack = false;
        }

        if (Vector3.Distance(transform.position, player.position) < 0.4f)
        {
            //State = char_state["attack"];
            //Attack();
            attack = true;
            angry = false;
            run = false;
        }

        if (angry)
        {
            health_bar.SetActive(true);
            Angry();
            //Debug.Log("angry");
        }

        else if (run)
        {
            Run();
            //Debug.Log("run");
        }

        else if (attack)
        {
            Attack();
        }

    }

    private void TakeDamage(Collider2D col, int damage)
    {
        if (col.name == gameObject.name)
        {
            Invoke("AnimationSelection", 0.0f);
            //animator.Play("LightGuard_Hurt");
            health -= damage;
            EventAggregator.enemy_health_bar_event.Publish(health);
        }
    }
    private void AnimationSelection()
    {
        int animation_index = Random.RandomRange(4, char_state.Count);
        State = animation_index;
    }

    private void Dead()
    {
        State = char_state["dead"];
        Destroy(this.gameObject, 2.5f);
    }

    protected override void Attack()
    {
        State = char_state["attack"];
        if (time_btw_attack <= 0)
        {

            Collider2D[] enemies_to_damage = Physics2D.OverlapCircleAll(attack_pose.position, attack_range, what_is_opponent);
            for (int i = 0; i < enemies_to_damage.Length; i++)
            {
                EventAggregator.hero_damage_event.Publish(damage);
            }
            time_btw_attack = start_time_btw_attack;
        }
        else
        {
            time_btw_attack -= Time.deltaTime;
        }
    }

    protected override void Angry()
    {
        
        if(player.position.x > transform.position.x && !facing_right)
        {
            Flip();
        }

        else if (player.position.x < transform.position.x && facing_right)
        {
            Flip();
        }
        State = char_state["walk"];
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attack_pose.position, attack_range);
    }

}
