using UnityEngine;
using UnityEngine.UI;

public class CreatePlayerButtonClicked : MonoBehaviour
{
    [SerializeField]
    private GameObject playerEditor;

    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        
        // Привязка события к кнопке 
        button.onClick.AddListener(delegate { OpenPlayerEditor(); });
    }

    // Показ редактора персонажа
    private void OpenPlayerEditor()
    {
        playerEditor.SetActive(true);
    }
}
