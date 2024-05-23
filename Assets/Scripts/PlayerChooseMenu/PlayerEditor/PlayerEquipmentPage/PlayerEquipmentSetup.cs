using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipmentSetup : MonoBehaviour
{
    public EquipmentDTO defaultEquipment;
    public Sprite defaultIcon;

    private GameObject currentImemSlot;
    private GameObject equipmentPanel;

    private Dictionary<EBodyPart, EquipmentDTO> equipment;

    private bool needUpdate;

    // Start is called before the first frame update
    void Start()
    {
        equipmentPanel = gameObject.transform.Find("EquipmentButtonPanel").gameObject;

        defaultEquipment = MakeDefaultEquipment();

        equipment = new Dictionary<EBodyPart, EquipmentDTO>();

        equipment = new Dictionary<EBodyPart, EquipmentDTO>
        {
            [EBodyPart.Head] = defaultEquipment,
            [EBodyPart.Body] = defaultEquipment,
            [EBodyPart.Hands] = defaultEquipment,
            [EBodyPart.Feet] = defaultEquipment,
            [EBodyPart.Weapon] = defaultEquipment,
            [EBodyPart.Extra] = defaultEquipment
        };

        for (int i = 0; i < 6; i++)
        {
            equipmentPanel.transform.GetChild(i).GetComponent<ItemData>().SetItemData(defaultEquipment);
        }

        SetDefaults();

        needUpdate = false;
    }

    public void SaveInformation(CharacterDTO character)
    {
        character.Equipment = equipment;
    }

    public void SetDefaults()
    {
        if (equipment == null)
        {
            return;
        }

            for (int i = 0; i < 6; i++)
        {
            GameObject itemSlot = equipmentPanel.transform.GetChild(i).gameObject;
            if (itemSlot.GetComponentInChildren<ItemData>().GetItemData().BaseData.Name != "Предмет не выбран")
            {
                EquipmentDataBase equipmentList = GameObject.Find("EquipmentList").GetComponent<EquipmentDataBase>();
                GameObject selectedItem = equipmentList.FindItem(itemSlot.transform.Find("Name").GetComponentInChildren<Text>().text);
                if (selectedItem != null)
                {
                    selectedItem.GetComponent<ItemData>().SetIsSelect(false);
                }
                equipmentList.UpdateInformation();
            }
            itemSlot.GetComponent<ItemData>().SetItemData(defaultEquipment);
        }

        if (currentImemSlot != null)
        {
            currentImemSlot.transform.Find("Item").GetComponent<ChooseCurrentItem>().contentPanel.SetActive(false);

            currentImemSlot.GetComponentInChildren<Outline>().enabled = false;

            currentImemSlot = null;
        }

        needUpdate = true;
    }

    public void SetCurrentItem(GameObject current)
    {
        if (currentImemSlot != null)
        {
            currentImemSlot.GetComponentInChildren<Outline>().enabled = false;
        }
        currentImemSlot = current;
        currentImemSlot.GetComponentInChildren<Outline>().enabled = true;
    }

    public GameObject GetCurrentItem()
    {
        return currentImemSlot;
    }

    private EquipmentDTO MakeDefaultEquipment()
    {
        EquipmentDTO defaultItem = new EquipmentDTO();
        defaultItem.BaseData.Name = "Предмет не выбран";
        defaultItem.BaseData.Description = "";
        defaultItem.BaseData.Icon = defaultIcon;
        defaultItem.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 0,
            [ECharacteristic.Dexterity] = 0,
            [ECharacteristic.Endurance] = 0,
            [ECharacteristic.Fire] = 0,
            [ECharacteristic.Water] = 0,
            [ECharacteristic.Air] = 0,
            [ECharacteristic.Earth] = 0,
        };

        return defaultItem;
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
