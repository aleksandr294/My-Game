using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TransitionContainer : MonoBehaviour
{
    [SerializeField] private Button go;
    [SerializeField] private Button day_night;

    [SerializeField] private Text description_t;

    [SerializeField] private List<string> description_of_places = new List<string>();

    [SerializeField] private Sprite moon_icon;
    [SerializeField] private Sprite sun_icon;

    [SerializeField] private TextAsset location_file_description;

    private bool is_day = true;

    private int scene_index;

    void Start()
    {
        //Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(List<string>));
        StringReader stringReader = new StringReader(location_file_description.text);
        description_of_places = deserializer.Deserialize(stringReader) as List<string>;
    }

    public void SeatSelection(int index)
    {
        scene_index = index;
        description_t.text = description_of_places[index];
    }

    public void CharacterTransition()
    {
        EventAggregator.transition_character_event.Publish(scene_index, is_day);
    }

    public void ChangeTimeOfDay()
    {
        if(is_day)
        {
            day_night.image.sprite = moon_icon;
            is_day = false;
        }
        else
        {
            day_night.image.sprite = sun_icon;
            is_day = true;
        }
    }

}
