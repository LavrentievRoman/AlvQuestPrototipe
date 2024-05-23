using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButtonClicked : MonoBehaviour
{
    private GameObject playerEditor;

    void Start()
    {
        playerEditor = GameObject.Find("PlayerEditor");

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { SaveCharacter(); });
    }

    // Update is called once per frame
    private void SaveCharacter()
    {
        playerEditor.GetComponent<PlayerEditor>().SaveInformation();
        playerEditor.GetComponent<PlayerEditor>().SavePlayer();
        playerEditor.GetComponent<PlayerEditor>().CloseEditor();
    }
}
