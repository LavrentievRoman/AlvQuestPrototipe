using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButtonCliked : MonoBehaviour
{
    public GameObject NextPanel;

    private GameObject playerEditor;
    
    void Start()
    {
        playerEditor = GameObject.Find("PlayerEditor");

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { OpenNextPanel(); });
    }

    void OpenNextPanel()
    {
        playerEditor.GetComponentInChildren<PlayerEditor>().SaveInformation();

        NextPanel.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
