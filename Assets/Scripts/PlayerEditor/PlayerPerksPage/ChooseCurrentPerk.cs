using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCurrentPerk : MonoBehaviour
{
    private GameObject perkSetupPage;

    // Start is called before the first frame update
    void Start()
    {
        perkSetupPage = GameObject.Find("PlayerPerksPanel");

        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate { SetCurrentPerk(); });
    }

    public void SetCurrentPerk()
    {
        perkSetupPage.GetComponent<PlayerPerksSetup>().SetCurrentPerk(gameObject.transform.parent.gameObject);
    }
}
