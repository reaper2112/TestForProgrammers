using UnityEngine;

public enum ItemType {Default, Weapon, Shield}

public class ItemScriptableObject : ScriptableObject
{
    public string _itemName;
    public int _maximumAmount;
    public GameObject _itemPrefab;
    public Sprite icon;
    public ItemType itemType;
    public string _itemDescription;
}
