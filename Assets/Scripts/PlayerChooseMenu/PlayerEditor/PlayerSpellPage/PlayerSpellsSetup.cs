using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpellsSetup : MonoBehaviour, IPlayerSetup
{
    public SpellDTO defaultSpell;
    public Sprite defaultIcon;

    private GameObject currentSpellSlot;
    private GameObject spellPanel;

    private List<SpellDTO> spells;

    private bool needUpdate;

    // Start is called before the first frame update
    void Start()
    {
        spellPanel = gameObject.transform.Find("SpellButtonPanel").gameObject;

        defaultSpell = new SpellDTO();
        MakeDefaultSpell(defaultSpell);

        spells = new List<SpellDTO>();

        for (int i = 0; i < 9; i++)
        {
            spells.Add(defaultSpell);
            spellPanel.transform.GetChild(i).GetComponent<SpellData>().SetSpellData(spells[i]);
        }

        SetDefaults();

        needUpdate = false;
    }

    public void SaveInformation(CharacterDTO character)
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject spellSlot = spellPanel.transform.GetChild(i).gameObject;
            spells[i] = spellSlot.GetComponentInChildren<SpellData>().GetSpellData();
        }

        character.Spells = new List<SpellDTO>(spells);
    }

    public void SetDefaults()
    {
        if (spells == null) return;

        for (int i = 0; i < 9; i++)
        {
            GameObject spellSlot = spellPanel.transform.GetChild(i).gameObject;
            if (spellSlot.GetComponentInChildren<SpellData>().GetSpellData().BaseData.Name != "Заклинание не выбранно")
            {
                SpellDataBase spellList = GameObject.Find("SpellList").GetComponent<SpellDataBase>();
                GameObject selectedSpell = spellList.FindSpell(spellSlot.transform.Find("Name").GetComponentInChildren<Text>().text);
                if (selectedSpell != null)
                {
                    selectedSpell.GetComponent<SpellData>().SetIsSelect(false);
                }
                spellList.UpdateInformation();
            }
            spellSlot.GetComponent<SpellData>().SetSpellData(defaultSpell);
        }

        if (currentSpellSlot != null)
        {
            GameObject.Find("SpellList").GetComponent<SpellDataBase>().SetActiveContentPanel(false);

            currentSpellSlot.GetComponentInChildren<Outline>().enabled = false;

            currentSpellSlot = null;
        }

        needUpdate = true;
    }

    public void SetCurrentSpell(GameObject current)
    {
        if (currentSpellSlot != null)
        {
            currentSpellSlot.GetComponentInChildren<Outline>().enabled = false;
        }
        currentSpellSlot = current;
        currentSpellSlot.GetComponentInChildren<Outline>().enabled = true;
    }

    public GameObject GetCurrentSpell()
    {
        return currentSpellSlot;
    }

    private void MakeDefaultSpell(SpellDTO defaultPerk)
    {
        defaultPerk.BaseData.Name = "Заклинание не выбранно";
        defaultPerk.BaseData.Description = "";
        defaultPerk.BaseData.Icon = defaultIcon;
        defaultPerk.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 0,
            [ECharacteristic.Dexterity] = 0,
            [ECharacteristic.Endurance] = 0,
            [ECharacteristic.Fire] = 0,
            [ECharacteristic.Water] = 0,
            [ECharacteristic.Air] = 0,
            [ECharacteristic.Earth] = 0,
        };
        defaultPerk.ManaCost = new Dictionary<EManaType, double>
        {
            [EManaType.EarthStone] = 0,
            [EManaType.FireStone] = 0,
            [EManaType.WaterStone] = 0,
            [EManaType.AirStone] = 0
        };
    }

    public bool IsNeedUpdate()
    {
        return needUpdate;
    }

    public void SetNeedUpdate(bool need)
    {
        needUpdate = need;
    }
}
