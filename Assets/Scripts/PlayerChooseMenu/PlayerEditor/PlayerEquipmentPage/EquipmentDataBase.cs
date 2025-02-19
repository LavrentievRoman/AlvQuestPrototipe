using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentDataBase : MonoBehaviour
{
    public GameObject itemForList;
    public GameObject contentList;

    private List<List<EquipmentDTO>> equipmentDataBase;
    private List<EquipmentDTO> HeadItemDataBase;
    private List<EquipmentDTO> BodyItemDataBase;
    private List<EquipmentDTO> HandItemDataBase;
    private List<EquipmentDTO> FeetItemDataBase;
    private List<EquipmentDTO> WeaponItemDataBase;
    private List<EquipmentDTO> ExtraItemDataBase;

    public GameObject FindItem(string name)
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject currentContentPanel = contentList.transform.GetChild(i).gameObject;
            for (int j = 0; j < equipmentDataBase[i].Count; j++)
            {
                if (currentContentPanel.transform.GetChild(j).Find("Name").GetComponentInChildren<Text>().text == name)
                {
                    return currentContentPanel.transform.GetChild(j).gameObject;
                }
            }           
        }
        return null;
    }

    public void UpdateInformation()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject currentContentPanel = contentList.transform.GetChild(i).gameObject;
            for (int j = 0; j < equipmentDataBase[i].Count; j++)
            {
                bool isSelect = currentContentPanel.transform.GetChild(j).GetComponent<ItemData>().IsSelect();
                bool isApply = CheckPlayerСharacteristic(currentContentPanel.transform.GetChild(j).GetComponent<ItemData>().GetItemData());

                if (!isSelect && isApply)
                {
                    currentContentPanel.transform.GetChild(j).Find("Name").GetComponent<Button>().interactable = true;
                }
                if (isSelect || !isApply)
                {
                    currentContentPanel.transform.GetChild(j).Find("Name").GetComponent<Button>().interactable = false;
                }
            }
        }
        GameObject.Find("PlayerEquipmentPanel").GetComponent<PlayerEquipmentSetup>().SetNeedUpdate(false);
    } 

    private void Start()
    {
        FillDataBase();       

        AddGraphics();
    }

    private void AddGraphics()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject currentContentPanel = contentList.transform.GetChild(i).gameObject;      
            for (int j = 0; j < equipmentDataBase[i].Count; j++)
            {
                GameObject newItem = Instantiate(itemForList, currentContentPanel.transform) as GameObject;

                newItem.name = "Item" + (j + 1).ToString();
                newItem.GetComponent<ItemData>().SetItemData(equipmentDataBase[i][j]);

                RectTransform rt = newItem.GetComponent<RectTransform>();
                rt.localPosition = new Vector3(0, 0, 0);
                rt.localScale = new Vector3(1, 1, 1);
                newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }
        UpdateInformation();
    }

    private bool CheckPlayerСharacteristic(EquipmentDTO item)
    {
        Dictionary<ECharacteristic, int> characteristic = GameObject.Find("PlayerEditor").GetComponent<PlayerEditor>().CustomPlayer.Characteristics;

        if (item.RequirementsForUse[ECharacteristic.Strength] > characteristic[ECharacteristic.Strength])
        {
            return false;
        }
        if (item.RequirementsForUse[ECharacteristic.Dexterity] > characteristic[ECharacteristic.Dexterity])
        {
            return false;
        }
        if (item.RequirementsForUse[ECharacteristic.Endurance] > characteristic[ECharacteristic.Endurance])
        {
            return false;
        }
        if (item.RequirementsForUse[ECharacteristic.Fire] > characteristic[ECharacteristic.Fire])
        {
            return false;
        }
        if (item.RequirementsForUse[ECharacteristic.Water] > characteristic[ECharacteristic.Water])
        {
            return false;
        }
        if (item.RequirementsForUse[ECharacteristic.Air] > characteristic[ECharacteristic.Air])
        {
            return false;
        }
        if (item.RequirementsForUse[ECharacteristic.Earth] > characteristic[ECharacteristic.Earth])
        {
            return false;
        }
        return true;
    }

    private void FillDataBase()
    {
        FillHeadItemDataBase();
        FillBodyItemDataBase();
        FillHandItemDataBase();
        FillFeetItemDataBase();
        FillWeaponItemDataBase();
        FillExtraItemDataBase();

        equipmentDataBase = new List<List<EquipmentDTO>>
        {
            HeadItemDataBase,
            BodyItemDataBase,
            HandItemDataBase,
            FeetItemDataBase,
            WeaponItemDataBase,
            ExtraItemDataBase
        };
    }

    private void FillHeadItemDataBase()
    {
        HeadItemDataBase = new List<EquipmentDTO>();

        EquipmentDTO newItem = new EquipmentDTO();

        newItem.BaseData.Name = "Шлем 1";
        newItem.BaseData.Description = "Описание шлема 1";
        //newItem.BaseData.Icon = Head1;
        newItem.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 5,
            [ECharacteristic.Dexterity] = 9,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };
        newItem.BodyPart = EBodyPart.Head;

        HeadItemDataBase.Add(newItem);

        newItem = new EquipmentDTO();

        newItem.BaseData.Name = "Шлем 2";
        newItem.BaseData.Description = "Описание шлема 2";
        //newItem.BaseData.Icon = Head2;
        newItem.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 9,
            [ECharacteristic.Dexterity] = 5,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };
        newItem.BodyPart = EBodyPart.Head;

        HeadItemDataBase.Add(newItem);
    }

    private void FillBodyItemDataBase()
    {
        BodyItemDataBase = new List<EquipmentDTO>();

        EquipmentDTO newItem = new EquipmentDTO();

        newItem.BaseData.Name = "Нагрудник 1";
        newItem.BaseData.Description = "Описание нагрудника 1";
        //newItem.BaseData.Icon = Body1;
        newItem.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 5,
            [ECharacteristic.Dexterity] = 9,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };
        newItem.BodyPart = EBodyPart.Body;

        BodyItemDataBase.Add(newItem);

        newItem = new EquipmentDTO();

        newItem.BaseData.Name = "Нагрудник 2";
        newItem.BaseData.Description = "Описание нагрудника 2";
        //newItem.BaseData.Icon = Body2;
        newItem.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 9,
            [ECharacteristic.Dexterity] = 5,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };
        newItem.BodyPart = EBodyPart.Body;

        BodyItemDataBase.Add(newItem);
    }

    private void FillHandItemDataBase()
    {
        HandItemDataBase = new List<EquipmentDTO>();

        EquipmentDTO newItem = new EquipmentDTO();

        newItem.BaseData.Name = "Наручи 1";
        newItem.BaseData.Description = "Описание наручей 1";
        //newItem.BaseData.Icon = Hands1;
        newItem.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 5,
            [ECharacteristic.Dexterity] = 9,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };
        newItem.BodyPart = EBodyPart.Hands;

        HandItemDataBase.Add(newItem);

        newItem = new EquipmentDTO();

        newItem.BaseData.Name = "Наручи 2";
        newItem.BaseData.Description = "Описание наручей 2";
        //newItem.BaseData.Icon = Hands2;
        newItem.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 9,
            [ECharacteristic.Dexterity] = 5,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };
        newItem.BodyPart = EBodyPart.Hands;

        HandItemDataBase.Add(newItem);
    }

    private void FillFeetItemDataBase()
    {
        FeetItemDataBase = new List<EquipmentDTO>();

        EquipmentDTO newItem = new EquipmentDTO();

        newItem.BaseData.Name = "Ботинки 1";
        newItem.BaseData.Description = "Описание ботинок 1";
        //newItem.BaseData.Icon = Feet1;
        newItem.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 5,
            [ECharacteristic.Dexterity] = 9,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };
        newItem.BodyPart = EBodyPart.Feet;

        FeetItemDataBase.Add(newItem);

        newItem = new EquipmentDTO();

        newItem.BaseData.Name = "Ботинки 2";
        newItem.BaseData.Description = "Описание ботинок 2";
        //newItem.BaseData.Icon = Feet2;
        newItem.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 9,
            [ECharacteristic.Dexterity] = 5,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };
        newItem.BodyPart = EBodyPart.Feet;

        FeetItemDataBase.Add(newItem);
    }

    private void FillWeaponItemDataBase()
    {
        WeaponItemDataBase = new List<EquipmentDTO>();

        EquipmentDTO newItem = new EquipmentDTO();

        newItem.BaseData.Name = "Оружее 1";
        newItem.BaseData.Description = "Описание оружия 1";
        //newItem.BaseData.Icon = Weapon1;
        newItem.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 5,
            [ECharacteristic.Dexterity] = 9,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };
        newItem.BodyPart = EBodyPart.Weapon;

        WeaponItemDataBase.Add(newItem);

        newItem = new EquipmentDTO();

        newItem.BaseData.Name = "Оружее 2";
        newItem.BaseData.Description = "Описание оружия 2";
        //newItem.BaseData.Icon = Weapon2;
        newItem.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 9,
            [ECharacteristic.Dexterity] = 5,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };
        newItem.BodyPart = EBodyPart.Weapon;

        WeaponItemDataBase.Add(newItem);
    }

    private void FillExtraItemDataBase()
    {
        ExtraItemDataBase = new List<EquipmentDTO>();

        EquipmentDTO newItem = new EquipmentDTO();

        newItem.BaseData.Name = "Экстра 1";
        newItem.BaseData.Description = "Описание экстра 1";
        //newItem.BaseData.Icon = Extra1;
        newItem.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 5,
            [ECharacteristic.Dexterity] = 9,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };
        newItem.BodyPart = EBodyPart.Extra;

        ExtraItemDataBase.Add(newItem);

        newItem = new EquipmentDTO();

        newItem.BaseData.Name = "Экстра 2";
        newItem.BaseData.Description = "Описание экстра 2";
        //newItem.BaseData.Icon = Extra2;
        newItem.RequirementsForUse = new Dictionary<ECharacteristic, int>()
        {
            [ECharacteristic.Strength] = 9,
            [ECharacteristic.Dexterity] = 5,
            [ECharacteristic.Endurance] = 5,
            [ECharacteristic.Fire] = 5,
            [ECharacteristic.Water] = 5,
            [ECharacteristic.Air] = 5,
            [ECharacteristic.Earth] = 5,
        };
        newItem.BodyPart = EBodyPart.Extra;

        ExtraItemDataBase.Add(newItem);
    }
}
