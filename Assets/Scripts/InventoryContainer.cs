using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryContainer : MonoBehaviour {

	[SerializeField]List<EquipableItem> equipableItems = new List<EquipableItem>();
	[SerializeField]List<ConsumableItem> consumableItems = new List<ConsumableItem>();

	//Adding an item
	public void collectItem(EquipableItem item){
		equipableItems.Add(item);
	}
	public void collectItem(ConsumableItem item){
		consumableItems.Add(item);
	}

	//Removing an item
	public void removeItem(EquipableItem item){
		equipableItems.Remove(item);
	}
	public void removeItem(ConsumableItem item){
		consumableItems.Remove(item);
	}

}
