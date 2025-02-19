using AlvQuest_Editor;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacteristicSetup : MonoBehaviour, IPlayerSetup
{
    [SerializeField] private int defaultStrengthValue = 5;
    [SerializeField] private int defaultDexterityValue = 5;
    [SerializeField] private int defaultEnduranceValue = 5;
    [SerializeField] private int defaultFireMasteryValue = 5;
    [SerializeField] private int defaultEarthMasteryValue = 5;
    [SerializeField] private int defaultAirMasteryValue = 5;
    [SerializeField] private int defaultWaterMasteryValue = 5;

    [SerializeField] private GameObject cpValue;
    [SerializeField] private GameObject strengthValue;
    [SerializeField] private GameObject dexterityValue;
    [SerializeField] private GameObject enduranceValue;
    [SerializeField] private GameObject fireMasteryValue;
    [SerializeField] private GameObject earthMasteryValue;
    [SerializeField] private GameObject airMasteryValue;
    [SerializeField] private GameObject waterMasteryValue;

    public int AvailableCP
    {
        get
        {
            return editor.CustomPlayer.CharPoints;
        }
        set
        {
            // ��������� �������� ��������� ����� ������� � ��������� � �� ������
            editor.CustomPlayer.CharPoints = value;
            cpValue.GetComponentInChildren<Text>().text = editor.CustomPlayer.CharPoints.ToString();
        }
    }

    private PlayerEditor editor; 

    private Dictionary<ECharacteristic, int> characteristics;

    public void Awake()
    {
        editor = GetComponentInParent<PlayerEditor>();

        characteristics = new Dictionary<ECharacteristic, int>
        {
            { ECharacteristic.Strength, defaultStrengthValue },
            { ECharacteristic.Dexterity, defaultDexterityValue },
            { ECharacteristic.Endurance, defaultEnduranceValue },
            { ECharacteristic.Fire, defaultFireMasteryValue },
            { ECharacteristic.Water, defaultWaterMasteryValue },
            { ECharacteristic.Air, defaultAirMasteryValue },
            { ECharacteristic.Earth, defaultEarthMasteryValue }
        };

        SetDefaults();
    }

    void OnEnable()
    {
        AvailableCP = editor.CustomPlayer.CharPoints;
    }

    // ���������� ����������
    public void SaveInformation(CharacterDTO character)
    {
        // ��������� �������� ����������
        characteristics[ECharacteristic.Strength] = int.Parse(strengthValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Dexterity] = int.Parse(dexterityValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Endurance] = int.Parse(enduranceValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Fire] = int.Parse(fireMasteryValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Water] = int.Parse(waterMasteryValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Air] = int.Parse(airMasteryValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Earth] = int.Parse(earthMasteryValue.GetComponentInChildren<Text>().text);

        // ������� ��������� ��� ��������, � ��� �� ���������� ���������� ����� �������
        character.Characteristics = new Dictionary<ECharacteristic, int>(characteristics);
        character.CharPoints = AvailableCP;
    }

    // ��������� �������� �� ���������
    public void SetDefaults()
    {
        strengthValue.GetComponentInChildren<Text>().text = defaultStrengthValue.ToString();
        dexterityValue.GetComponentInChildren<Text>().text = defaultDexterityValue.ToString();
        enduranceValue.GetComponentInChildren<Text>().text = defaultEnduranceValue.ToString();
        fireMasteryValue.GetComponentInChildren<Text>().text = defaultFireMasteryValue.ToString();
        waterMasteryValue.GetComponentInChildren<Text>().text = defaultWaterMasteryValue.ToString();
        airMasteryValue.GetComponentInChildren<Text>().text = defaultAirMasteryValue.ToString();
        earthMasteryValue.GetComponentInChildren<Text>().text = defaultEarthMasteryValue.ToString();
    }
}
