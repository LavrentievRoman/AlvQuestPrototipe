using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPerksSetup : MonoBehaviour
{
    public PerkDTO defaultPerk;
    public Sprite defaultIcon;

    private GameObject currentPerkSelect;
    private GameObject perkPanel;

    private List<PerkDTO> perks;

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
        }

        SetDefault();
    }

    public void SaveInformation()
    {

    }

    public void SetDefault()
    {
        for (int i = 0; i < 6; i++)
        {
            perkPanel.transform.GetChild(i).GetComponent<PerkData>().SetPerkData(defaultPerk);
        }
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
}
