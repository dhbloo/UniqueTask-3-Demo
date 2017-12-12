using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Dialogue2Pool : MonoBehaviour
{
    public RawImage box_prefab;
    public RawImage portrait_prefab;
    public GameObject dialogue_prefab;
    
    private Queue<string> text_pool;
    private Queue<string> speaker_pool;

    private RawImage box_obj;
    private RawImage portrait_obj;
    private GameObject dialogue_obj;
    
    private bool active;
    public KeyCode key_end = KeyCode.E;


    // Use this for initialization
    void Start()
    {
        text_pool = new Queue<string>();
        speaker_pool = new Queue<string>();
        
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
            return;

        if (Input.GetKeyDown(key_end))
        {
            Destroy(dialogue_obj);
            if (text_pool.Count > 0)
                CreateDialogue();
            else
            {
                Destroy(box_obj);
                Destroy(portrait_obj);
                active = false;
                return;
            }
        }
    }

    private void CreateDialogue()
    {
        dialogue_obj = Instantiate(dialogue_prefab);
        dialogue_obj.transform.SetParent(transform);
        Dialogue2 dialogue = dialogue_obj.GetComponent<Dialogue2>();
        dialogue.SetText(text_pool.Dequeue());
        dialogue.SetSpeaker(speaker_pool.Dequeue());
    }

    public void Add(string _text, string _speaker)
    {
        text_pool.Enqueue(_text);
        speaker_pool.Enqueue(_speaker);
    }

    public void StartActivity()
    {
        if (text_pool.Count > 0)
        {
            portrait_obj = Instantiate(portrait_prefab);
            portrait_obj.transform.SetParent(transform);

            box_obj = Instantiate(box_prefab);
            box_obj.transform.SetParent(transform);

            CreateDialogue();

            active = true;
        }
    }

    private void OnDestroy()
    {
        if (active)
        {
            Destroy(dialogue_obj);
            Destroy(box_obj);
            Destroy(portrait_obj);
        }
    }
}
