using UnityEngine;
using System.Collections;

public class InteractionBase : MonoBehaviour
{
    protected bool active = false;

    protected GameController game_controller;
    protected CharacterInteraction character_interaction;

    public string interaction_name;

    public string[] demand_histories;
    public string[] demand_no_histories;


    // Use this for initialization
    protected virtual void Start()
    {
        game_controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        character_interaction = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInteraction>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (game_controller.IsPause())
            return;

        if (active && InteractionDemand())
        {
            bool demand = true;
            foreach(string demand_history in demand_histories)
                demand &= character_interaction.HaveHistory(demand_history);
            if (demand)
            {
                foreach (string demand_no_history in demand_no_histories)
                    demand &= !character_interaction.HaveHistory(demand_no_history);
                if(!demand)
                {
                    enabled = false;
                    character_interaction.AddHistory(interaction_name);
                    return;
                }
                Interaction();
                if (!RepeatDemand())
                {
                    enabled = false;
                    character_interaction.AddHistory(interaction_name);
                }
            }
        }
    }
    
    protected virtual void OnDestroy()
    {
        
    }

    public virtual void SetActive(bool _active)
    {
        active = _active;
    }

    protected virtual bool InteractionDemand()
    {
        return true;
    }

    protected virtual void Interaction()
    {
        ;
    }

    protected virtual bool RepeatDemand()
    {
        return false;
    }
}
