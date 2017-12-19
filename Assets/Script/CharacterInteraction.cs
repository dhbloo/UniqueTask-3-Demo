using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterInteraction : MonoBehaviour
{
    List<string> histories;
    List<string> things;

    public string[] interaction_tags;

    // Use this for initialization
    void Start()
    {
        histories = new List<string>();
        things = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (string tag in interaction_tags)
            if (other.tag == tag)
            {
                foreach (InteractionBase interaction in other.GetComponents<InteractionBase>())
                    interaction.SetActive(true);
                return;
            }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (string tag in interaction_tags)
            if (other.tag == tag)
            {
                foreach (InteractionBase interaction in other.GetComponents<InteractionBase>())
                    interaction.SetActive(false);
                return;
            }
    }

    public void PickUpThing(string _thing)
    {
        things.Add(_thing);
    }

    public bool UseThing(string _thing)
    {
        return things.Remove(_thing);
    }

    public bool HaveThing(string _thing)
    {
        return things.Contains(_thing);
    }

    public void AddHistory(string _history)
    {
        histories.Add(_history);
    }

    public bool HaveHistory(string _history)
    {
        return histories.Contains(_history);
    }

    public bool RemoveHistory(string _history)
    {
        return histories.Remove(_history);
    }

    public void ClearHistory()
    {
        histories.Clear();
    }
}
