using UnityEngine;
using System.Collections;
using UnityEditor;

public enum ItemType {isEquipableItem, isConsumableItem};
public enum EquipmentType {ranged_combat_weapon, close_combat_weapon, armor, accessory};
public enum RangedCombatWeaponType {magic, bow, throwing};
public enum CloseCombatWeaponType {sword, axe, lance, martial_art};
public enum ArmorType {boots, pant, shirt, helmet, sleeves, gauntlets}
public enum AccessoryType {ring, necklace, headband, bracelet, belt};

public class InventoryCreatorWindow : EditorWindow {

	[MenuItem("Window/Inventory Creator")]
	public static void ShowWindow(){
		EditorWindow.GetWindow(typeof(InventoryCreatorWindow));
	}

	//Editor constants

	//Visuals and Identifiers
	Sprite sprite;
	string itemTitle = "";
	string itemDescription = "";

	//Item Type Selection Vars
	ItemType itemTypeSelected;

	//Equipable Item Specific Attributes
	EquipmentType equipmentTypeSelected;
	RangedCombatWeaponType rangedCombatWeaponTypeSelected;
	CloseCombatWeaponType closeCombatWeaponTypeSelected;
	ArmorType armorTypeSelected;
	AccessoryType accessoryTypeSelected;
	float attackMultiplier;
	float defenseMultiplier;
	float magicMultiplier;
	float resistanceMultiplier;
	float healthMultiplier;
	float manaMultiplier;

	//Consumable Item Specific Attributes
	bool hasTimeOut = false;
	float effectDuration;
	bool isStackable = false;
	int maxNumberOfStacks;

	//Attributes shared between consumables
	float attack;
	float defense;
	float magic;
	float resistance;
	float health;
	float mana;
	
