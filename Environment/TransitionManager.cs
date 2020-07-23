using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public GameObject template;

    private bool is_created = false;

    private int[] index_day_scene = { 2 };

    private int[] index_night_scene = { 0 };

    private void Awake()
    {
        EventAggregator.transition_character_event.Subscribe(LoadPlace);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadPlace(int index, bool is_day)
    {
        if (is_day)
        {
            SceneManager.LoadScene(index_day_scene[index]);
        }
        else
        {
            SceneManager.LoadScene(index_night_scene[index]);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && Input.GetKey(KeyCode.E) && !is_created)
        {
            Instantiate(template);
            is_created = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        is_created = false;
    }
}
