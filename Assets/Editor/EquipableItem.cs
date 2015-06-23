using UnityEngine;
using System.Collections;

public class EquipableItem : InventoryItem {
	
	//Equipable Item Specific Attributes
	EquipmentType equipmentType;
	ArmorType armorType;

	public void initEquipableItem(Sprite sprite, string itemTitle, string itemDescription, ItemType itemType,
	                               float attackMultiplier, float defenseMultiplier, float magicMultiplier, float resistanceMultiplier, float healthMultiplier, float manaMultiplier, 
	                               float attack, float defense, float magic, float resistance, float health, float mana, 
	                               EquipmentType equipmentType, ArmorType armorType){
		base.init(sprite, itemTitle, itemDescription, itemType,
		          attackMultiplier, defenseMultiplier, magicMultiplier, resistanceMultiplier, healthMultiplier, manaMultiplier, 
		          attack, defense, magic, resistance, health, mana);
		
		this.equipmentType = equipmentType;
		this.armorType = armorType;
	}
}
