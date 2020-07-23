using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem
{
    public List<Node> Load(TextAsset text_asset)
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(List<Node>));
        StringReader stringReader = new StringReader(text_asset.text);
        var dialog = deserializer.Deserialize(stringReader) as List<Node>;
        return dialog;
    }
}

[System.Serializable]
public class Node
{
    public string npc_text;
    public List<Answer> answers;
}
[System.Serializable]
public class Answer
{
    public string text_answer;
    public int to_node;
    public bool speak_end;
}
