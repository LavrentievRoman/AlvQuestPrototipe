using AlvQuest_Editor;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerCard : MonoBehaviour
{
    private CharacterDTO character;

    [SerializeField] 
    private GameObject namePanel;

    [SerializeField] 
    private GameObject imagePanel;

    [SerializeField] 
    private GameObject manaPanel;
    private GameObject strength;
    private GameObject dexterity;
    private GameObject endurance;
    private GameObject fire;
    private GameObject water;
    private GameObject earth;
    private GameObject air;

    [SerializeField] 
    private GameObject equipmentPanel;

    [SerializeField] 
    private GameObject perksPanel;

    [SerializeField] 
    private GameObject characteristicPanel;

    [SerializeField] 
    private GameObject spellPanel;
    private List<GameObject> spell = new();
    private List<GameObject> spellCost = new();

    void Start()
    {
        strength = characteristicPanel.transform.Find("Strength").gameObject;
        dexterity = characteristicPanel.transform.Find("Dexterity").gameObject;
        endurance = characteristicPanel.transform.Find("Endurance").gameObject;
        fire = characteristicPanel.transform.Find("FireMastery").gameObject;
        water = characteristicPanel.transform.Find("WaterMastery").gameObject;
        earth = characteristicPanel.transform.Find("EarthMastery").gameObject;
        air = characteristicPanel.transform.Find("AirMastery").gameObject;

        for (int i = 0; i < spellPanel.transform.childCount; i++)
        {
            if (i % 2 == 0) 
                spell.Add(spellPanel.transform.GetChild(i).gameObject);
            else 
                spellCost.Add(spellPanel.transform.GetChild(i).gameObject);
        }

        // Показываем значения карты персонажа по умолчанию
        ShowDefault();
    }

    // Отображение значений персонажа на карточке
    public void ShowCharacter(CharacterDTO newCharacter)
    {
        character = newCharacter;

        ShowHealtBar(0);
        ShowName(character.BaseData.Name);
        ShowImage(character.BaseData.Icon);
        ShowMana(character.Characteristics);
        ShowGold(0);
        ShowEquipment(character.Equipment);
        ShowPerks(character.Perks);
        ShowCharacteristic(character.Characteristics);
        ShowSpells(character.Spells);

    }

    // Отображения значения здоровья персонажа
    private void ShowHealtBar(int hp)
    {
        return;
    }

    // Отображение имени персонажа
    private void ShowName(string name)
    {
        namePanel.transform.Find("Name").GetComponent<Text>().text = name;
    }

    // Отображение картинки персонажа
    private void ShowImage(Sprite img)
    {
        imagePanel.transform.Find("Image").GetComponent<Image>().sprite = img;
    }

    // Отображение значений маны 
    private void ShowMana(Dictionary<ECharacteristic, int> characteristics)
    {
        manaPanel.transform.Find("MaxFireGemCount").GetComponent<Text>().text = (characteristics[ECharacteristic.Fire] * 2).ToString();
        manaPanel.transform.Find("MaxWaterGemCount").GetComponent<Text>().text = (characteristics[ECharacteristic.Water] * 2).ToString();
        manaPanel.transform.Find("MaxEarthGemCount").GetComponent<Text>().text = (characteristics[ECharacteristic.Earth] * 2).ToString();
        manaPanel.transform.Find("MaxAirGemCount").GetComponent<Text>().text = (characteristics[ECharacteristic.Air] * 2).ToString();
    }

    // Отображение количества золота у персонажа
    private void ShowGold(int goldCount)
    {
        return;
    }

    // Отображение экипировки перосонажа
    private void ShowEquipment(Dictionary<EBodyPart, EquipmentDTO> equipment)
    {
        equipmentPanel.transform.Find("HeadItem").GetComponentInChildren<Image>().sprite = equipment[EBodyPart.Head].BaseData.Icon;
        equipmentPanel.transform.Find("HeadItemText").GetComponentInChildren<Text>().text = equipment[EBodyPart.Head].BaseData.Name;

        equipmentPanel.transform.Find("BodyItem").GetComponentInChildren<Image>().sprite = equipment[EBodyPart.Body].BaseData.Icon;
        equipmentPanel.transform.Find("BodyItemText").GetComponentInChildren<Text>().text = equipment[EBodyPart.Body].BaseData.Name;

        equipmentPanel.transform.Find("HandsItem").GetComponentInChildren<Image>().sprite = equipment[EBodyPart.Hands].BaseData.Icon;
        equipmentPanel.transform.Find("HandsItemText").GetComponentInChildren<Text>().text = equipment[EBodyPart.Hands].BaseData.Name;

        equipmentPanel.transform.Find("FeetItem").GetComponentInChildren<Image>().sprite = equipment[EBodyPart.Feet].BaseData.Icon;
        equipmentPanel.transform.Find("FeetItemText").GetComponentInChildren<Text>().text = equipment[EBodyPart.Feet].BaseData.Name;

        equipmentPanel.transform.Find("WeaponItem").GetComponentInChildren<Image>().sprite = equipment[EBodyPart.Weapon].BaseData.Icon;
        equipmentPanel.transform.Find("WeaponItemText").GetComponentInChildren<Text>().text = equipment[EBodyPart.Weapon].BaseData.Name;

        equipmentPanel.transform.Find("ExtraItem").GetComponentInChildren<Image>().sprite = equipment[EBodyPart.Extra].BaseData.Icon;
        equipmentPanel.transform.Find("ExtraItemText").GetComponentInChildren<Text>().text = equipment[EBodyPart.Extra].BaseData.Name;
    }

    // Отображение перков пероснажа
    private void ShowPerks(List<PerkDTO> perks)
    {
        for (int i = 0; i < 6; i++)
        {
            perksPanel.transform.Find($"Perk{i + 1}").GetComponentInChildren<Image>().sprite = perks[i].BaseData.Icon;
            perksPanel.transform.Find($"Perk{i + 1}Text").GetComponentInChildren<Text>().text = perks[i].BaseData.Name;
        }
    }

    // Отображение характеристик персонажа
    private void ShowCharacteristic(Dictionary<ECharacteristic, int> characteristics)
    {
        strength.transform.Find("ParameterValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Strength].ToString();
        //strength.transform.Find("CombinationBonusValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Strength].ToString() + "%";
        //strength.transform.Find("AdditionalMoveChanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Strength].ToString() + "%";
        //strength.transform.Find("ResistanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Strength].ToString() + "%";

        dexterity.transform.Find("ParameterValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Dexterity].ToString();
        //dexterity.transform.Find("CombinationBonusValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Dexterity].ToString() + "%";
        //dexterity.transform.Find("AdditionalMoveChanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Dexterity].ToString() + "%";

        endurance.transform.Find("ParameterValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Endurance].ToString();
        //endurance.transform.Find("CombinationBonusValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Endurance].ToString() + "%";
        //endurance.transform.Find("AdditionalMoveChanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Endurance].ToString() + "%";

        fire.transform.Find("ParameterValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Fire].ToString();
        //fire.transform.Find("CombinationBonusValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Fire].ToString() + "%";
        //fire.transform.Find("AdditionalMoveChanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Fire].ToString() + "%";
        //fire.transform.Find("ResistanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Fire].ToString() + "%";

        water.transform.Find("ParameterValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Water].ToString();
        //water.transform.Find("CombinationBonusValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Water].ToString() + "%";
        //water.transform.Find("AdditionalMoveChanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Water].ToString() + "%";
        //water.transform.Find("ResistanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Water].ToString() + "%";

        earth.transform.Find("ParameterValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Earth].ToString();
        //earth.transform.Find("CombinationBonusValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Earth].ToString() + "%";
        //earth.transform.Find("AdditionalMoveChanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Earth].ToString() + "%";
        //earth.transform.Find("ResistanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Earth].ToString() + "%";

        air.transform.Find("ParameterValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Air].ToString();
        //air.transform.Find("CombinationBonusValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Air].ToString() + "%";
        //air.transform.Find("AdditionalMoveChanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Air].ToString() + "%";
        //air.transform.Find("ResistanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Air].ToString() + "%";
    }

    // Отображение заклинаний персонажа
    private void ShowSpells(List<SpellDTO> spells)
    {
        for (int i = 0; i < 9; i++)
        {
            spell[i].transform.Find("SpellName").GetComponentInChildren<Text>().text = spells[i].BaseData.Name;

            spellCost[i].transform.Find("MaxEarthGemCost").GetComponentInChildren<Text>().text = spells[i].ManaCost[EManaType.EarthStone].ToString();
            spellCost[i].transform.Find("MaxAirGemCost").GetComponentInChildren<Text>().text = spells[i].ManaCost[EManaType.AirStone].ToString();
            spellCost[i].transform.Find("MaxFireGemCost").GetComponentInChildren<Text>().text = spells[i].ManaCost[EManaType.FireStone].ToString();
            spellCost[i].transform.Find("MaxWaterGemCost").GetComponentInChildren<Text>().text = spells[i].ManaCost[EManaType.WaterStone].ToString();
        }
    }

    // Отображение базовых параметров
    private void ShowDefault()
    {
        return;
    }
}
