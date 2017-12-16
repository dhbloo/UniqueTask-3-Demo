using UnityEngine;
using System.Collections;

public class TextPauseGame : MonoBehaviour
{
    private GameController game_controller;

    private float pause_time;

    // Use this for initialization
    void Start()
    {
        game_controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        pause_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pause_time > 0)
        {
            pause_time -= Time.deltaTime;
            if(pause_time <= 0)
                game_controller.Continue();
        }
    }

    public void PauseGameKeep()
    {
        game_controller.Pause();
    }

    public void ContinueGame()
    {
        game_controller.Continue();
    }

    public void PauseGameTime(float _pause_time)
    {
        game_controller.Pause();
        pause_time = _pause_time;
    }
}
