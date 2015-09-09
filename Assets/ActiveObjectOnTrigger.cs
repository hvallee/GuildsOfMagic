using UnityEngine;
using System.Collections;

public class ActiveObjectOnTrigger : MonoBehaviour {
	
	public GameObject objectToActive;
	
	void OnTriggerEnter(Collider col)
	{
		objectToActive.SetActive(true);
	}
}
