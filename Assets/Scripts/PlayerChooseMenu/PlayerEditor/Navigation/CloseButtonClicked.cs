using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButtonClicked : MonoBehaviour
{
    private GameObject playerEditor;

    void Start()
    {
        playerEditor = GameObject.Find("PlayerEditor");

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { ShowCloseDialog(); });
    }

    // Update is called once per frame
    private void ShowCloseDialog()
    {
        playerEditor.transform.Find("CloseEditorDialog").gameObject.SetActive(true);
    }
}
