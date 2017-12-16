using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tip : MonoBehaviour
{
    public Text text_prefab;
    public RawImage box_prefab;

    private Text text;
    private RawImage box;
    private float time_keep = 1;

    private bool inited = false;
    private TextPool pool;

    private float time = 0;

    // Use this for initialization
    private void Start()
    {

    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > time_keep)
            Destroy(gameObject);
    }

    public void Init(TextPool _pool)
    {
        if (inited)
            return;

        pool = _pool;
        box = Instantiate(box_prefab, transform);
        text = Instantiate(text_prefab, transform);

        time = 0;

        inited = true;
    }

    public void SetText(string _text)
    {
        text.text = _text;
    }

    public void SetTime(float _time)
    {
        time_keep = _time;
    }

    private void OnDestroy()
    {
        if (inited)
        {
            pool.Continue();
            Destroy(text);
            Destroy(box);
        }
    }
}
