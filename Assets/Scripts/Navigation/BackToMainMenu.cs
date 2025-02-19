using UnityEngine;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;

    public void Start()
    {
        Button button = gameObject.GetComponent<Button>();

        // Привязываем событее к кнопке
        button.onClick.AddListener(delegate { ShowMenu(); });
    }

    // Показ меню
    private void ShowMenu()
    {
        // Делаем основное меню активным
        mainMenu.SetActive(true);

        // Скрываем текущее меню
        transform.parent.gameObject.SetActive(false);
    }
}
