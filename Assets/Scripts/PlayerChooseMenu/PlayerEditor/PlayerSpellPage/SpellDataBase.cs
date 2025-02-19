using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellDataBase : MonoBehaviour
{
    public GameObject spellForList;
    public GameObject contentPanel;

    public Sprite icon1;
    public Sprite icon2;
    public Sprite icon3;

    private List<SpellDTO> spellsDataBase;

    public void UpdateInformation()
    {
        for (int i = 0; i < spellsDataBase.Count; i++)
        {
            bool isSelect = contentPanel.transform.GetChild(i).GetComponent<SpellData>().IsSelect();
            bool isApply = CheckPlayerСharacteristic(contentPanel.transform.GetChild(i).GetComponent<SpellData>().GetSpellData());

            if (!isSelect && isApply)
            {
                contentPanel.transform.GetChild(i).Find("Name").GetComponent<Button>().interactable = true;
            }
            if (isSelect || !isApply)
            {
                contentPanel.transform.GetChild(i).Find("Name").GetComponent<Button>().interactable = false;
            }
        }
        GameObject.Find("PlayerSpellPanel").GetComponent<PlayerSpellsSetup>().SetNeedUpdate(false);
    }

    public void SetActiveContentPanel(bool active)
    {
        contentPanel.SetActive(active);
    }

    public GameObject FindSpell(string name)
    {
        for (int i = 0; i < spellsDataBase.Count; i++)
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
        FillDataBase();

        AddGraphics();
    }

    private void AddGraphics()
    {
        for (int i = 0; i < spellsDataBase.Count; i++)
        {
            GameObject newSpell = Instantiate(spellForList, contentPanel.transform) as GameObject;

            newSpell.name = "Spell" + (i + 1).ToString();

            newSpell.GetComponent<SpellData>().SetSpellData(spellsDataBase[i]);

            RectTransform rt = newSpell.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newSpell.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);
        }

        UpdateInformation();
    }

    private bool CheckPlayerСharacteristic(SpellDTO perk)
    {
        Dictionary<ECharacteristic, int> characteristic = GameObject.Find("PlayerEditor").GetComponent<PlayerEditor>().CustomPlayer.Characteristics;

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
        spellsDataBase = new List<SpellDTO>();

        SpellDTO newSpell = new SpellDTO();

        newSpell.BaseData.Name = "Тестовое заклинание 1";
        newSpell.BaseData.Description = "Описание тестового заклинания 1";
        newSpell.BaseData.Icon = icon1;
        newSpell.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 5,
            [ECharacteristic.Dexterity] = 5,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 7,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };
        newSpell.ManaCost = new Dictionary<EManaType, double>
        {
            [EManaType.EarthStone] = 0,
            [EManaType.FireStone] = 1,
            [EManaType.WaterStone] = 0,
            [EManaType.AirStone] = 0
        };

        spellsDataBase.Add(newSpell);

        newSpell = new SpellDTO();

        newSpell.BaseData.Name = "Тестовое заклинание 2";
        newSpell.BaseData.Description = "Описание тестового заклинания 2";
        newSpell.BaseData.Icon = icon2;
        newSpell.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 5,
            [ECharacteristic.Dexterity] = 5,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 7,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };
        newSpell.ManaCost = new Dictionary<EManaType, double>
        {
            [EManaType.EarthStone] = 0,
            [EManaType.FireStone] = 0,
            [EManaType.WaterStone] = 2,
            [EManaType.AirStone] = 0
        };

        spellsDataBase.Add(newSpell);

        newSpell = new SpellDTO();

        newSpell.BaseData.Name = "Тестовое заклинание 3";
        newSpell.BaseData.Description = "Описание тестового заклинания 3";
        newSpell.BaseData.Icon = icon3;
        newSpell.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 5,
            [ECharacteristic.Dexterity] = 5,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 7,
            [ECharacteristic.Earth] = 5,
        };
        newSpell.ManaCost = new Dictionary<EManaType, double>
        {
            [EManaType.EarthStone] = 0,
            [EManaType.FireStone] = 0,
            [EManaType.WaterStone] = 0,
            [EManaType.AirStone] = 3
        };

        spellsDataBase.Add(newSpell);
    }
}
