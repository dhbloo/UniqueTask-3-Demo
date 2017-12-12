using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dialogue1 : MonoBehaviour
{
    public Text text_prefab;
    public RawImage box_prefab;

    private Text text;
    private RawImage box;
    private float time_keep;

    private float time;

    // Use this for initialization
    void Start()
    {
        text = Instantiate(text_prefab);
        text.transform.SetParent(transform);

        box = Instantiate(box_prefab);
        box.transform.SetParent(transform);

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

    public void SetTime(float _time)
    {
        time_keep = _time;
    }

    private void OnDestroy()
    {
        Destroy(text);
        Destroy(box);
    }
}
