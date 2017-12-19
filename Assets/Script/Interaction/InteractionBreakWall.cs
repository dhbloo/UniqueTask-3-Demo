using UnityEngine;
using System.Collections;

public class InteractionBreakWall : InteractionBase
{
    protected override bool InteractionDemand()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    protected override void Interaction()
    {
        GetComponent<WallBreak>().BreakWall();
    }
}
