using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dialogue2 : MonoBehaviour
{
    public Text text_prefab;
    public Text speaker_prefab;


    private Text text;
    private Text speaker;

    // Use this for initialization
    void Start()
    {
        speaker = Instantiate(speaker_prefab);
        speaker.transform.SetParent(transform);

        text = Instantiate(text_prefab);
        text.transform.SetParent(transform);
    }

    public void SetText(string _text)
    {
        text.text = _text;
    }

    public void SetSpeaker(string _speaker)
    {
        speaker.text = _speaker;
    }

    private void OnDestroy()
    {
        Destroy(text);
        Destroy(speaker);
    }
}
