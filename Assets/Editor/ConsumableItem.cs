using UnityEngine;
using System.Collections;

public class ConsumableItem : InventoryItem {
	
	//Consumable Item Specific Attributes
	[SerializeField] bool hasTimeOut;
	[SerializeField] float effectDuration;
	[SerializeField] bool isStackable;
	[SerializeField] int maxNumberOfStacks;
	
	public void initConsumableItem(Sprite sprite, string itemTitle, string itemDescription, double cost, double weight, int rarity,
	                      float attackMultiplier, float defenseMultiplier, float magicMultiplier, float resistanceMultiplier, float healthMultiplier, float manaMultiplier, 
	                      float attack, float defense, float magic, float resistance, float health, float mana, 
	                      bool hasTimeOut, float effectDuration, bool isStackable, int maxNumberOfStacks){
		base.init(sprite, itemTitle, itemDescription, cost, weight, rarity,
		          attackMultiplier, defenseMultiplier, magicMultiplier, resistanceMultiplier, healthMultiplier, manaMultiplier, 
		          attack, defense, magic, resistance, health, mana);

		this.hasTimeOut = hasTimeOut;
		this.effectDuration = effectDuration;
		this.isStackable = isStackable;
		this.maxNumberOfStacks = maxNumberOfStacks;
	}

}
