using UnityEngine;
using System.Collections;

public class ButtonID : MonoBehaviour {

    private int _destinationId;
    public int destinationId
    {
        get
        {
            return _destinationId;
        }
        set
        {
            _destinationId = value;
        }
    }

    DialogueLoader dl;

    void Start()
    {

        dl = GameObject.FindGameObjectWithTag("loader").GetComponent<DialogueLoader>();
    }



    public void LoadDialogue()
    {
        dl.LoadDialogue(destinationId);
    }
}
