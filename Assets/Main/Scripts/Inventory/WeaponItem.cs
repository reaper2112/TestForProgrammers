using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Item", menuName = "Inventory/Items/New Weapon Item")]

public class WeaponItem : ItemScriptableObject
{
    [SerializeField] private float damage;

    private void Start()
    {
        itemType = ItemType.Weapon;
    }
}
