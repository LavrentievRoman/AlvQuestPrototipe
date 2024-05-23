using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCurrentSpell : MonoBehaviour
{
    private GameObject spellSetupPage;

    void Start()
    {
        spellSetupPage = GameObject.Find("PlayerSpellPanel");

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { SetCurrentSpell(); });
    }

    public void SetCurrentSpell()
    {
        spellSetupPage.GetComponent<PlayerSpellsSetup>().SetCurrentSpell(gameObject.transform.parent.gameObject);
        GameObject.Find("SpellList").GetComponent<SpellDataBase>().SetActiveContentPanel(true);

        if (spellSetupPage.GetComponent<PlayerSpellsSetup>().IsNeedUpdate())
        {
            GameObject.Find("SpellList").GetComponent<SpellDataBase>().UpdateInformation();
        }
    }
}
