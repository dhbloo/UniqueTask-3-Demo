using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TipPool : MonoBehaviour
{
    public GameObject tip_prefab;

    private Queue<float> time_pool;
    private Queue<GameObject> tip_obj_pool;

    GameObject tip_obj;

    private float time;
    private float time_keep;

    // Use this for initialization
    void Start()
    {
        time_pool = new Queue<float>();
        tip_obj_pool = new Queue<GameObject>();

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time != 0)
        {
            time += Time.deltaTime;

            if (time > time_keep)
            {
                Destroy(tip_obj);
                time = 0;
            }
            return;
        }

        if (tip_obj_pool.Count > 0)
        {
            tip_obj = tip_obj_pool.Dequeue();
            tip_obj.SetActive(true);

            time_keep = time_pool.Dequeue();
            time += Time.deltaTime;
        }
    }

    private void CreateTipToPool(float _time, string _text, string _title)
    {
        tip_obj = Instantiate(tip_prefab);
        tip_obj.transform.SetParent(transform);
        tip_obj.SetActive(false);
        Tip tip = tip_obj.GetComponent<Tip>();
        tip.SetText(_text);
        tip.SetTitle(_title);
        tip.SetTime(_time);

        tip_obj_pool.Enqueue(tip_obj);
    }

    public void Add(float _time, string _text, string _title)
    {
        time_pool.Enqueue(_time);
        CreateTipToPool(_time, _text, _title);
    }

    private void OnDestroy()
    {
        if (tip_obj_pool.Count > 0)
        {
            tip_obj = tip_obj_pool.Dequeue();
            Destroy(tip_obj);
        }
    }
}
