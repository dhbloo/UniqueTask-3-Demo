using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tip : MonoBehaviour
{
    public Text text_prefab;
    public Text title_prefab;
    public RawImage box_prefab;

    private Text text;
    private Text title;
    private RawImage box;
    private float time_keep;

    private float time;

    // Use this for initialization
    void Start()
    {
        box = Instantiate(box_prefab);
        box.transform.SetParent(transform);

        title = Instantiate(title_prefab);
        title.transform.SetParent(transform);

        text = Instantiate(text_prefab);
        text.transform.SetParent(transform);

        time = 0;
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public void SetText(string _text)
    {
        text.text = _text;
    }

    public void SetTitle(string _title)
    {
        title.text = _title;
    }

    public void SetTime(float _time)
    {
        time_keep = _time;
    }

    private void OnDestroy()
    {
        Destroy(text);
        Destroy(title);
        Destroy(box);
    }
}
