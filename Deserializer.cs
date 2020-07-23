using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deserializer
{
    public object Deserialization(TextAsset text_asset, Type type)
    {
        XmlSerializer deserializer = new XmlSerializer(type);
        StreamReader reader = new StreamReader(text_asset.text);
        var date = deserializer.Deserialize(reader);
        return date;
        
    }
}
