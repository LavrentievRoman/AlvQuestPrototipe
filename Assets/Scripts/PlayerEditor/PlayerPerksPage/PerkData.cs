using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerkData : MonoBehaviour
{
    private PerkDTO perkData;

    private GameObject descriptionPanel;
    private GameObject requirementsPanel;

    private bool isSelect;

    public void Start()
    {
        descriptionPanel = GameObject.Find("DescriptionPanel");
        requirementsPanel = GameObject.Find("PerkRequirementsPanel");

        isSelect = false;
    }

    public void SetPerkData(PerkDTO perk)
    {
        perkData = perk;

        gameObject.transform.Find("Name").GetComponentInChildren<Text>().text = perkData.BaseData.Name;
        gameObject.transform.Find("Perk").GetComponentInChildren<Image>().sprite = perkData.BaseData.Icon;
    }

    public PerkDTO GetPerkData()
    {
        return perkData;
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
        ShowPerkDescription(true);
        ShowPerkRequirements(true);
    }

    public void OnMouseExit()
    {
        ShowPerkDescription(false);
        ShowPerkRequirements(false);
    }

    private void ShowPerkDescription(bool show)
    {
        if (show)
        {
            descriptionPanel.transform.Find("PerkName").GetComponent<Text>().text = perkData.BaseData.Name;
            descriptionPanel.transform.Find("Description").GetComponent<TMP_Text>().text = perkData.BaseData.Name;
        }
        else
        {
            descriptionPanel.transform.Find("PerkName").GetComponent<Text>().text = "";
            descriptionPanel.transform.Find("Description").GetComponent<TMP_Text>().text = "";
        }
    }

    private void ShowPerkRequirements(bool show)
    {
        if (show)
        {
            Dictionary<ECharacteristic, int> requirements = perkData.RequirementsForUse;

            requirementsPanel.transform.Find("StrengthReq").GetComponent<Text>().text = requirements[ECharacteristic.Strength].ToString();
            requirementsPanel.transform.Find("DexterityReq").GetComponent<Text>().text = requirements[ECharacteristic.Dexterity].ToString();
            requirementsPanel.transform.Find("EnduranceReq").GetComponent<Text>().text = requirements[ECharacteristic.Endurance].ToString();
            requirementsPanel.transform.Find("FireMasteryReq").GetComponent<Text>().text = requirements[ECharacteristic.Fire].ToString();
            requirementsPanel.transform.Find("WaterMasteryReq").GetComponent<Text>().text = requirements[ECharacteristic.Water].ToString();
            requirementsPanel.transform.Find("EarthMasteryReq").GetComponent<Text>().text = requirements[ECharacteristic.Air].ToString();
            requirementsPanel.transform.Find("AirMasteryReq").GetComponent<Text>().text = requirements[ECharacteristic.Earth].ToString();
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
