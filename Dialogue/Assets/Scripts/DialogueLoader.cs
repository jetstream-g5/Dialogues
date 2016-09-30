using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueLoader : MonoBehaviour {

    [SerializeField]private TextAsset path;

    private DialogueContainer dc;
    private Dialogue currentDialogue;

    [SerializeField]private GameObject panel;
    [SerializeField]private Text source;
    [SerializeField]private Text text;
    [SerializeField]private Button[] options;

    //public delegate void LoadNextDialogue(int destination);
    //public static event LoadNextDialogue OnLoadNextDialogue;

    void Start () {
        dc = DialogueContainer.Load(path);

        LoadDialogue(1);
	}

    public void LoadDialogue(int ID)
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].gameObject.SetActive(false);
        }
        if(ID == 0)
        {
            panel.SetActive(false);
        }

        foreach (Dialogue dialogue in dc.dialogues)
        {
            if (dialogue.id == ID)
            {
                currentDialogue = dialogue;
                SetText();
                Debug.Log(dialogue.id);
            }
        }
    }

    void SetText()
    {
        source.text = currentDialogue.source;
        text.text = currentDialogue.text;
        AddButtons();
        for (int i = 0; i < currentDialogue.options.Length; i++){
            options[i].gameObject.GetComponentInChildren<Text>().text = currentDialogue.options[i];
        }
    }

    void AddButtons()
    {
        for (int i = 0; i < currentDialogue.options.Length; i++)
        {
            options[i].gameObject.SetActive(true);
            options[i].gameObject.GetComponent<ButtonID>().destinationId = currentDialogue.destinations[i];
        }
    }
}
