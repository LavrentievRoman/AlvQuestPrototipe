using AlvQuest_Editor;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour
{
    private SelectCharacter selectCharacter;

    private GameObject namePanel;
    private GameObject lvlPanel;
    private GameObject imagePanel;
    private GameObject charPanel;

    private CharacterDTO _character;
    public CharacterDTO Character 
    { 
        get
        {
            return _character;
        }
        set
        {
            _character = value;

            ShowCharacterMainInformation(_character);
        }
    }

    private void Awake()
    {
        namePanel = transform.Find("NamePanel").gameObject;
        lvlPanel = transform.Find("LevelPanel").gameObject;
        imagePanel = transform.Find("ImagePanel").gameObject;
        charPanel = transform.Find("СharacteristicPanel").gameObject;

        selectCharacter = GameObjectManager.Instance.Objects["CharacterList"].GetComponent<SelectCharacter>();
    }

    private void OnMouseDown()
    {
        selectCharacter.SelectedCharacterCard = gameObject;
    }

    // Отображение основной информации о персонаже
    private void ShowCharacterMainInformation(CharacterDTO character)
    {
        namePanel.transform.Find("Name").GetComponentInChildren<Text>().text = character.BaseData.Name;

        imagePanel.transform.Find("Image").GetComponentInChildren<Image>().sprite = character.BaseData.Icon;

        lvlPanel.transform.Find("Lvl").GetComponentInChildren<Text>().text = character.Level.ToString();

        ShowCharacteristics(character.Characteristics);
    }

    // Отображение характеристик пероснажа
    private void ShowCharacteristics(Dictionary<ECharacteristic, int> characteristics)
    {      
        charPanel.transform.Find("StrengthValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Strength].ToString();
        charPanel.transform.Find("DexterityValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Dexterity].ToString();
        charPanel.transform.Find("EnduranceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Endurance].ToString();
        charPanel.transform.Find("FireMasteryValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Fire].ToString();
        charPanel.transform.Find("WaterMasteryValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Water].ToString();
        charPanel.transform.Find("EarthMasteryValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Earth].ToString();
        charPanel.transform.Find("AirMasteryValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Air].ToString();
    }
}
