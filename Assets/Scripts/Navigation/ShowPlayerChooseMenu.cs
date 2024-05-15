using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowPlayerChooseMenu : MonoBehaviour
{
    public GameObject playerChooseMenu;

    public void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { ShowMenu(); });
    }

    public void ShowMenu()
    {
        playerChooseMenu.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
