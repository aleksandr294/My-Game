using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogBox : MonoBehaviour
{
    private RectTransform dialog_rect_transform;
    private RectTransform dialog_text_rect_transform;

    public Transform friend;

    [SerializeField] private List<string> replicas = new List<string>();

    private Image dialog_box;

    private Text dialog_text;

    void Start()
    {
        dialog_rect_transform = transform.GetChild(0).GetComponent<RectTransform>();
        dialog_text_rect_transform = transform.GetChild(0).GetComponent<RectTransform>();

        dialog_box = transform.GetChild(0).GetComponent<Image>();
        dialog_text = transform.GetChild(0).GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
