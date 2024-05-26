using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerCard : MonoBehaviour
{
    private CharacterDTO character;

    void Start()
    {
        ShowDefault();
    }

    public void ShowCharacter(CharacterDTO newCharacter)
    {
        character = newCharacter;

        //ShowHealtBar(0);
        ShowName(character.BaseData.Name);
        ShowImage(character.BaseData.Icon);
        ShowMana(character.Characteristics);
        //ShowGold(0);
        ShowEquipment(character.Equipment);
        ShowPerks(character.Perks);
        ShowCharacteristic(character.Characteristics);
        ShowSpells(character.Spells);

    }

    private void ShowHealtBar(int hp)
    {

    }

    private void ShowName(string name)
    {
        GameObject namePanel = gameObject.transform.Find("NamePanel").gameObject;

        namePanel.transform.Find("Name").GetComponent<Text>().text = name;
    }

    private void ShowImage(Sprite img)
    {
        GameObject imagePanel = gameObject.transform.Find("ImagePanel").gameObject;

        imagePanel.transform.Find("Image").GetComponent<Image>().sprite = img;
    }

    private void ShowMana(Dictionary<ECharacteristic, int> characteristics)
    {
        GameObject manaPanel = gameObject.transform.Find("ManaPanel").gameObject;

        manaPanel.transform.Find("MaxFireGemCount").GetComponent<Text>().text = (characteristics[ECharacteristic.Fire] * 2).ToString();
        manaPanel.transform.Find("MaxWaterGemCount").GetComponent<Text>().text = (characteristics[ECharacteristic.Water] * 2).ToString();
        manaPanel.transform.Find("MaxEarthGemCount").GetComponent<Text>().text = (characteristics[ECharacteristic.Earth] * 2).ToString();
        manaPanel.transform.Find("MaxAirGemCount").GetComponent<Text>().text = (characteristics[ECharacteristic.Air] * 2).ToString();
    }

    private void ShowGold(int goldCount)
    {

    }

    private void ShowEquipment(Dictionary<EBodyPart, EquipmentDTO> equipment)
    {
        GameObject equipmentPanel = gameObject.transform.Find("EquipmentPanel").gameObject;

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

    private void ShowPerks(List<PerkDTO> perks)
    {
        GameObject perksPanel = gameObject.transform.Find("PerksPanel").gameObject;

        for (int i = 0; i < 6; i++)
        {
            perksPanel.transform.Find($"Perk{i + 1}").GetComponentInChildren<Image>().sprite = perks[i].BaseData.Icon;
            perksPanel.transform.Find($"Perk{i + 1}Text").GetComponentInChildren<Text>().text = perks[i].BaseData.Name;
        }
    }

    private void ShowCharacteristic(Dictionary<ECharacteristic, int> characteristics)
    {
        GameObject characteristicPanel = gameObject.transform.Find("ÑharacteristicPanel").gameObject;

        GameObject strength = characteristicPanel.transform.Find("Strength").gameObject;
        strength.transform.Find("ParameterValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Strength].ToString();
        //strength.transform.Find("CombinationBonusValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Strength].ToString() + "%";
        //strength.transform.Find("AdditionalMoveChanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Strength].ToString() + "%";
        //strength.transform.Find("ResistanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Strength].ToString() + "%";

        GameObject dexterity = characteristicPanel.transform.Find("Dexterity").gameObject;
        dexterity.transform.Find("ParameterValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Dexterity].ToString();
        //dexterity.transform.Find("CombinationBonusValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Dexterity].ToString() + "%";
        //dexterity.transform.Find("AdditionalMoveChanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Dexterity].ToString() + "%";

        GameObject endurance = characteristicPanel.transform.Find("Endurance").gameObject;
        endurance.transform.Find("ParameterValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Endurance].ToString();
        //endurance.transform.Find("CombinationBonusValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Endurance].ToString() + "%";
        //endurance.transform.Find("AdditionalMoveChanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Endurance].ToString() + "%";

        GameObject fire = characteristicPanel.transform.Find("FireMastery").gameObject;
        fire.transform.Find("ParameterValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Fire].ToString();
        //fire.transform.Find("CombinationBonusValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Fire].ToString() + "%";
        //fire.transform.Find("AdditionalMoveChanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Fire].ToString() + "%";
        //fire.transform.Find("ResistanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Fire].ToString() + "%";

        GameObject water = characteristicPanel.transform.Find("WaterMastery").gameObject;
        water.transform.Find("ParameterValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Water].ToString();
        //water.transform.Find("CombinationBonusValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Water].ToString() + "%";
        //water.transform.Find("AdditionalMoveChanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Water].ToString() + "%";
        //water.transform.Find("ResistanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Water].ToString() + "%";

        GameObject earth = characteristicPanel.transform.Find("EarthMastery").gameObject;
        earth.transform.Find("ParameterValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Earth].ToString();
        //earth.transform.Find("CombinationBonusValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Earth].ToString() + "%";
        //earth.transform.Find("AdditionalMoveChanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Earth].ToString() + "%";
        //earth.transform.Find("ResistanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Earth].ToString() + "%";

        GameObject air = characteristicPanel.transform.Find("AirMastery").gameObject;
        air.transform.Find("ParameterValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Air].ToString();
        //air.transform.Find("CombinationBonusValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Air].ToString() + "%";
        //air.transform.Find("AdditionalMoveChanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Air].ToString() + "%";
        //air.transform.Find("ResistanceValue").GetComponentInChildren<Text>().text = characteristics[ECharacteristic.Air].ToString() + "%";
    }

    private void ShowSpells(List<SpellDTO> spells)
    {
        GameObject spellPanel = gameObject.transform.Find("SpellPanel").gameObject;

        for (int i = 0; i < 9; i++)
        {
            GameObject spell = spellPanel.transform.Find($"Spell{i + 1}").gameObject;
            GameObject spellCost = spellPanel.transform.Find($"Spell{i + 1}Cost").gameObject;

            spell.transform.Find("SpellName").GetComponentInChildren<Text>().text = spells[i].BaseData.Name;

            spellCost.transform.Find("MaxEarthGemCost").GetComponentInChildren<Text>().text = spells[i].ManaCost[EManaType.EarthStone].ToString();
            spellCost.transform.Find("MaxAirGemCost").GetComponentInChildren<Text>().text = spells[i].ManaCost[EManaType.AirStone].ToString();
            spellCost.transform.Find("MaxFireGemCost").GetComponentInChildren<Text>().text = spells[i].ManaCost[EManaType.FireStone].ToString();
            spellCost.transform.Find("MaxWaterGemCost").GetComponentInChildren<Text>().text = spells[i].ManaCost[EManaType.WaterStone].ToString();
        }
    }

    private void ShowDefault()
    {

    }
}
