using UnityEngine;
using System.Collections;

public class DestroyChildWhenHit : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnTriggerExit(Collider col)
	{Debug.Log("okk");
		if(col.gameObject.layer == 13)
		{
			if(transform.GetChild(0) != null)
				Destroy(transform.GetChild(0).gameObject);
			else
				Destroy(gameObject);
		}
	}
}