	//Window
	void OnGUI(){

		//Identifications
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.BeginVertical();
		sprite = EditorGUILayout.ObjectField("Sprite: ", sprite, typeof(Sprite), false) as Sprite; 
		EditorGUILayout.EndVertical();
				
		EditorGUILayout.BeginVertical();
		EditorGUILayout.PrefixLabel("Name");
		itemTitle = GUILayout.TextField(itemTitle);

		EditorGUILayout.PrefixLabel("Description");
		itemDescription = GUILayout.TextArea(itemDescription);
		EditorGUILayout.EndVertical();
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();
		
		//Attributes
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel("Type of Item");
		itemTypeSelected = (ItemType)EditorGUILayout.EnumPopup(itemTypeSelected);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();

		//Equipable item selected
		if (itemTypeSelected == ItemType.isEquipableItem){

			equipmentTypeSelected = (EquipmentType)EditorGUILayout.EnumPopup(equipmentTypeSelected);

			if (equipmentTypeSelected == EquipmentType.close_combat_weapon) closeCombatWeaponTypeSelected = (CloseCombatWeaponType)EditorGUILayout.EnumPopup(closeCombatWeaponTypeSelected);
			if (equipmentTypeSelected == EquipmentType.ranged_combat_weapon) rangedCombatWeaponTypeSelected = (RangedCombatWeaponType)EditorGUILayout.EnumPopup(rangedCombatWeaponTypeSelected);
			if (equipmentTypeSelected == EquipmentType.armor) armorTypeSelected = (ArmorType)EditorGUILayout.EnumPopup(armorTypeSelected);
			if (equipmentTypeSelected == EquipmentType.accessory) accessoryTypeSelected = (AccessoryType)EditorGUILayout.EnumPopup(accessoryTypeSelected);

			EditorGUILayout.BeginHorizontal();
			attack = EditorGUILayout.FloatField("Attack", attack);
			attackMultiplier = EditorGUILayout.FloatField("Attack Multiplier", attackMultiplier);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			defense = EditorGUILayout.FloatField("Defense", defense);
			defenseMultiplier = EditorGUILayout.FloatField("Defense Multiplier", defenseMultiplier);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			magic = EditorGUILayout.FloatField("Magic", magic);
			magicMultiplier = EditorGUILayout.FloatField("Magic Multiplier", magicMultiplier); 
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			resistance = EditorGUILayout.FloatField("Resistance", resistance);
			resistanceMultiplier = EditorGUILayout.FloatField("Resistance Multiplier", resistanceMultiplier); 
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			health = EditorGUILayout.FloatField("Health", health);
			healthMultiplier = EditorGUILayout.FloatField("Health Multiplier", healthMultiplier); 
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			mana = EditorGUILayout.FloatField("Mana", mana);
			manaMultiplier = EditorGUILayout.FloatField("Mana Multiplier", manaMultiplier); 
			EditorGUILayout.EndHorizontal();
		}

		//Equipable item selected
		if (itemTypeSelected == ItemType.isConsumableItem){

			EditorGUILayout.BeginHorizontal();
			hasTimeOut = EditorGUILayout.Toggle("Effect Times Out", hasTimeOut);
			if (hasTimeOut) effectDuration = EditorGUILayout.FloatField("Duration", effectDuration);
			if (effectDuration < 0.001) effectDuration=0.001f;
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			isStackable = EditorGUILayout.Toggle("Stackable Item", isStackable);
			if (isStackable) maxNumberOfStacks = EditorGUILayout.IntField("Max Number of stacks", maxNumberOfStacks);
			if (maxNumberOfStacks < 1) maxNumberOfStacks=1;
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			attack = EditorGUILayout.FloatField("Attack", attack);
			attackMultiplier = EditorGUILayout.FloatField("Attack Multiplier", attackMultiplier);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			defense = EditorGUILayout.FloatField("Defense", defense);
			defenseMultiplier = EditorGUILayout.FloatField("Defense Multiplier", defenseMultiplier);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			magic = EditorGUILayout.FloatField("Magic", magic);
			magicMultiplier = EditorGUILayout.FloatField("Magic Multiplier", magicMultiplier); 
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			resistance = EditorGUILayout.FloatField("Resistance", resistance);
			resistanceMultiplier = EditorGUILayout.FloatField("Resistance Multiplier", resistanceMultiplier); 
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			health = EditorGUILayout.FloatField("Health", health);
			healthMultiplier = EditorGUILayout.FloatField("Health Multiplier", healthMultiplier); 
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			mana = EditorGUILayout.FloatField("Mana", mana);
			manaMultiplier = EditorGUILayout.FloatField("Mana Multiplier", manaMultiplier); 
			EditorGUILayout.EndHorizontal();
		}

		//Create the asset
		if (GUILayout.Button("Create Item")) {
			if (itemTypeSelected==ItemType.isConsumableItem){
				ConsumableItem item;
				item  = CustomAssetUtil.CreateAsset<ConsumableItem>(itemTitle);
				item.initConsumableItem(sprite, itemTitle, itemDescription, itemTypeSelected, 
				                        attackMultiplier, defenseMultiplier, magicMultiplier, resistanceMultiplier, healthMultiplier, manaMultiplier,
				                        attack, defense, magic, resistance, health, mana, 
				                        hasTimeOut, effectDuration, isStackable, maxNumberOfStacks);
			}
			if (itemTypeSelected==ItemType.isEquipableItem){
				EquipableItem item;
				item  = CustomAssetUtil.CreateAsset<EquipableItem>(itemTitle);
				item.initEquipableItem(sprite, itemTitle, itemDescription, itemTypeSelected, 
				                        attackMultiplier, defenseMultiplier, magicMultiplier, resistanceMultiplier, healthMultiplier, manaMultiplier,
				                        attack, defense, magic, resistance, health, mana,
				                        equipmentTypeSelected, closeCombatWeaponTypeSelected, armorTypeSelected, accessoryTypeSelected);
			}
		}



	}

}
