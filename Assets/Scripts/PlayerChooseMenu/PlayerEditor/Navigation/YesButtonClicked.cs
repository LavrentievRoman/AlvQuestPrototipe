using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesButtonClicked : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { CloseEditor(); });
    }

    // Update is called once per frame
    private void CloseEditor()
    {
        GameObject playerEditor = GameObject.Find("PlayerEditor").gameObject;
        playerEditor.GetComponent<PlayerEditor>().CloseEditor();

        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
