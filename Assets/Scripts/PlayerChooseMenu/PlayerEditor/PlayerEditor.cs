using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

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
        playerEquipmentPanel = gameObject.transform.Find("PlayerEquipmentPanel").gameObject;
        playerSpellPanel = gameObject.transform.Find("PlayerSpellPanel").gameObject;

        character = new CharacterDTO();
    }

    public void CloseEditor()
    {
        playerMain—haracteristicPanel.SetActive(true);
        playerMain—haracteristicPanel.GetComponentInChildren<PlayerCharacteristicSetup>().SetDefaults();
        playerMain—haracteristicPanel.SetActive(false);

        playerPerksPanel.SetActive(true);
        playerPerksPanel.GetComponentInChildren<PlayerPerksSetup>().SetDefaults();
        playerPerksPanel.SetActive(false);

        playerEquipmentPanel.SetActive(true);
        playerEquipmentPanel.GetComponentInChildren<PlayerEquipmentSetup>().SetDefaults();
        playerEquipmentPanel.SetActive(false);

        playerSpellPanel.SetActive(true);
        playerSpellPanel.GetComponentInChildren<PlayerSpellsSetup>().SetDefaults();
        playerSpellPanel.SetActive(false);

        playerNamePanel.SetActive(true);
        playerNamePanel.GetComponentInChildren<PlayerNameSetup>().SetDefaults();

        character = new CharacterDTO();

        gameObject.SetActive(false);
    }

    public void SavePlayer()
    {      
        GameObject.Find("CharacterList").GetComponent<CharacterDataBase>().AddNewCharacter(character);

        CloseEditor();
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
        if (playerPerksPanel.activeInHierarchy)
        {
            playerPerksPanel.GetComponentInChildren<PlayerPerksSetup>().SaveInformation(character);
        }
        if (playerEquipmentPanel.activeInHierarchy)
        {
            playerEquipmentPanel.GetComponentInChildren<PlayerEquipmentSetup>().SaveInformation(character);
        }
        if (playerSpellPanel.activeInHierarchy)
        {
            playerSpellPanel.GetComponentInChildren<PlayerSpellsSetup>().SaveInformation(character);
        }
    }

    public void SetDefault()
    {
        if (playerMain—haracteristicPanel.activeInHierarchy)
        {
            playerMain—haracteristicPanel.GetComponentInChildren<PlayerCharacteristicSetup>().SetDefaults();
        }
        if (playerPerksPanel.activeInHierarchy)
        {
            playerPerksPanel.GetComponentInChildren<PlayerPerksSetup>().SetDefaults();
        }
        if (playerEquipmentPanel.activeInHierarchy)
        {
            playerEquipmentPanel.GetComponentInChildren<PlayerEquipmentSetup>().SetDefaults();
        }
        if (playerSpellPanel.activeInHierarchy)
        {
            playerSpellPanel.GetComponentInChildren<PlayerSpellsSetup>().SetDefaults();
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
