using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowEnemyChooseMenu : MonoBehaviour
{
    public GameObject enemyChooseMenu;

    public void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { ShowMenu(); });
    }

    public void ShowMenu()
    {
        enemyChooseMenu.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
