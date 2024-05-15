using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    private GameObject currentMenu;

    public void Start()
    {
        currentMenu = transform.parent.gameObject;

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { ShowMenu(); });
    }

    public void ShowMenu()
    {
        mainMenu.SetActive(true);
        currentMenu.SetActive(false);
    }
}
