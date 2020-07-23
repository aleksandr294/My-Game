using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : Character
{
    private float move_input;
    public float check_radius;
    public float jump_force;
    private float time_btw_attack;
    public float start_time_btw_attack;
    public float attack_range;
    private float next_step = 0f;
    private float step_rite = 0.6f;

    protected Dictionary<string, int> char_state = new Dictionary<string, int>
        {
            {"hero_idl", 0 },
            {"hero_walk", 1 },
            {"hero_run", 2 },
            {"hero_jump", 3 },
            {"hero_attack", 4 }
        };

    private bool is_ground;

    private Rigidbody2D rigidbody2D;

    public Transform ground_check;
    public Transform attack_pose;

    public LayerMask what_is_ground;
    public LayerMask what_is_enemy;

    private int extra_jump;
    public int extra_jump_value;
    public int damage;

    private SpriteRenderer sprite_renderer;

    public AudioSource walk_sound;
    public AudioClip audioClip;

    public Rigidbody2D Rigidbody_2D
    {
        get
        {
            return rigidbody2D;
        }

        set
        {
            rigidbody2D = value;
        }
    }


    private void Awake()
    {
        EventAggregator.hero_damage_event.Subscribe(TakingDamage);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        extra_jump = extra_jump_value;
        
    }

    private void FixedUpdate()
    {
        is_ground = Physics2D.OverlapCircle(ground_check.position, check_radius, what_is_ground);
        move_input = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        State = char_state["hero_idl"];
        if(Input.GetButton("Horizontal"))
        {
            State = char_state["hero_walk"];
            Run();
            //PlaySoundEffect(walk_sound, next_step, step_rite, audioClip);
            if (Time.time > next_step && is_ground)
            {
                //PlaySoundEffect(walk_sound, next_step, step_rite, audioClip);
                next_step = Time.time + step_rite;
                walk_sound.pitch = Random.Range(0.7f, 1.1f);
                walk_sound.Play();
                //walk_sound.PlayOneShot(audioClip);
            }
        }
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetButton("Horizontal"))
        {
            State = char_state["hero_run"];
            Run();
        }
        
        if(is_ground)
        {
            extra_jump = extra_jump_value;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && extra_jump > 0)
        {
            State = char_state["hero_jump"];
            Jump();
            extra_jump--;
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && extra_jump == 0 && is_ground)
        {
            Jump();
        }

       if(Input.GetKey(KeyCode.F))
        {
            State = char_state["hero_attack"];
            Attack();
        }     
    }

    public void TakingDamage(float damage)
    {
        health -= damage;
        EventAggregator.health_bar_event.Publish(health);
    }

    public override void Run()
    {
        
        //Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        rigidbody2D.velocity = new Vector3(move_input * speed, rigidbody2D.velocity.y, transform.position.z);
        if (move_input > 0 && !facing_right)
        {
            Flip();
        }

        else if (move_input < 0 && facing_right)
        {
            Flip();
        }
        //walk_sound.PlayDelayed(0.05f);
        //PlaySoundEffect(walk_sound, next_step, step_rite, audioClip);
    }

    public void Jump()
    {
        rigidbody2D.velocity = Vector2.up * jump_force;
    }

    private void Attack()
    {
        if (time_btw_attack <= 0)
        {
            
                Collider2D[] enemies_to_damage = Physics2D.OverlapCircleAll(attack_pose.position, attack_range, what_is_enemy);
                for (int i = 0; i < enemies_to_damage.Length; i++)
                {
                    EventAggregator.kick_event.Publish(enemies_to_damage[i], damage);
                }
            time_btw_attack = start_time_btw_attack;
        }
        else
        {
            time_btw_attack -= Time.deltaTime;
        }
    }
    private IEnumerator<WaitForSeconds> play()
    {
        //walk_sound.PlayOneShot(audioClip);
        walk_sound.PlayDelayed(1f);
        yield return new WaitForSeconds(1.5f);
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Moving platform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Moving platform"))
        {
            this.transform.parent = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attack_pose.position, attack_range);
    }

}
