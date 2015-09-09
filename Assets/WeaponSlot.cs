using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponSlot : MonoBehaviour {

	public Item item;
	public GameObject weaponItem;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		item = weaponItem.GetComponent<CharacterSlot>().item;
		if(item.itemName != null)
		{
			transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(item.itemIcon);
			transform.GetChild(0).GetComponent<Image>().enabled = true;
		}
		else
		{
			transform.GetChild(0).GetComponent<Image>().enabled = false;
		}
			
	}
}
