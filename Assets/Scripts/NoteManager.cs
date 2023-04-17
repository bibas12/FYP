using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public void ChangeNoteKey(KeyCode oldKey, KeyCode newKey)
    {
        NoteObject[] noteObjects = FindObjectsOfType<NoteObject>();
        foreach (NoteObject noteObject in noteObjects)
        {
            if (noteObject.keyToPress == oldKey)
            {
                noteObject.keyToPress = newKey;
            }
        }
    }
}
