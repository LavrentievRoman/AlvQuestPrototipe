using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameSetup : MonoBehaviour
{    
    public string defaultPlayerName;
    public int defaultPlayerLvl;

    private GameObject playerNameLabel;
    private GameObject playerLvlLabel;

    public void Start()
    {
        playerNameLabel = gameObject.transform.Find("PlayerNameInputField").gameObject;
        playerLvlLabel = gameObject.transform.Find("PlayerLevelInputField").gameObject;

        playerNameLabel.GetComponent<TMP_InputField>().text = defaultPlayerName;
        playerLvlLabel.GetComponent<TMP_InputField>().text = defaultPlayerLvl.ToString();
    }

    public void SaveInformation(CharacterDTO character)
    {
        int lvl = int.Parse(playerLvlLabel.GetComponent<TMP_InputField>().text);
        if (lvl <= 0)
        {
            lvl = defaultPlayerLvl;
            playerLvlLabel.GetComponent<TMP_InputField>().text = defaultPlayerLvl.ToString();
        }  
        
        string name = playerNameLabel.GetComponent<TMP_InputField>().text;

        int charPoints = int.Parse(playerLvlLabel.GetComponent<TMP_InputField>().text) * 4;

        character.Level = lvl;
        character.BaseData.Name = name;

        gameObject.transform.parent.Find("PlayerMain—haracteristicPanel").GetComponentInChildren<PlayerCharacteristicSetup>().SetCharacteristicPointValue(charPoints);
    }
}
