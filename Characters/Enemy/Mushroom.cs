using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy
{
    private bool explosion_occurred = false;

    private PointEffector2D point_effector;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        point_effector = attack_pose.GetComponent<PointEffector2D>();
        char_state.Add("hit", 1);
        char_state.Add("explosion", 2);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < stopping_distance)
        {
            angry = true;
        }



        if (angry)
        {
            if (transform.position.y < -0.843)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f * Time.deltaTime, transform.position.z);
            }
            else
            {
                Angry();
            } 
        }

        if (attack)
        {
            State = char_state["explosion"];
            Attack();
            Destroy(this.gameObject, 1f);
        }
    }

    protected override void Angry()
    {
        angry = false;
        attack = true;
    }

    protected override void Attack()
    {
        if (!explosion_occurred)
        {
            walk_sound.Play();
            Collider2D[] enemies_to_damage = Physics2D.OverlapCircleAll(attack_pose.transform.position, attack_range, what_is_opponent);
            for (int i = 0; i < enemies_to_damage.Length; i++)
            {
                if (!enemies_to_damage[i].isTrigger)
                {
                    point_effector.enabled = true;
                    EventAggregator.hero_damage_event.Publish(damage);
                }
            }
            explosion_occurred = true;
        }   
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attack_pose.transform.position, attack_range);
    }

}
