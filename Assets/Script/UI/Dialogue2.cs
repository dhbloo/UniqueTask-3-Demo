using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dialogue2 : MonoBehaviour
{
    public Text text_prefab;
    public Text speaker_prefab;
    public RawImage box_prefab;
    public RawImage portrait_prefab;

    private Text text;
    private Text speaker;
    private RawImage box;
    private RawImage portrait;

    private bool inited = false;
    private TextPool pool;

    public KeyCode key_continue = KeyCode.E;

    // Use this for initialization
    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(key_continue))
            Destroy(gameObject);
    }

    public void Init(TextPool _pool)
    {
        if (inited)
            return;

        pool = _pool;

        portrait = Instantiate(portrait_prefab);
        portrait.transform.SetParent(transform);
        portrait.transform.Translate(transform.position);
        portrait.transform.localScale = new Vector3(1, 1, 1);

        box = Instantiate(box_prefab);
        box.transform.SetParent(transform);
        box.transform.Translate(transform.position);
        box.transform.localScale = new Vector3(1, 1, 1);

        speaker = Instantiate(speaker_prefab);
        speaker.transform.SetParent(transform);
        speaker.transform.Translate(transform.position);
        speaker.transform.localScale = new Vector3(1, 1, 1);

        text = Instantiate(text_prefab);
        text.transform.SetParent(transform);
        text.transform.Translate(transform.position);
        text.transform.localScale = new Vector3(1, 1, 1);

        // Set Game Stop

        inited = true;
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
        if (inited)
        {
            pool.SetActive(true);
            Destroy(text);
            Destroy(speaker);
            Destroy(box);
            Destroy(portrait);

            // Set Game Continue
        }
    }
}
