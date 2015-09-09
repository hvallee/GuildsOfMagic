using UnityEngine;
using System.Collections;

public class DestroyWhenHit : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.layer == 13)
			Destroy(gameObject);
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.layer == 13)
			Destroy(gameObject);
	}
}
