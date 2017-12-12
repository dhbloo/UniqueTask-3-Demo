using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Dialogue1Pool : MonoBehaviour
{
    public GameObject dialogue_prefab;

    private Queue<float> time_pool;
    private Queue<string> text_pool;

    private Queue<GameObject> dialogue_obj_pool;

    GameObject dialogue_obj;
    
    private float time;
    private float time_keep;

    // Use this for initialization
    void Start()
    {
        time_pool = new Queue<float>();
        dialogue_obj_pool = new Queue<GameObject>();

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time != 0)
        {
            time += Time.deltaTime;

            if(time > time_keep)
            {
                Destroy(dialogue_obj);
                time = 0;
            }
            return;
        }

        if (dialogue_obj_pool.Count > 0)
        {
            dialogue_obj = dialogue_obj_pool.Dequeue();
            dialogue_obj.SetActive(true);

            time_keep = time_pool.Dequeue();
            time += Time.deltaTime;
        }
    }

    private void CreateDialogueToPool(float _time, string _text)
    {
        dialogue_obj = Instantiate(dialogue_prefab);
        dialogue_obj.transform.SetParent(transform);
        dialogue_obj.SetActive(false);
        Dialogue1 dialogue = dialogue_obj.GetComponent<Dialogue1>();
        dialogue.SetText(_text);
        dialogue.SetTime(_time);

        dialogue_obj_pool.Enqueue(dialogue_obj);
    }

    public void Add(float _time, string _text)
    {
        time_pool.Enqueue(_time);
        CreateDialogueToPool(_time, _text);
    }

    private void OnDestroy()
    {
        if (dialogue_obj_pool.Count > 0)
        {
            dialogue_obj = dialogue_obj_pool.Dequeue();
            Destroy(dialogue_obj);
        }
    }
}
