using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizelSkills : MonoBehaviour
{
    [SerializeField] private List<float> skills = new List<float>();

    public Transform fire_point;

    [SerializeField] private GameObject torch;
    //[SerializeField] private Transform attack_pose;

    float time = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && skills[0] <= 0)
        {
           
            Instantiate(torch, fire_point.position, fire_point.rotation);
            skills[0] = 25f;
            EventAggregator.reset_skill_event.Publish(0);
        }
        else
        {
            skills[0] -= Time.deltaTime;
            //Invoke("SkillRecovery", 2f);
            StartCoroutine(skill_reload(1, 0.0017f, 0));
        }
        //if (Input.GetKeyDown(KeyCode.Alpha2) && skills[1] <= 0)
        //{
        //    Collider2D[] enemies_to_damage = Physics2D.OverlapCircleAll(attack_pose.position, attack_range, what_is_enemy);
        //    for (int i = 0; i < enemies_to_damage.Length; i++)
        //    {
        //        EventAggregator.kick_event.Publish(enemies_to_damage[i], 25f);
        //    }
        //    skills[1] = 25f;
        //    EventAggregator.reset_skill_event.Publish(1);
        //}
        //else
        //{
        //    skills[0] -= Time.deltaTime;
        //    //Invoke("SkillRecovery", 2f);
        //    StartCoroutine(skill_reload(1, 0.0017f, 0));
        //}
    }

    private IEnumerator<WaitForSeconds> skill_reload(float seconds, float restore, int index)
    {
        EventAggregator.reduce_skill_event.Publish(index, restore);
        yield return new WaitForSeconds(seconds);
    }

}
