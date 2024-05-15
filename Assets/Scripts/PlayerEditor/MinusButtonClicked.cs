using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class MinusButtonClicked : MonoBehaviour
{
    private GameObject characteristic;

    private GameObject panel;

    public void Start()
    {
        characteristic = transform.parent.gameObject.transform.Find("CharacteristicValue").gameObject;

        panel = GameObject.Find("PlayerMain—haracteristicPanel");

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { ReduceCharacteristicValue(); });
    }

    public void Update()
    {
        if (int.Parse(characteristic.GetComponentInChildren<Text>().text) == 1)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }      
    }

    public void ReduceCharacteristicValue()
    {
        int newValue = int.Parse(characteristic.GetComponentInChildren<Text>().text) - 1;
        characteristic.GetComponentInChildren<Text>().text = newValue.ToString();

        panel.GetComponentInChildren<PlayerCharacteristicSetup>().IncreaseCharacteristicPoint();
        panel.GetComponentInChildren<PlayerCharacteristicSetup>().UpdateInformation();
    }
}
