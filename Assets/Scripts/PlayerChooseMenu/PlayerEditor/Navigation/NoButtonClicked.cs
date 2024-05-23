using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoButtonClicked : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { CloseDialog(); });
    }

    private void CloseDialog()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
