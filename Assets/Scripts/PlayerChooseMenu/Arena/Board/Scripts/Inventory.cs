using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AlvQuestCore;
using AlvQuest_Editor;

public class Inventory : MonoBehaviour
{
    public static Inventory Singleton;
    public static InventoryItem carriedItem;

    [SerializeField] InventorySlot[] inventorySlots;
    //[SerializeField] InventorySlot[] hotbarSlots;

    // 0=Head, 1=Chest, 2=Legs, 3=Feet
    //[SerializeField] InventorySlot[] equipmentSlots;

    [SerializeField] Transform draggablesTransform;
    [SerializeField] InventoryItem itemPrefab;

    [Header("Item List")]
    [SerializeField] Item[] items;

    [Header("Debug")]
    [SerializeField] Button giveItemBtn;

    void Awake()
    {
        Singleton = this;
       
    }

    private void Start()
    {
        giveItemBtn.onClick.AddListener(delegate { SpawnInventoryItems(); });
    }

    void Update()
    {
        if(carriedItem == null) return;

        carriedItem.transform.position = Input.mousePosition;

    }

    public void SetCarriedItem(InventoryItem item)
    {
        if(carriedItem != null && StoneBoard.Instance.StoneClick((int)item.Position.x, (int)item.Position.y))
        {
            //if(item.activeSlot.myTag != SlotTag.None && item.activeSlot.myTag != carriedItem.myItem.itemTag) return;
            item.activeSlot.SetItem(carriedItem);
        }


        else if (carriedItem == null)
        {
            carriedItem = item;
            carriedItem.canvasGroup.blocksRaycasts = false;
            item.transform.SetParent(draggablesTransform);
        }

    }

    /*public void EquipEquipment(SlotTag tag, InventoryItem item = null)
    {
        switch (tag)
        {
            case SlotTag.Head:
                if(item == null)
                {
                    // Destroy item.equipmentPrefab on the Player Object;
                    Debug.Log("Unequipped helmet on " + tag);
                }
                else
                {
                    // Instantiate item.equipmentPrefab on the Player Object;
                    Debug.Log("Equipped " + item.myItem.name + " on " + tag);
                }
                break;
            case SlotTag.Chest:
                break;
            case SlotTag.Legs:
                break;
            case SlotTag.Feet:
                break;
        }
    }*/

    public void SpawnInventoryItem(Item item = null)
    {
        Item _item = item;
        if(_item == null)
        { _item = PickRandomItem(); }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            // Check if the slot is empty
            if(inventorySlots[i].myItem == null)
            {
                InventoryItem inventoryItem = Instantiate(itemPrefab, inventorySlots[i].transform);
                inventoryItem.transform.localPosition = Vector3.zero;
                inventoryItem.Initialize(_item, inventorySlots[i], new());
                break;
            }
        }
    }

    public void SpawnInventoryItems(Item item = null)
    {
        foreach (var slot in inventorySlots)
        {
            if(slot.myItem != null)
            {
                Destroy(slot.myItem.gameObject);
            }
        }

        int iters = 0;

        Item _item;

        StoneBoard.Instance.ResetStoneGrid();

        for (int i = 0; i < AlvQuestStatic.STONE_GRID_SIZE; i++)
        {
            for (int j = 0; j < AlvQuestStatic.STONE_GRID_SIZE; j++)
            {
                foreach (var stone in items)
                {
                    // Check if the slot is empty
                    if (stone.stoneType.ToString() == StoneBoard.Instance.StoneGrid[i,j].ToString())
                    {
                        _item = stone;
                        InventoryItem inventoryItem = Instantiate(itemPrefab, inventorySlots[iters].transform);
                        inventoryItem.transform.localPosition = Vector3.zero;
                        inventoryItem.Initialize(_item, inventorySlots[iters], new(i,j));
                        iters++;
                        break;
                    }
                }

            }

        }
        Debug.Log("Items spawned");
    }

    public void DebugStoneGrid()
    {
        StoneBoard.Instance.ResetStoneGrid();
    }

    public void ShowStoneGrid()
    {
        StoneBoard.Instance.ResetStoneGrid();
        StoneBoard.Instance.StoneGrid.ToString();
    }

    Item PickRandomItem()
    {
        int random = Random.Range(0, items.Length);
        return items[random];
    }

    public void CreateItem(Item item, InventorySlot slot, Vector2 position)
    {
        InventoryItem inventoryItem = Instantiate(itemPrefab, slot.transform);
        inventoryItem.transform.localPosition = Vector3.zero;
        inventoryItem.Initialize(item, slot, position);
    }

    private void SwapInventoryItems(InventoryItem item1, InventoryItem item2)
    {
        (item1.Position, item2.Position) = (item2.Position, item1.Position);
        (item1.activeSlot, item2.activeSlot) = (item2.activeSlot, item2.activeSlot);
        (item1.activeSlot.myItem, item2.activeSlot.myItem) = (item2, item1);
/*
        InventorySlot tempSlot = item1.activeSlot;
        item1.activeSlot = item2.activeSlot;
        item2.activeSlot = tempSlot;

        item1.activeSlot.myItem = item1;
        item2.activeSlot.myItem = item2;*/

        item1.transform.SetParent(item1.activeSlot.transform);
        item2.transform.SetParent(item2.activeSlot.transform);

        item1.transform.localPosition = Vector3.zero;
        item2.transform.localPosition = Vector3.zero;

        carriedItem = null;
    }
}
