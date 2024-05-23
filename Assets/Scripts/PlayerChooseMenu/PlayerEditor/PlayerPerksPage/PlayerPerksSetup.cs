using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPerksSetup : MonoBehaviour
{
    public PerkDTO defaultPerk;
    public Sprite defaultIcon;

    private GameObject currentPerkSelect;
    private GameObject perkPanel;

    private List<PerkDTO> perks;

    private bool needUpdate;

    // Start is called before the first frame update
    void Start()
    {
        perkPanel = gameObject.transform.Find("PerkButtonPanel").gameObject;

        defaultPerk = new PerkDTO();
        MakeDefaultPerk(defaultPerk);

        perks = new List<PerkDTO>();

        for (int i = 0; i < 6; i++)
        {
            perks.Add(defaultPerk);
            perkPanel.transform.GetChild(i).GetComponent<PerkData>().SetPerkData(perks[i]);
        }

        SetDefaults();

        needUpdate = false;
    }

    public void SaveInformation(CharacterDTO character)
    {
        character.Perks = perks;
    }

    public void SetDefaults()
    {
        if (perks == null) return;

        for (int i = 0; i < 6; i++)
        {
            GameObject perkSlot = perkPanel.transform.GetChild(i).gameObject;
            if (perkSlot.GetComponentInChildren<PerkData>().GetPerkData().BaseData.Name != "Перк не выбран")
            {
                PerksDataBase perklist = GameObject.Find("PerkList").GetComponent<PerksDataBase>();
                GameObject selectedPerk = perklist.FindPerk(perkSlot.transform.Find("Name").GetComponentInChildren<Text>().text);
                if (selectedPerk != null)
                {
                    selectedPerk.GetComponent<PerkData>().SetIsSelect(false);
                }
                perklist.UpdateInformation();
            }
            perkSlot.GetComponent<PerkData>().SetPerkData(defaultPerk);
        }

        if (currentPerkSelect != null)
        {
            GameObject.Find("PerkList").GetComponent<PerksDataBase>().SetActiveContentPanel(false);

            currentPerkSelect.GetComponentInChildren<Outline>().enabled = false;

            currentPerkSelect = null;
        }

        needUpdate = true;
    }

    public void SetCurrentPerk(GameObject current)
    {
        if(currentPerkSelect != null)
        {
            currentPerkSelect.GetComponentInChildren<Outline>().enabled = false;
        }
        currentPerkSelect = current;
        currentPerkSelect.GetComponentInChildren<Outline>().enabled = true;
    }

    public GameObject GetCurrentPerk()
    {
        return currentPerkSelect;
    }

    private void MakeDefaultPerk(PerkDTO defaultPerk)
    {
        defaultPerk.BaseData.Name = "Перк не выбран";
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
