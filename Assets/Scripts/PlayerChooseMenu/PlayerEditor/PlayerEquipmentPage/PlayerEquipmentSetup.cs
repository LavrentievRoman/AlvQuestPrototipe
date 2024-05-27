using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipmentSetup : MonoBehaviour
{  
    public Sprite defaultIcon;

    private GameObject currentImemSlot;
    private GameObject equipmentPanel;

    private Dictionary<EBodyPart, EquipmentDTO> defaultEquipment;
    private Dictionary<EBodyPart, EquipmentDTO> equipment;

    private bool needUpdate;

    // Start is called before the first frame update
    void Start()
    {
        equipmentPanel = gameObject.transform.Find("EquipmentButtonPanel").gameObject;

        defaultEquipment = MakeDefaultEquipment();

        equipment = new Dictionary<EBodyPart, EquipmentDTO>(defaultEquipment);

        for (int i = 0; i < 6; i++)
        {          
            switch (i)
            {
                case 0: equipmentPanel.transform.GetChild(i).GetComponent<ItemData>().SetItemData(defaultEquipment[EBodyPart.Head]); break;
                case 1: equipmentPanel.transform.GetChild(i).GetComponent<ItemData>().SetItemData(defaultEquipment[EBodyPart.Body]); break;
                case 2: equipmentPanel.transform.GetChild(i).GetComponent<ItemData>().SetItemData(defaultEquipment[EBodyPart.Hands]); break;
                case 3: equipmentPanel.transform.GetChild(i).GetComponent<ItemData>().SetItemData(defaultEquipment[EBodyPart.Feet]); break;
                case 4: equipmentPanel.transform.GetChild(i).GetComponent<ItemData>().SetItemData(defaultEquipment[EBodyPart.Weapon]); break;
                case 5: equipmentPanel.transform.GetChild(i).GetComponent<ItemData>().SetItemData(defaultEquipment[EBodyPart.Extra]); break;
            }
        }

        SetDefaults();

        needUpdate = false;
    }

    public void SaveInformation(CharacterDTO character)
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject itemSlot = equipmentPanel.transform.GetChild(i).gameObject;
            switch(itemSlot.GetComponentInChildren<ItemData>().GetItemData().BodyPart)
            {
                case EBodyPart.Head:
                    Debug.Log(itemSlot.GetComponentInChildren<ItemData>().GetItemData().BaseData.Name);
                    equipment[EBodyPart.Head] = itemSlot.GetComponentInChildren<ItemData>().GetItemData();
                    break;
                case EBodyPart.Body:
                    equipment[EBodyPart.Body] = itemSlot.GetComponentInChildren<ItemData>().GetItemData();
                    break;
                case EBodyPart.Hands:
                    equipment[EBodyPart.Hands] = itemSlot.GetComponentInChildren<ItemData>().GetItemData();
                    break;
                case EBodyPart.Feet:
                    equipment[EBodyPart.Feet] = itemSlot.GetComponentInChildren<ItemData>().GetItemData();
                    break;
                case EBodyPart.Weapon:
                    equipment[EBodyPart.Weapon] = itemSlot.GetComponentInChildren<ItemData>().GetItemData();
                    break;
                case EBodyPart.Extra:
                    equipment[EBodyPart.Extra] = itemSlot.GetComponentInChildren<ItemData>().GetItemData();
                    break;
            }
            
        }   

        character.Equipment = new Dictionary<EBodyPart, EquipmentDTO>(equipment);
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

            switch (i)
            {
                case 0: itemSlot.GetComponent<ItemData>().SetItemData(defaultEquipment[EBodyPart.Head]); break;
                case 1: itemSlot.GetComponent<ItemData>().SetItemData(defaultEquipment[EBodyPart.Body]); break;
                case 2: itemSlot.GetComponent<ItemData>().SetItemData(defaultEquipment[EBodyPart.Hands]); break;
                case 3: itemSlot.GetComponent<ItemData>().SetItemData(defaultEquipment[EBodyPart.Feet]); break;
                case 4: itemSlot.GetComponent<ItemData>().SetItemData(defaultEquipment[EBodyPart.Weapon]); break;
                case 5: itemSlot.GetComponent<ItemData>().SetItemData(defaultEquipment[EBodyPart.Extra]); break;
            }
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

    public bool IsNeedUpdate()
    {
        return needUpdate;
    }

    public void SetNeedUpdate(bool need)
    {
        needUpdate = need;
    }

    private Dictionary<EBodyPart, EquipmentDTO> MakeDefaultEquipment()
    {
        Dictionary<EBodyPart, EquipmentDTO> defaultEq = new Dictionary<EBodyPart, EquipmentDTO>();

        for (int i = 0; i < 6; i++)
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

            switch (i)
            {
                case 0: defaultItem.BodyPart = EBodyPart.Head; defaultEq[EBodyPart.Head] = defaultItem; break;
                case 1: defaultItem.BodyPart = EBodyPart.Body; defaultEq[EBodyPart.Body] = defaultItem; break;
                case 2: defaultItem.BodyPart = EBodyPart.Hands; defaultEq[EBodyPart.Hands] = defaultItem; break;
                case 3: defaultItem.BodyPart = EBodyPart.Feet; defaultEq[EBodyPart.Feet] = defaultItem; break;
                case 4: defaultItem.BodyPart = EBodyPart.Weapon; defaultEq[EBodyPart.Weapon] = defaultItem; break;
                case 5: defaultItem.BodyPart = EBodyPart.Extra; defaultEq[EBodyPart.Extra] = defaultItem; break;
            }
        }
        return defaultEq;
    }
}
