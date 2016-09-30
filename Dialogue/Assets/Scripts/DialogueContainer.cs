using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[XmlRoot("dialogue")]
public class DialogueContainer {

    [XmlArray("messages")]
    [XmlArrayItem("message")]
    public List<Dialogue> dialogues = new List<Dialogue>();

    public static DialogueContainer Load(TextAsset path)
    {
        TextAsset _xml = path;

        XmlSerializer serializer = new XmlSerializer(typeof(DialogueContainer));

        StringReader reader = new StringReader(_xml.text);

        DialogueContainer dialogues = serializer.Deserialize(reader) as DialogueContainer;

        reader.Close();

        return dialogues;
    }

}
