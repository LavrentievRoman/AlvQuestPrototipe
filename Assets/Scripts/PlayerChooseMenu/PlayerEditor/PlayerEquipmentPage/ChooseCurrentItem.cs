using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCurrentItem : MonoBehaviour
{
    public GameObject contentPanel;

    private GameObject equipmentSetupPage;

    // Start is called before the first frame update
    void Start()
    {
        equipmentSetupPage = GameObject.Find("PlayerEquipmentPanel");

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { SetCurrentItem(); });
    }

    public void SetCurrentItem()
    {
        equipmentSetupPage.GetComponent<PlayerEquipmentSetup>().SetCurrentItem(gameObject.transform.parent.gameObject);
        ShowCurrentContentPanel();

        if (GameObject.Find("PlayerEquipmentPanel").GetComponent<PlayerEquipmentSetup>().IsNeedUpdate())
        {
            GameObject.Find("EquipmentList").GetComponent<EquipmentDataBase>().UpdateInformation();
        }
    }

    private void ShowCurrentContentPanel()
    {
        GameObject equipmentList = GameObject.Find("EquipmentList");
        GameObject contentList = equipmentList.transform.Find("Viewport").gameObject;

        for (int i = 0; i < 6; i++)
        {
            contentList.transform.GetChild(i).gameObject.SetActive(false);
        }

        contentPanel.SetActive(true);
    }
}
