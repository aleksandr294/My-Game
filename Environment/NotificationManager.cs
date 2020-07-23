using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    public string t;
    private bool is_created = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(is_created)
        {
            StartCoroutine(NotificationRecovery());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && !is_created)
        {
            NotificationContainer.show_container(t);
            is_created = true;
        }
    }

    private IEnumerator<WaitForSeconds> NotificationRecovery()
    {
        yield return new WaitForSeconds(30f);
        is_created = false;
    }
}
