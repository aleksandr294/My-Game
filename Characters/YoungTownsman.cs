using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YoungTownsman : NPC
{
    private RectTransform dialog_rect_transform;
    private RectTransform dialog_text_rect_transform;

    public float start_time_dialog;
    private float dialog_time;

    public Transform friend;

    [SerializeField] private List<string> replicas = new List<string>();

    private Image dialog_box;

    private Text dialog_text;

    void Start()
    {
        wait_time = start_wait_time;
        
        random_spot = Random.RandomRange(0, move_spots.Count);

        animator = GetComponent<Animator>();

        dialog_rect_transform = transform.GetChild(0).GetComponent<RectTransform>();
        dialog_text_rect_transform = transform.GetChild(1).GetComponent<RectTransform>();
        Debug.Log(dialog_rect_transform.rect);
        dialog_box = transform.GetChild(0).GetComponent<Image>();
        dialog_text = transform.GetChild(1).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();

        if (Vector3.Distance(transform.position, friend.position) < 0.4f && replicas.Count != 0)
        {
            Debug.Log(gameObject.name + "\n" + facing_right);
            wait_time = 20f;
            if (facing_right)
            {
                Debug.Log(gameObject.name + facing_right);
                //Debug.Log(gameObject.name + "\n" + dialog_rect_transform.rotation.y);
                //dialog_rect_transform.Rotate(0, 0, 0);
                dialog_text_rect_transform.Rotate(0, 0, 0);
            }
            else
            {
                Debug.Log(gameObject.name + facing_right);
                //Debug.Log(gameObject.name + "\n" + dialog_rect_transform.rotation.y);
                //dialog_rect_transform.Rotate(0, 180, 0);
                dialog_text_rect_transform.Rotate(0, 180, 0);
            }

            dialog_box.enabled = true;
            dialog_text.enabled = true;


            StartCoroutine(TypeSentence(replicas[0]));
            replicas.RemoveAt(0);
        }
    }
    
    private IEnumerator TypeSentence(string sentence)
    {
        foreach (var character in sentence)
        {
            dialog_text.text += character;
            yield return null;
        }
    }

    
}
