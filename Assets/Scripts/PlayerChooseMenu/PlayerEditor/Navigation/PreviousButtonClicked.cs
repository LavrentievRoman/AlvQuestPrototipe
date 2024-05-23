using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviousButtonClicked : MonoBehaviour
{
    public GameObject PreviousPanel;

    private GameObject playerEditor;

    void Start()
    {
        playerEditor = GameObject.Find("PlayerEditor");

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { OpenPreviousPanel(); });
    }

    void OpenPreviousPanel()
    {
        playerEditor.GetComponentInChildren<PlayerEditor>().SetDefault();

        PreviousPanel.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
