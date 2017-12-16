using UnityEngine;
using System.Collections;

public class InteractionPickUp : InteractionBase
{
    public GameState game_state_before_pick_up = GameState.start;
    public GameState game_state_after_pick_up = GameState.start;

    public int text_key = 0;

    protected override bool InteractionDemand()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    protected override void Interaction()
    {
        GameState game_state = game_controller.GetState();
        if (game_state <= game_state_before_pick_up)
        {
            text_controller.StartText(text_key);
            game_controller.SetState(game_state_after_pick_up);
        }
        else if (game_state >= game_state_after_pick_up)
            Destroy(gameObject);
    }
}
