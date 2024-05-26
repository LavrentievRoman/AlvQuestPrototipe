using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowArenaMenu : MonoBehaviour
{

    [SerializeField] private GameObject arenaMenu;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => {
            arenaMenu.SetActive(true);
            transform.parent.gameObject.SetActive(false);});
        
    }
}
