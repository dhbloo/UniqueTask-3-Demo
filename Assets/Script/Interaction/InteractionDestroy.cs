using UnityEngine;
using System.Collections;

public class InteractionDestroy : InteractionBase
{
    protected override void Interaction()
    {
        Destroy(gameObject);
    }
}
