using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum WeaponSlot {weapon, boots, pant, shirt, helmet, sleeves, gauntlets, accessory}


public class EquippedInventoryContainer : MonoBehaviour {

	[SerializeField] Dictionary<WeaponSlot, EquipableItem> equippedWeapons = new Dictionary<WeaponSlot, EquipableItem>();

	public void add(WeaponSlot slot, EquipableItem item){
		equippedWeapons.Add(slot, item);
	}

	public void remove(WeaponSlot slot){
		equippedWeapons.Remove(slot);
	}
}
