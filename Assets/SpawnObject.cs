using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {

	public GameObject objectToSpawn;
	public bool hasSpawn = false;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasSpawn && Network.isServer)
		{
			hasSpawn = true;
			Network.Instantiate(objectToSpawn, transform.position, transform.rotation, 0);
		}
	}
}
