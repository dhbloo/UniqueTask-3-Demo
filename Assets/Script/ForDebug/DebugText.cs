using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DebugText : MonoBehaviour
{
    public GameObject text_controller_obj;
    public Text debug_text;

    private TextController text_controller;
    
    private int debug_key;

    // Use this for initialization
    void Start ()
    {
        text_controller = text_controller_obj.GetComponent<TextController>();
        debug_text.text = "DebugText: ";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            debug_text.text = "DebugText: ";
            debug_key = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            text_controller.StartText(debug_key);
            debug_text.text = "DebugText: ";
            debug_key = 0;
            return;
        }

        KeyCode num = KeyCode.Alpha0;
        for (num = KeyCode.Alpha0; num <= KeyCode.Alpha9; num++)
        {
            if (Input.GetKeyDown(num))
            {
                debug_key = debug_key * 10 + num - KeyCode.Alpha0;
                debug_text.text = "DebugText: " + debug_key.ToString();
                return;
            }
        }

        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            debug_key /= 10;
            if (debug_key == 0)
                debug_text.text = "DebugText: ";
            else
                debug_text.text = "DebugText: " + debug_key.ToString();
            return;
        }
	}
}
