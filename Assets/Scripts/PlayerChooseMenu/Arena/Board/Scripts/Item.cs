using AlvQuest_Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public EStoneType stoneType;
    //public SlotTag itemTag;

    /*[Header("If the item can be equipped")]
    public GameObject equipmentPrefab;*/
}
