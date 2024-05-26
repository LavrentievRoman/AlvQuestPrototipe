using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacteristicSetup : MonoBehaviour
{
    public int defaultStrengthValue = 5;
    public int defaultDexterityValue = 5;
    public int defaultEnduranceValue = 5;
    public int defaultFireMasteryValue = 5;
    public int defaultEarthMasteryValue = 5;
    public int defaultAirMasteryValue = 5;
    public int defaultWaterMasteryValue = 5;

    public GameObject cpValue;
    public GameObject strengthValue;
    public GameObject dexterityValue;
    public GameObject enduranceValue;
    public GameObject fireMasteryValue;
    public GameObject earthMasteryValue;
    public GameObject airMasteryValue;
    public GameObject waterMasteryValue;

    private int availableCP;

    private Dictionary<ECharacteristic, int> characteristics;

    // Start is called before the first frame update
    public void Awake()
    {
        characteristics = new Dictionary<ECharacteristic, int>();

        characteristics.Add(ECharacteristic.Strength, defaultStrengthValue);
        characteristics.Add(ECharacteristic.Dexterity, defaultDexterityValue);
        characteristics.Add(ECharacteristic.Endurance, defaultEnduranceValue);
        characteristics.Add(ECharacteristic.Fire, defaultFireMasteryValue);
        characteristics.Add(ECharacteristic.Water, defaultWaterMasteryValue);
        characteristics.Add(ECharacteristic.Air, defaultAirMasteryValue);
        characteristics.Add(ECharacteristic.Earth, defaultEarthMasteryValue);

        SetDefaults();
    }

    public void SetCharacteristicPointValue(int CP)
    {
        availableCP = CP;

        cpValue.GetComponentInChildren<Text>().text = availableCP.ToString();
    }

    public void IncreaseCharacteristicPoint()
    {
        availableCP++;

        UpdateInformation();
    }

    public void ReduceCharacteristicPoint()
    {
        availableCP--;

        UpdateInformation();
    }   

    public int GetCharacteristicPointValue()
    {
        return availableCP;
    }

    public void UpdateInformation()
    {
        cpValue.GetComponentInChildren<Text>().text = availableCP.ToString();

        characteristics[ECharacteristic.Strength] = int.Parse(strengthValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Dexterity] = int.Parse(dexterityValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Endurance] = int.Parse(enduranceValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Fire] = int.Parse(fireMasteryValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Water] = int.Parse(waterMasteryValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Air] = int.Parse(airMasteryValue.GetComponentInChildren<Text>().text);
        characteristics[ECharacteristic.Earth] = int.Parse(earthMasteryValue.GetComponentInChildren<Text>().text);
    }

    public void SaveInformation(CharacterDTO character)
    {
        character.Characteristics = new Dictionary<ECharacteristic, int>(characteristics);
        character.CharPoints = availableCP;
    }

    public void SetDefaults()
    {
        strengthValue.GetComponentInChildren<Text>().text = defaultStrengthValue.ToString();
        dexterityValue.GetComponentInChildren<Text>().text = defaultDexterityValue.ToString();
        enduranceValue.GetComponentInChildren<Text>().text = defaultEnduranceValue.ToString();
        fireMasteryValue.GetComponentInChildren<Text>().text = defaultFireMasteryValue.ToString();
        waterMasteryValue.GetComponentInChildren<Text>().text = defaultWaterMasteryValue.ToString();
        airMasteryValue.GetComponentInChildren<Text>().text = defaultAirMasteryValue.ToString();
        earthMasteryValue.GetComponentInChildren<Text>().text = defaultEarthMasteryValue.ToString();

        if (characteristics == null) return;
        UpdateInformation();
    }
}
