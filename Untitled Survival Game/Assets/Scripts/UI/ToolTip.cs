using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private Transform _entryHolder;

	[SerializeField]
	private ToolTipEntry _entryPrefab;


	private List<ToolTipEntry> _entries = new List<ToolTipEntry>();


	public void SetToolTip(Sprite icon, string[] entries)
	{
		_icon.sprite = icon;

		if (entries.Length > _entries.Count)
		{
			for (int i = _entries.Count; i < entries.Length; i++)
			{
				_entries.Add(Instantiate(_entryPrefab, _entryHolder, false));
			}
		}


		for (int i = 0; i < entries.Length; i++)
		{
			_entries[i].SetEntry(entries[i]);
			_entries[i].gameObject.SetActive(true);
		}

		for (int i = entries.Length; i < _entries.Count; i++)
		{
			_entries[i].gameObject.SetActive(false);
		}
	}


	private void Update()
	{
		transform.position = Input.mousePosition;
	}
}