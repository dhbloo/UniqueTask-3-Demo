using UnityEngine;
using System.Collections;

public class InteractionKey1 : InteractionBase
{
    protected override bool InteractionDemand()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    protected override void Interaction()
    {
        GameState game_state = game_controller.GetState();
        if (game_state == GameState.start)
        {
            text_controller.StartText(11);
            game_state = GameState.find_red_key;
        }
        else if (game_state == GameState.find_red_key)
            Destroy(gameObject);
    }
}
