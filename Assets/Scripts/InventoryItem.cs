using UnityEngine;
using System.Collections;

public abstract class InventoryItem : ScriptableObject {
	
	[SerializeField] Sprite sprite;
	[SerializeField] string itemTitle = "";
	[SerializeField] string itemDescription = "";
	[SerializeField] double cost;
	[SerializeField] double weight;
	[SerializeField] int rarity; // Between one (1) and ten (10)
	[SerializeField] float attack;
	[SerializeField] float defense;
	[SerializeField] float magic;
	[SerializeField] float resistance;
	[SerializeField] float health;
	[SerializeField] float mana;
	[SerializeField] float attackMultiplier;
	[SerializeField] float defenseMultiplier;
	[SerializeField] float magicMultiplier;
	[SerializeField] float resistanceMultiplier;
	[SerializeField] float healthMultiplier;
	[SerializeField] float manaMultiplier;


	public void init(Sprite sprite, string itemTitle, string itemDescription, double cost, double weight, int rarity,
	                         float attackMultiplier, float defenseMultiplier, float magicMultiplier, float resistanceMultiplier, float healthMultiplier, float manaMultiplier, 
	                         float attack, float defense, float magic, float resistance, float health, float mana
	                    )
	{
		this.sprite = sprite;
		this.itemTitle = itemTitle;
		this.itemDescription = itemDescription;
		this.cost = cost;
		this.weight = weight;
		this.rarity = rarity;
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
