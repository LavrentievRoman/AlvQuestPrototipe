using UnityEngine;
using UnityEngine.UI;

public class ShowMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    public void Start()
    {      
        Button button = gameObject.GetComponent<Button>();

        // Привязываем событее к кнопке
        button.onClick.AddListener(delegate { Show(); });
    }

    // Показ меню
    private void Show()
    {
        // Делаем меню активным
        menu.SetActive(true);

        // Скрываем текущее меню
        transform.parent.gameObject.SetActive(false);
    }
}
