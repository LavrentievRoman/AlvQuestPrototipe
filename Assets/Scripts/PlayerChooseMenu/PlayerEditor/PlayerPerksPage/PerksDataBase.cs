using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class PerksDataBase : MonoBehaviour
{   
    public GameObject perkForList;
    public GameObject contentPanel;

    public Sprite icon1;
    public Sprite icon2;
    public Sprite icon3;

    private List<PerkDTO> perksDataBase;

    public void UpdateInformation()
    {
        for (int i = 0; i < perksDataBase.Count; i++)
        {
            bool isSelect = contentPanel.transform.GetChild(i).GetComponent<PerkData>().IsSelect();
            bool isApply = CheckPlayerСharacteristic(contentPanel.transform.GetChild(i).GetComponent<PerkData>().GetPerkData());

            if (!isSelect && isApply)
            {
                contentPanel.transform.GetChild(i).Find("Name").GetComponent<Button>().interactable = true;              
            }
            if (isSelect || !isApply)
            {
                contentPanel.transform.GetChild(i).Find("Name").GetComponent<Button>().interactable = false;
            }
        }
        GameObject.Find("PlayerPerksPanel").GetComponent<PlayerPerksSetup>().SetNeedUpdate(false);
    }

    public void SetActiveContentPanel(bool active)
    {
        contentPanel.SetActive(active);
    }

    public GameObject FindPerk(string name)
    {
        for (int i = 0; i < perksDataBase.Count; i++)
        {
            if (contentPanel.transform.GetChild(i).Find("Name").GetComponentInChildren<Text>().text == name)
            {
                return contentPanel.transform.GetChild(i).gameObject;
            }
        }
        return null;
    }

    private void Start()
    {
        perksDataBase = new List<PerkDTO>();

        FillDataBase();

        AddGraphics();
    }

    private void AddGraphics()
    {
        for (int i = 0; i < perksDataBase.Count; i++)
        {
            GameObject newPerk = Instantiate(perkForList, contentPanel.transform) as GameObject;

            newPerk.name = "Perk" + (i + 1).ToString();
            newPerk.GetComponent<PerkData>().SetPerkData(perksDataBase[i]);

            RectTransform rt = newPerk.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newPerk.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);
        }

        UpdateInformation();
    }

    private bool CheckPlayerСharacteristic(PerkDTO perk)
    {
        Dictionary<ECharacteristic, int> characteristic = GameObject.Find("PlayerEditor").GetComponent<PlayerEditor>().GetPlayerCharacteristics();

        if (perk.RequirementsForUse[ECharacteristic.Strength] > characteristic[ECharacteristic.Strength])
        {
            return false;
        }
        if (perk.RequirementsForUse[ECharacteristic.Dexterity] > characteristic[ECharacteristic.Dexterity])
        {
            return false;
        }
        if (perk.RequirementsForUse[ECharacteristic.Endurance] > characteristic[ECharacteristic.Endurance])
        {
            return false;
        }
        if (perk.RequirementsForUse[ECharacteristic.Fire] > characteristic[ECharacteristic.Fire])
        {
            return false;
        }
        if (perk.RequirementsForUse[ECharacteristic.Water] > characteristic[ECharacteristic.Water])
        {
            return false;
        }
        if (perk.RequirementsForUse[ECharacteristic.Air] > characteristic[ECharacteristic.Air])
        {
            return false;
        }
        if (perk.RequirementsForUse[ECharacteristic.Earth] > characteristic[ECharacteristic.Earth])
        {
            return false;
        }
        return true;
    }

    private void FillDataBase()
    {
        PerkDTO newPerk = new PerkDTO();

        newPerk.BaseData.Name = "Тестовый перк 1";
        newPerk.BaseData.Description = "Описание тестового перка 1";
        newPerk.BaseData.Icon = icon1;
        newPerk.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 6,
            [ECharacteristic.Dexterity] = 8,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };

        perksDataBase.Add(newPerk);

        newPerk = new PerkDTO();

        newPerk.BaseData.Name = "Тестовый перк 2";
        newPerk.BaseData.Description = "Описание тестового перка 2";
        newPerk.BaseData.Icon = icon2;
        newPerk.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 10,
            [ECharacteristic.Dexterity] = 5,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };

        perksDataBase.Add(newPerk);

        newPerk = new PerkDTO();

        newPerk.BaseData.Name = "Тестовый перк 3";
        newPerk.BaseData.Description = "Описание тестового перка 3";
        newPerk.BaseData.Icon = icon3;
        newPerk.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 5,
            [ECharacteristic.Dexterity] = 5,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 10,
            [ECharacteristic.Water] = 10,
            [ECharacteristic.Air] = 10,
            [ECharacteristic.Earth] = 10,
        };

        perksDataBase.Add(newPerk);
    }
}
