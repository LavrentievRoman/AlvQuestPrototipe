using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlayerButtonClicked : MonoBehaviour
{
    public GameObject playerEditor;

    // Start is called before the first frame update
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { OpenPlayerEditor(); });
    }

    // Update is called once per frame
    private void OpenPlayerEditor()
    {
        playerEditor.SetActive(true);
    }
}
