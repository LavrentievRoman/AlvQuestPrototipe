using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlusButtonClicked : MonoBehaviour
{
    private GameObject characteristic;

    private GameObject panel;

    public void Start()
    {
        characteristic = transform.parent.gameObject.transform.Find("CharacteristicValue").gameObject;

        panel = GameObject.Find("PlayerMainСharacteristicPanel");

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { IncreaseCharacteristicValue(); });
    }

    public void Update()
    {
        if (int.Parse(characteristic.GetComponentInChildren<Text>().text) == 99 || panel.GetComponentInChildren<PlayerCharacteristicSetup>().GetCharacteristicPointValue() == 0)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void IncreaseCharacteristicValue()
    {
        int newValue = int.Parse(characteristic.GetComponentInChildren<Text>().text) + 1;
        characteristic.GetComponentInChildren<Text>().text = newValue.ToString();

        panel.GetComponentInChildren<PlayerCharacteristicSetup>().ReduceCharacteristicPoint();
        panel.GetComponentInChildren<PlayerCharacteristicSetup>().UpdateInformation();
    }
}
