using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemSO")]
public class ItemSO : ScriptableObject
{
	public int ItemID;

	public string ItemName;

	public string ExamineText;

	// Inventory Data
	public int StackLimit;

	public EquipSlot equipSlot;

	public Sprite Sprite;

	public List<Options> InventoryOptions;

	public List<Options> EquipedOptions;

	// World Item Data
	public Mesh Mesh;

	public Material Material;

	public List<Options> WorldOptions;

	// Wieldable Data

	public Vector3 ProjectileSource;


	// Ability Data
	[SerializeField]
	private UseItemSO _useItemSO;
	public UseItemSO UseItemSO => _useItemSO;

	[SerializeField]
	private AbilitySet _abilitySet;


	public AbilityItem GetAbilityItem()
	{
		return new AbilityItem(this);
	}


	public Ability[] GetRuntimeAbilities()
	{
		return _abilitySet.GetRuntimeAbilities();
	}

	private void OnValidate()
	{
		_abilitySet.ValidateAbilities();
	}
}
