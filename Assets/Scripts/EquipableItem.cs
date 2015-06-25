using UnityEngine;
using System.Collections;

public class EquipableItem : InventoryItem {
	
	//Equipable Item Specific Attributes
	[SerializeField] EquipmentType equipmentType;
	[SerializeField] WeaponType weaponType;
	[SerializeField] ArmorType armorType;
	[SerializeField] Projectile projectile;

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
	
	public void setProjectile(Projectile projectile){
		this.projectile = projectile;
	}


}
