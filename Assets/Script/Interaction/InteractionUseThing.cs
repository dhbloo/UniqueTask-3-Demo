using UnityEngine;
using System.Collections;

public class InteractionUseThing : InteractionBase
{
    public string thing_name;

    protected override bool InteractionDemand()
    {
        return Input.GetKeyDown(KeyCode.E) && character_interaction.HaveThing(thing_name);
    }

    protected override void Interaction()
    {
        character_interaction.UseThing(thing_name);
    }
}
