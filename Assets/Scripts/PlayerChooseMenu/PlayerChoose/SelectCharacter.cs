using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    private ShowPlayerCard playerCard;

    private GameObject _selectedCharacter;
    public GameObject SelectedCharacterCard 
    {
        get
        {
            return _selectedCharacter;
        }
        set
        {
            // ������� ��������� � ����������� ���������� ���������
            if (_selectedCharacter != null)
            {
                _selectedCharacter.GetComponentInChildren<Outline>().enabled = false;
            }

            // �������� �������� ���������� ���������
            _selectedCharacter = value;
            _selectedCharacter.GetComponentInChildren<Outline>().enabled = true;

            // ���������� ���������� � ��������� �� ��������
            playerCard.ShowCharacter(_selectedCharacter.GetComponent<CharacterData>().Character);
        }
    }  

    private void Start()
    {
        playerCard = GameObjectManager.Instance.Objects["PlayerCard"].GetComponent<ShowPlayerCard>();
    }
}
