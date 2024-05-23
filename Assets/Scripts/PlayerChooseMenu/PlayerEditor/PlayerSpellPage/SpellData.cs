using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellData : MonoBehaviour
{
    private SpellDTO spellData;

    private GameObject descriptionPanel;
    private GameObject requirementsPanel;

    private bool isSelect;

    public void Start()
    {
        descriptionPanel = GameObject.Find("DescriptionPanel");
        requirementsPanel = GameObject.Find("SpellRequirementsPanel");

        isSelect = false;
    }

    public void SetSpellData(SpellDTO item)
    {
        spellData = item;

        gameObject.transform.Find("Name").GetComponentInChildren<Text>().text = spellData.BaseData.Name;
        gameObject.transform.Find("Spell").GetComponentInChildren<Image>().sprite = spellData.BaseData.Icon;

        GameObject spellCost = gameObject.transform.Find("Cost").gameObject;

        spellCost.transform.Find("EarthGemCost").GetComponentInChildren<Text>().text = spellData.ManaCost[EManaType.EarthStone].ToString();
        spellCost.transform.Find("FireGemCost").GetComponentInChildren<Text>().text = spellData.ManaCost[EManaType.FireStone].ToString();
        spellCost.transform.Find("AirGemCost").GetComponentInChildren<Text>().text = spellData.ManaCost[EManaType.AirStone].ToString();
        spellCost.transform.Find("WaterGemCost").GetComponentInChildren<Text>().text = spellData.ManaCost[EManaType.WaterStone].ToString();
    }

    public SpellDTO GetSpellData()
    {
        return spellData;
    }

    public void SetIsSelect(bool select)
    {
        isSelect = select;
    }

    public bool IsSelect()
    {
        return isSelect;
    }

    public void OnMouseEnter()
    {
        ShowSpellDescription(true);
        ShowSpellRequirements(true);
    }

    public void OnMouseExit()
    {
        ShowSpellDescription(false);
        ShowSpellRequirements(false);
    }

    private void ShowSpellDescription(bool show)
    {
        if (show)
        {
            descriptionPanel.transform.Find("SpellName").GetComponent<Text>().text = spellData.BaseData.Name;
            descriptionPanel.transform.Find("Description").GetComponent<TMP_Text>().text = spellData.BaseData.Name;
        }
        else
        {
            descriptionPanel.transform.Find("SpellName").GetComponent<Text>().text = "";
            descriptionPanel.transform.Find("Description").GetComponent<TMP_Text>().text = "";
        }
    }

    private void ShowSpellRequirements(bool show)
    {
        if (show)
        {
            Dictionary<ECharacteristic, int> requirements = spellData.RequirementsForUse;

            requirementsPanel.transform.Find("StrengthReq").GetComponent<Text>().text = requirements[ECharacteristic.Strength].ToString();
            requirementsPanel.transform.Find("DexterityReq").GetComponent<Text>().text = requirements[ECharacteristic.Dexterity].ToString();
            requirementsPanel.transform.Find("EnduranceReq").GetComponent<Text>().text = requirements[ECharacteristic.Endurance].ToString();
            requirementsPanel.transform.Find("FireMasteryReq").GetComponent<Text>().text = requirements[ECharacteristic.Fire].ToString();
            requirementsPanel.transform.Find("WaterMasteryReq").GetComponent<Text>().text = requirements[ECharacteristic.Water].ToString();
            requirementsPanel.transform.Find("EarthMasteryReq").GetComponent<Text>().text = requirements[ECharacteristic.Earth].ToString();
            requirementsPanel.transform.Find("AirMasteryReq").GetComponent<Text>().text = requirements[ECharacteristic.Air].ToString();
        }
        else
        {
            requirementsPanel.transform.Find("StrengthReq").GetComponent<Text>().text = "";
            requirementsPanel.transform.Find("DexterityReq").GetComponent<Text>().text = "";
            requirementsPanel.transform.Find("EnduranceReq").GetComponent<Text>().text = "";
            requirementsPanel.transform.Find("FireMasteryReq").GetComponent<Text>().text = "";
            requirementsPanel.transform.Find("WaterMasteryReq").GetComponent<Text>().text = "";
            requirementsPanel.transform.Find("EarthMasteryReq").GetComponent<Text>().text = "";
            requirementsPanel.transform.Find("AirMasteryReq").GetComponent<Text>().text = "";
        }

    }
}
