using UnityEngine;
using System.Collections;

public class SaveInformation : MonoBehaviour {

	public void SaveAllInformation()
	{
		PlayerPrefs.SetInt("PLAYERINVENTORY", GameInformation.current);
		PlayerPrefs.SetString("PLAYERNAME", GameInformation.name);
		
		Debug.Log(PlayerPrefs.GetString("PLAYERNAME"));
	} 
} 
