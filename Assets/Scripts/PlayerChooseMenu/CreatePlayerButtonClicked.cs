using UnityEngine;
using UnityEngine.UI;

public class CreatePlayerButtonClicked : MonoBehaviour
{
    [SerializeField]
    private GameObject playerEditor;

    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        
        // �������� ������� � ������ 
        button.onClick.AddListener(delegate { OpenPlayerEditor(); });
    }

    // ����� ��������� ���������
    private void OpenPlayerEditor()
    {
        playerEditor.SetActive(true);
    }
}
