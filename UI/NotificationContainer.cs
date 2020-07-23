using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationContainer : MonoBehaviour
{
    private static NotificationContainer container_obj;

    public GameObject template;
    static GameObject container;

    private static Transform panel;

    private static Text notification_text;

    private void Awake()
    {
        container_obj = this;
    }

    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void initialization()
    {
        container = Object.Instantiate(container_obj.template);

        panel = container.transform.Find("Panel");

        notification_text = panel.Find("notification text").GetComponent<Text>();
    }

    public static void show_container(string district_name)
    {
        initialization();
        notification_text.text = district_name;
        Object.Destroy(container, 6.3f);
    }
}
