using UnityEngine;
using System.Collections;

public class InteractionText : InteractionBase
{
    public bool demand_E;
    public bool repeat;
    public int text_key;

    protected override bool InteractionDemand()
    {
        if (demand_E)
            return Input.GetKeyDown(KeyCode.E);
        else
            return true;
    }

    protected override void Interaction()
    {
        GameObject.FindGameObjectWithTag("TextController").GetComponent<TextController>().StartText(text_key);
        if (repeat)
            enabled = true;
    }

    protected override bool RepeatDemand()
    {
        return repeat;
    }
}
