using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private Image health_bar;
    // Start is called before the first frame update

    private void Awake()
    {
        EventAggregator.enemy_health_bar_event.Subscribe(ReduceHealth);
    }

    void Start()
    {
        health_bar = transform.GetChild(0).GetComponent<Image>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReduceHealth(float health)
    {
        Debug.Log(health);
        health_bar.fillAmount = health / 100;
    }
}
