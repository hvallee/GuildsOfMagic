using UnityEngine;
using System.Collections;

public class SpellActivation : MonoBehaviour {

	public Transform obj;

	
	public void Preview()
	{
		transform.FindChild("preview").gameObject.SetActive(true);
	}
	
	public void Activate(Transform pos)
	{
		obj = pos;
		transform.FindChild("preview").gameObject.SetActive(false);
		transform.FindChild("spell").gameObject.SetActive(true);
		GetComponent<NetworkView>().RPC ("RPCActivate", RPCMode.OthersBuffered);
	}
	
	[RPC]
	public void RPCActivate()
	{
		transform.FindChild("spell").gameObject.SetActive(true);
	}
	
}
