using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCurrentPerk : MonoBehaviour
{
    private GameObject perkSetupPage;
    // Start is called before the first frame update
    void Start()
    {
        perkSetupPage = GameObject.Find("PlayerPerksPanel");

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { SelectPerk(); });
    }

    public void SelectPerk()
    {
        GameObject currentPerk = perkSetupPage.GetComponent<PlayerPerksSetup>().GetCurrentPerk();
        if (currentPerk != null) 
        {
            if (currentPerk.transform.Find("Name").GetComponentInChildren<Text>().text != "Перк не выбран")
            {
                UnselectPerk(currentPerk);
                SetPerk(currentPerk);
            }    
            else
            {
                SetPerk(currentPerk);
            }          
            GameObject.Find("PerkList").GetComponent<PerksDataBase>().UpdateInformation();
        }     
    }

    private void UnselectPerk(GameObject currentPerk)
    {
        GameObject perk = GameObject.Find("PerkList").GetComponent<PerksDataBase>().FindPerk(currentPerk.transform.Find("Name").GetComponentInChildren<Text>().text);
        if (perk != null) 
        {
            perk.GetComponent<PerkData>().SetIsSelect(false);
        }
    }
    private void SetPerk(GameObject currentPerk)
    {
        GameObject selectedPerk = gameObject.transform.parent.gameObject;
        currentPerk.GetComponent<PerkData>().SetPerkData(selectedPerk.GetComponent<PerkData>().GetPerkData());

        selectedPerk.GetComponent<PerkData>().SetIsSelect(true);
    }
}
