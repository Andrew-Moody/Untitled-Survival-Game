using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
	[SerializeField]
	private string _panelName;
	public string PanelName => _panelName;

	protected GameObject _player;


	public virtual void Initialize()
	{
		
	}


	public virtual void SetPlayer(GameObject player)
	{
		_player = player;
	}


	public virtual void Show(UIPanelData data)
	{
		gameObject.SetActive(true);

		//Debug.LogError("Showing " + _panelName);
	}


	public virtual void Hide()
	{
		gameObject.SetActive(false);

		//Debug.LogError("Hiding " + _panelName);
	}
}


public class UIPanelData
{

}