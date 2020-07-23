using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileBar : MonoBehaviour
{
    public Image bar;
    public List<Image> skill_cells = new List<Image>();

    private void Awake()
    {
        EventAggregator.health_bar_event.Subscribe(ReduceHealth);
        EventAggregator.reduce_skill_event.Subscribe(ReduceSkill);
        EventAggregator.reset_skill_event.Subscribe(ResetSkill);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ReduceHealth(float health)
    {
        //Debug.Log(health);
        bar.fillAmount = health / 100;
    }

    private void ReduceSkill(int index, float restore)
    {
        //Debug.Log(restore);
        skill_cells[index].fillAmount += restore;
    }

    private void ResetSkill(int index)
    {
        skill_cells[index].fillAmount = 0;
    }
}