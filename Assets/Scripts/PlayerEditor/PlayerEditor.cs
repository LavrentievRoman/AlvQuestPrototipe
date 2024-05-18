using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEditor : MonoBehaviour
{
    private CharacterDTO character;

    private GameObject playerNamePanel;
    private GameObject playerMain—haracteristicPanel;
    private GameObject playerPerksPanel;
    private GameObject playerEquipmentPanel;
    private GameObject playerSpellPanel;

    public void Start()
    {
        playerNamePanel = gameObject.transform.Find("PlayerNamePanel").gameObject;
        playerMain—haracteristicPanel = gameObject.transform.Find("PlayerMain—haracteristicPanel").gameObject;
        playerPerksPanel = gameObject.transform.Find("PlayerPerksPanel").gameObject;
        //playerEquipmentPanel = gameObject.transform.Find("PlayerEquipmentPanel").gameObject;
        //playerSpellPanel = gameObject.transform.Find("PlayerSpellPanel").gameObject;

        character = new CharacterDTO();
    }

    public void SavePlayer()
    {

    }

    public void SaveInformation()
    {
        if(playerNamePanel.activeInHierarchy)
        {
            playerNamePanel.GetComponentInChildren<PlayerNameSetup>().SaveInformation(character);
        }         
        if(playerMain—haracteristicPanel.activeInHierarchy)
        {
            playerMain—haracteristicPanel.GetComponentInChildren<PlayerCharacteristicSetup>().SaveInformation(character);
        }               
    }

    public void SetDefault()
    {
        if (playerMain—haracteristicPanel.activeInHierarchy)
        {
            playerMain—haracteristicPanel.GetComponentInChildren<PlayerCharacteristicSetup>().SetDefaults();
        }
    }

    public int GetPlayerCharPoints()
    {
        return character.CharPoints;
    }

    public Dictionary<ECharacteristic, int> GetPlayerCharacteristics()
    {
        return character.Characteristics;
    }
}
