using UnityEngine;
using System.Collections;

public abstract class InventoryItem : ScriptableObject {


	//Visuals and Identifiers
	Sprite sprite;
	string itemTitle;
	string itemDescription;
	ItemType itemType;

	float attackMultiplier;
	float defenseMultiplier;
	float magicMultiplier;
	float resistanceMultiplier;
	float healthMultiplier;
	float manaMultiplier;

	float attack;
	float defense;
	float magic;
	float resistance;
	float health;
	float mana;


	public void init(Sprite sprite, string itemTitle, string itemDescription, ItemType itemType,
	                         float attackMultiplier, float defenseMultiplier, float magicMultiplier, float resistanceMultiplier, float healthMultiplier, float manaMultiplier, 
	                         float attack, float defense, float magic, float resistance, float health, float mana
	                    )
	{
		this.sprite = sprite;
		this.itemTitle = itemTitle;
		this.itemDescription = itemDescription;
		this.itemType = itemType;
		this.attackMultiplier = attackMultiplier;
		this.defenseMultiplier = defenseMultiplier;
		this.magicMultiplier = magicMultiplier;
		this.resistanceMultiplier = resistanceMultiplier;
		this.healthMultiplier = healthMultiplier;
		this.manaMultiplier = manaMultiplier;
		this.attack = attack;
		this.defense = defense;
		this.magic = magic;
		this.resistance = resistance;
		this.health = health;
		this.mana = mana;
	}

}
