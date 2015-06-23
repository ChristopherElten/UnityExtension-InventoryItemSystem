using UnityEngine;
using System.Collections;

public class EquipableItem : InventoryItem {
	
	//Equipable Item Specific Attributes
	EquipmentType equipmentType;
	WeaponType weaponType;
	ArmorType armorType;

	public void initEquipableItem(Sprite sprite, string itemTitle, string itemDescription, double cost, double weight, int rarity,
	                              float attackMultiplier, float defenseMultiplier, float magicMultiplier, float resistanceMultiplier, float healthMultiplier, float manaMultiplier, 
	                              float attack, float defense, float magic, float resistance, float health, float mana, 
	                               EquipmentType equipmentType, WeaponType weaponType, ArmorType armorType){
		base.init(sprite, itemTitle, itemDescription, cost, weight, rarity,
		          attackMultiplier, defenseMultiplier, magicMultiplier, resistanceMultiplier, healthMultiplier, manaMultiplier, 
		          attack, defense, magic, resistance, health, mana);
		
		this.equipmentType = equipmentType;
		this.weaponType = weaponType;
		this.armorType = armorType;
	}
}
