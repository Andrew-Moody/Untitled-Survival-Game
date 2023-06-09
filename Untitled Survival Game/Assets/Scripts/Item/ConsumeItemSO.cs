using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item/ConsumeItemSO")]
public class ConsumeItemSO : UseItemSO
{
	public override void UseItem(AbilityActor user, ItemSO itemSO)
	{
		Debug.LogError($"Consuming item: {itemSO.ItemName}");
	}
}
