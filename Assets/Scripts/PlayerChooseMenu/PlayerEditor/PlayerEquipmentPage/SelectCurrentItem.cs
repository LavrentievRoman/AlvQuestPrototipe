using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCurrentItem : MonoBehaviour
{
    private GameObject equipmentSetupPanel;
    // Start is called before the first frame update
    void Start()
    {
        equipmentSetupPanel = GameObject.Find("PlayerEquipmentPanel");

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { SelectItem(); });
    }

    public void SelectItem()
    {
        GameObject currentItem = equipmentSetupPanel.GetComponent<PlayerEquipmentSetup>().GetCurrentItem();
        if (currentItem != null)
        {
            if (currentItem.transform.Find("Name").GetComponentInChildren<Text>().text != "Предмет не выбран")
            {
                UnselectItem(currentItem);
                SetItem(currentItem);
            }
            else
            {
                SetItem(currentItem);
            }
            GameObject.Find("EquipmentList").GetComponent<EquipmentDataBase>().UpdateInformation();
        }      
    }

    private void UnselectItem(GameObject currentItem)
    {
        GameObject item = GameObject.Find("EquipmentList").GetComponent<EquipmentDataBase>().FindItem(currentItem.transform.Find("Name").GetComponentInChildren<Text>().text);
        if (item != null)
        {
            item.GetComponent<ItemData>().SetIsSelect(false);
        }
    }
    private void SetItem(GameObject currentItem)
    {
        GameObject selectedItem = gameObject.transform.parent.gameObject;
        currentItem.GetComponent<ItemData>().SetItemData(selectedItem.GetComponent<ItemData>().GetItemData());

        selectedItem.GetComponent<ItemData>().SetIsSelect(true);
    }
}
