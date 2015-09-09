using UnityEngine;
using System.Collections;

public class LoadInformation : MonoBehaviour {

	public void LoadAllInformation()
	{
		GameInformation.current = PlayerPrefs.GetInt("PLAYERINVENTORY");		
		GameInformation.name = PlayerPrefs.GetString("PLAYERNAME");
		Debug.Log(PlayerPrefs.GetString("PLAYERNAME"));
	}
}
