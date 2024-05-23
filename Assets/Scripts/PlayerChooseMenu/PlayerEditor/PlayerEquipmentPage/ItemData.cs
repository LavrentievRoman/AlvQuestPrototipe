using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemData : MonoBehaviour
{
    private EquipmentDTO equipmentData;

    private GameObject descriptionPanel;
    private GameObject requirementsPanel;

    private bool isSelect;

    public void Start()
    {
        descriptionPanel = GameObject.Find("DescriptionPanel");
        requirementsPanel = GameObject.Find("EquipmentRequirementsPanel");

        isSelect = false;
    }

    public void SetItemData(EquipmentDTO item)
    {
        equipmentData = item;

        gameObject.transform.Find("Name").GetComponentInChildren<Text>().text = equipmentData.BaseData.Name;
        gameObject.transform.Find("Item").GetComponentInChildren<Image>().sprite = equipmentData.BaseData.Icon;
    }

    public EquipmentDTO GetItemData()
    {
        return equipmentData;
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
        ShowItemDescription(true);
        ShowItemRequirements(true);
    }

    public void OnMouseExit()
    {
        ShowItemDescription(false);
        ShowItemRequirements(false);
    }

    private void ShowItemDescription(bool show)
    {
        if (show)
        {
            descriptionPanel.transform.Find("ItemName").GetComponent<Text>().text = equipmentData.BaseData.Name;
            descriptionPanel.transform.Find("Description").GetComponent<TMP_Text>().text = equipmentData.BaseData.Name;
        }
        else
        {
            descriptionPanel.transform.Find("ItemName").GetComponent<Text>().text = "";
            descriptionPanel.transform.Find("Description").GetComponent<TMP_Text>().text = "";
        }
    }

    private void ShowItemRequirements(bool show)
    {
        if (show)
        {
            Dictionary<ECharacteristic, int> requirements = equipmentData.RequirementsForUse;

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
