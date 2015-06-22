using UnityEngine;
using System.Collections;

public class EquipableItem : InventoryItem {
	
	//Equipable Item Specific Attributes
	EquipmentType equipmentType;
	CloseCombatWeaponType closeCombatWeaponType;
	RangedCombatWeaponType rangedWeaponType;
	ArmorType armorType;
	AccessoryType accesoryType;
	
	public void initEquipableItem(Sprite sprite, string itemTitle, string itemDescription, ItemType itemType,
	                               float attackMultiplier, float defenseMultiplier, float magicMultiplier, float resistanceMultiplier, float healthMultiplier, float manaMultiplier, 
	                               float attack, float defense, float magic, float resistance, float health, float mana, 
	                               EquipmentType equipmentType, CloseCombatWeaponType closeCombatWeaponType, ArmorType armorType, AccessoryType accessoryType){
		base.init(sprite, itemTitle, itemDescription, itemType,
		          attackMultiplier, defenseMultiplier, magicMultiplier, resistanceMultiplier, healthMultiplier, manaMultiplier, 
		          attack, defense, magic, resistance, health, mana);
		
		this.equipmentType = equipmentType;
		this.closeCombatWeaponType = closeCombatWeaponType;
		this.armorType = armorType;
		this.accesoryType = accesoryType;
	}
}
