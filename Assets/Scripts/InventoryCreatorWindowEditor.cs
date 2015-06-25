using UnityEngine;
using System.Collections;
using UnityEditor;

public enum ItemType {isEquipableItem, isConsumableItem};
public enum EquipmentType {weapon, armor};
public enum WeaponType {magic, bow, throwing, sword, axe, lance, martial_art};
public enum ArmorType {boots, pant, shirt, helmet, sleeves, gauntlets, accessory}

public class InventoryCreatorWindowEditor : EditorWindow {

	[MenuItem("Window/Inventory Creator")]
	public static void ShowWindow(){
		EditorWindow.GetWindow(typeof(InventoryCreatorWindowEditor));
	}
	//Item Type Selection Vars
	ItemType itemTypeSelected;

	//Equipable Item Specific Attributes
	EquipmentType equipmentTypeSelected;
	WeaponType weaponTypeSelected;
	ArmorType armorTypeSelected;

	//Projectile Specificity
	bool hasProjectile;
	string projectileName;
	Sprite projectileSprite;
	float projectileRange;
	float projectileWeight;
	ParticleSystem projectileLaunchParticles;
	TrailRenderer projectileTrail;
	ParticleSystem projectileImpactParticles;

	//Consumable Item Specific Attributes
	bool hasTimeOut = false;
	float effectDuration;
	bool isStackable = false;
	int maxNumberOfStacks;

	//Attributes shared between consumables
	Sprite sprite;
	string itemTitle = "";
	string itemDescription = "";
	double cost;
	double weight;
	int rarity; // Between one (1) and ten (10)
	float attack;
	float defense;
	float magic;
	float resistance;
	float health;
	float mana;
	float attackMultiplier;
	float defenseMultiplier;
	float magicMultiplier;
	float resistanceMultiplier;
	float healthMultiplier;
	float manaMultiplier;
	
	//Window
	void OnGUI(){

		//Identifications
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.BeginVertical();
		sprite = EditorGUILayout.ObjectField(sprite, typeof(Sprite), false, GUILayout.MinWidth(100), GUILayout.MinHeight(100), GUILayout.MaxWidth(100), GUILayout.MaxHeight(100)) as Sprite; 
		EditorGUILayout.EndVertical();
				
		EditorGUILayout.BeginVertical();
		EditorGUILayout.PrefixLabel("Name");
		itemTitle = GUILayout.TextField(itemTitle);

		EditorGUILayout.PrefixLabel("Description");
		itemDescription = GUILayout.TextArea(itemDescription);
		EditorGUILayout.EndVertical();
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();

		EditorGUILayout.BeginHorizontal();
		cost = EditorGUILayout.DoubleField("Cost", cost);
		if (cost < 0) cost=0;
		weight = EditorGUILayout.DoubleField("Weight", weight);
		if (weight < 0) weight=0;
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		rarity = EditorGUILayout.IntSlider("Rarity", rarity, 1, 10);
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

			if (equipmentTypeSelected == EquipmentType.weapon) {
				weaponTypeSelected = (WeaponType)EditorGUILayout.EnumPopup(weaponTypeSelected);
				
				hasProjectile = EditorGUILayout.BeginToggleGroup("Projectile", hasProjectile);
				//Projectile
				projectileName = EditorGUILayout.TextField("Projectile Name", projectileName);
				projectileRange = EditorGUILayout.FloatField("Range", projectileRange);
				if (projectileRange < 0) projectileRange=0;
				projectileWeight = EditorGUILayout.FloatField("Projectile Weight", projectileWeight);
				projectileLaunchParticles = EditorGUILayout.ObjectField("Projectile Launch Particles: ", projectileLaunchParticles, typeof(ParticleSystem), false) as ParticleSystem;
				//Potentially ask for particle material and then build through script?
				projectileTrail = EditorGUILayout.ObjectField("Projectile Trail: ", projectileTrail, typeof(TrailRenderer), false) as TrailRenderer;
				projectileImpactParticles = EditorGUILayout.ObjectField("Projectile Impact Particles: ", projectileImpactParticles, typeof(ParticleSystem), false) as ParticleSystem;
				projectileSprite = EditorGUILayout.ObjectField("Projectile Sprite: ", projectileSprite, typeof(Sprite), false) as Sprite;
				EditorGUILayout.EndToggleGroup();
			}


			//Armor
			if (equipmentTypeSelected == EquipmentType.armor) armorTypeSelected = (ArmorType)EditorGUILayout.EnumPopup(armorTypeSelected);
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
		}

		//Create the asset
		if (GUILayout.Button("Create Item")) {
			if (itemTypeSelected==ItemType.isConsumableItem){
				ConsumableItem item;
				item  = CustomAssetUtil.CreateAsset<ConsumableItem>(itemTitle);
				item.initConsumableItem(sprite, itemTitle, itemDescription, cost, weight, rarity, 
				                        attackMultiplier, defenseMultiplier, magicMultiplier, resistanceMultiplier, healthMultiplier, manaMultiplier,
				                        attack, defense, magic, resistance, health, mana, 
				                        hasTimeOut, effectDuration, isStackable, maxNumberOfStacks);
			}
			if (itemTypeSelected==ItemType.isEquipableItem){

				
				EquipableItem item;
				item  = CustomAssetUtil.CreateAsset<EquipableItem>(itemTitle);
				item.initEquipableItem(sprite, itemTitle, itemDescription, cost, weight, rarity, 
				                       attackMultiplier, defenseMultiplier, magicMultiplier, resistanceMultiplier, healthMultiplier, manaMultiplier,
				                       attack, defense, magic, resistance, health, mana, 
				                       equipmentTypeSelected, weaponTypeSelected, armorTypeSelected);

				if (hasProjectile){
					//Create projectile object here
					Projectile projectile;
					projectile = CustomAssetUtil.CreateAsset<Projectile>(projectileName);
					projectile.init(projectileName, projectileSprite, projectileRange, projectileWeight, projectileLaunchParticles, projectileTrail, projectileImpactParticles);

					item.setProjectile(projectile);
				}

			}
		}



	}

}
