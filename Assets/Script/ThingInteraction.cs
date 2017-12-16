using UnityEngine;
using System.Collections;

public class ThingInteraction : MonoBehaviour
{
    public int text_key = 0;

    public int destroy_text_key = 0;

    private bool active = false;

    public GameObject cube_E_prefab;
    private GameObject cube_E;
    public Vector3 cube_E_offset;

    // Use this for initialization
    void Start()
    {
        cube_E = Instantiate(cube_E_prefab);
        cube_E.transform.SetParent(transform);
        cube_E.transform.localPosition = cube_E_offset;
        cube_E.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.FindGameObjectWithTag("TextController").GetComponent<TextController>().StartText(text_key);
            if (text_key == destroy_text_key)
                Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Destroy(cube_E);
    }

    public void SetActive(bool _active)
    {
        cube_E.SetActive(_active);
        active = _active;
    }

    public void SetTextKey(int _text_key)
    {
        text_key = _text_key;
    }
}
