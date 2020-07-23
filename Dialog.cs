using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    private List<Node> dialog;

    private DialogSystem dialog_system = new DialogSystem();

    [SerializeField] private TextAsset dialogue_file;

    public int current_node;

    [SerializeField] private bool dialogue_is_over = true;

    private Transform player;

    public GUISkin skin;

    public float distance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dialog = dialog_system.Load(dialogue_file);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < distance && Input.GetKeyDown(KeyCode.E))
        {
            dialogue_is_over = false;
        }
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        if (!dialogue_is_over)
        {
            GUI.Box(new Rect(Screen.width / 2 - 300, Screen.height - 300, 600, 250), "");
            GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height - 280, 500, 90), dialog[current_node].npc_text);
            for (int i = 0; i < dialog[current_node].answers.Count; i++)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height - 200 + 25 * i, 500, 25), dialog[current_node].answers[i].text_answer))
                {
                    if (dialog[current_node].answers[i].speak_end == true)
                    {
                        dialogue_is_over = true;
                    }
                    current_node = dialog[current_node].answers[i].to_node;
                }
            }
        }
    }

}
