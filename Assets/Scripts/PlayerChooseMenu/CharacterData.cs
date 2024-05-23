using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour
{
    private CharacterDTO character;

    void Start()
    {
        character = new CharacterDTO();
    }

    public CharacterDTO GetCharacterData()
    {
        return character;
    }

    public void SetCharacterData(CharacterDTO data)
    {
        character = data;

        GameObject namePanel = gameObject.transform.Find("NamePanel").gameObject;

        namePanel.transform.Find("Name").GetComponentInChildren<Text>().text = character.BaseData.Name;

        //gameObject.transform.Find("Image").GetComponentInChildren<Image>().sprite = character.BaseData.Icon;

        GameObject lvlPanel = gameObject.transform.Find("LevelPanel").gameObject;

        lvlPanel.transform.Find("Lvl").GetComponentInChildren<Text>().text = character.Level.ToString();

        SetCharacteristics(character.Characteristics);

    }

    private void SetCharacteristics(Dictionary<ECharacteristic, int> characteristics)
    {
        GameObject charPanel = gameObject.transform.Find("ÑharacteristicPanel").gameObject;

        charPanel.transform.Find("StrengthValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Strength].ToString();
        charPanel.transform.Find("DexterityValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Dexterity].ToString();
        charPanel.transform.Find("EnduranceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Endurance].ToString();
        charPanel.transform.Find("FireMasteryValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Fire].ToString();
        charPanel.transform.Find("WaterMasteryValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Water].ToString();
        charPanel.transform.Find("EarthMasteryValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Earth].ToString();
        charPanel.transform.Find("AirMasteryValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Air].ToString();
    }
}
