using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCurrentSpell : MonoBehaviour
{
    private GameObject spellSetupPage;
    // Start is called before the first frame update
    void Start()
    {
        spellSetupPage = GameObject.Find("PlayerSpellPanel");

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { SelectSpell(); });
    }

    public void SelectSpell()
    {
        GameObject currentSpell = spellSetupPage.GetComponent<PlayerSpellsSetup>().GetCurrentSpell();
        if (currentSpell != null)
        {
            if (currentSpell.transform.Find("Name").GetComponentInChildren<Text>().text != "Заклинание не выбранно")
            {
                UnselectSpell(currentSpell);
                SetSpell(currentSpell);
            }
            else
            {
                SetSpell(currentSpell);
            }
            GameObject.Find("SpellList").GetComponent<SpellDataBase>().UpdateInformation();
        }
    }

    private void UnselectSpell(GameObject currentSpell)
    {
        GameObject spell = GameObject.Find("SpellList").GetComponent<SpellDataBase>().FindSpell(currentSpell.transform.Find("Name").GetComponentInChildren<Text>().text);
        if (spell != null)
        {
            spell.GetComponent<SpellData>().SetIsSelect(false);
        }
    }
    private void SetSpell(GameObject currentPerk)
    {
        GameObject selectedSpell = gameObject.transform.parent.gameObject;
        currentPerk.GetComponent<SpellData>().SetSpellData(selectedSpell.GetComponent<SpellData>().GetSpellData());

        selectedSpell.GetComponent<SpellData>().SetIsSelect(true);
    }
}
