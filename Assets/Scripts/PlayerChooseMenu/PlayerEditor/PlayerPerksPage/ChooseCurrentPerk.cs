using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCurrentPerk : MonoBehaviour
{
    private GameObject perkSetupPage;

    void Start()
    {
        perkSetupPage = GameObject.Find("PlayerPerksPanel");

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { SetCurrentPerk(); });
    }

    public void SetCurrentPerk()
    {
        perkSetupPage.GetComponent<PlayerPerksSetup>().SetCurrentPerk(gameObject.transform.parent.gameObject);
        GameObject.Find("PerkList").GetComponent<PerksDataBase>().SetActiveContentPanel(true);

        if (perkSetupPage.GetComponent<PlayerPerksSetup>().IsNeedUpdate())
        {
            GameObject.Find("PerkList").GetComponent<PerksDataBase>().UpdateInformation();
        }
    }
}
