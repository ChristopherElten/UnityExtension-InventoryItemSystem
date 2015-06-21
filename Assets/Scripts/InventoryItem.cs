using UnityEngine;
using System.Collections;

public class InventoryItem : ScriptableObject {


	//Visuals and Identifiers
	Sprite sprite;
	string itemTitle;
	string itemDescription;
	ItemType itemType;
	
	//Equipable Item Specific Attributes
	EquipmentType equipmentType;
	CloseCombatWeaponType closeCombatWeaponType;
	RangedCombatWeaponType rangedWeaponType;
	ArmorType armorType;
	AccessoryType accesoryType;

	float attackMultiplier;
	float defenseMultiplier;
	float magicMultiplier;
	float resistanceMultiplier;
	float healthMultiplier;
	float manaMultiplier;

	//Consumable Item Specific Attributes
	bool hasTimeOut;
	float effectDuration;
	bool isStackable;
	int maxNumberOfStacks;

	//Attributes shared between consumables
	float attack;
	float defense;
	float magic;
	float resistance;
	float health;
	float mana;


	public void init(Sprite sprite, string itemTitle, string itemDescription, ItemType itemType, 
	                 EquipmentType equipmentType, CloseCombatWeaponType closeCombatWeaponType, RangedCombatWeaponType rangedWeaponType, ArmorType armorType, AccessoryType accesoryType,
	                 float attackMultiplier, float defenseMultiplier, float magicMultiplier, float resistanceMultiplier, float healthMultiplier, float manaMultiplier, 
	                 bool hasTimeOut, float effectDuration, bool isStackable, int maxNumberOfStacks,
	                 float attack, float defense, float magic, float resistance, float health, float mana
	                 ){
		this.sprite = sprite;
		this.itemTitle = itemTitle;
		this.itemDescription = itemDescription;
		this.itemType = itemType;
		this.equipmentType = equipmentType;
		this.closeCombatWeaponType = closeCombatWeaponType;
		this.rangedWeaponType = rangedWeaponType;
		this.armorType = armorType;
		this.accesoryType = accesoryType;
		this.attackMultiplier = attackMultiplier;
		this.defenseMultiplier = defenseMultiplier;
		this.magicMultiplier = magicMultiplier;
		this.resistanceMultiplier = resistanceMultiplier;
		this.healthMultiplier = healthMultiplier;
		this.manaMultiplier = manaMultiplier;
		this.hasTimeOut = hasTimeOut;
		this.effectDuration = effectDuration;
		this.isStackable = isStackable;
		this.maxNumberOfStacks = maxNumberOfStacks;
		this.attack = attack;
		this.defense = defense;
		this.magic = magic;
		this.resistance = resistance;
		this.health = health;
		this.mana = mana;
	}

}
