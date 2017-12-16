using UnityEngine;
using System.Collections;

public class InteractionBase : MonoBehaviour
{
    protected bool active = false;

    protected GameController game_controller;
    protected TextController text_controller;
    
    protected GameObject cube_E;
    public Vector3 cube_E_offset;

    // Use this for initialization
    protected void Start()
    {
        game_controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        text_controller = GameObject.FindGameObjectWithTag("TextController").GetComponent<TextController>();

        cube_E = Instantiate(GameObject.FindGameObjectWithTag("CubeE"));
        cube_E.transform.SetParent(transform);
        cube_E.transform.localPosition = cube_E_offset;
        cube_E.SetActive(false);
    }

    // Update is called once per frame
    protected void Update()
    {
        if (game_controller.IsPause())
            return;

        if (active && InteractionDemand())
            Interaction();
    }
    
    protected void OnDestroy()
    {
        Destroy(cube_E);
    }

    public void SetActive(bool _active)
    {
        cube_E.SetActive(_active);
        active = _active;
    }

    protected virtual bool InteractionDemand()
    {
        return true;
    }

    protected virtual void Interaction()
    {
        Destroy(gameObject);
    }
}
