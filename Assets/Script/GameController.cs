using UnityEngine;
using System.Collections;

public enum GameState
{
    start = 1,
    find_red_key = 2,
    find_green_key = 3
}

public class GameController : MonoBehaviour
{
    private GameState state;
    private bool is_pause;
    private float pause_time;

    // Use this for initialization
    void Start()
    {
        state = GameState.start;
        is_pause = false;
        pause_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pause_time > 0)
        {
            pause_time -= Time.deltaTime;
            if (pause_time <= 0)
                Continue();
        }
    }

    public GameState GetState()
    {
        return state;
    }

    public void SetState(GameState _state)
    {
        state = _state;
    }

    public void Pause()
    {
        is_pause = true;
    }

    public void Pause(float _time)
    {
        is_pause = true;
        pause_time = _time;
    }

    public void Continue()
    {
        is_pause = false;
    }

    public bool IsPause()
    {
        return is_pause;
    }
}
