using UnityEngine;
using System.Collections;

public class CharacterInteraction : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Thing")
            other.GetComponent<InteractionBase>().SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Thing")
            other.GetComponent<InteractionBase>().SetActive(false);
    }
}
