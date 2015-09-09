using UnityEngine;
using System.Collections;

public class SacredPool : MonoBehaviour {

	public int destr = 0;
	public LayerMask layer;


	// Use this for initialization
	void Start () 
	{
		Invoke ("Destroy", 10.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.layer == 11)
		{
			if(col.GetComponent<PlayerStats>() != null)
				col.GetComponent<PlayerStats>().IncreaseLife(1);
		}
	}
	
	void Destroy()
	{
		if(destr == 1)
			transform.FindChild("Particles").GetComponent<ParticleSystem>().enableEmission = false;
		transform.GetChild(destr).gameObject.SetActive(false);
		if(destr < 10)
		{
			destr++;
			Invoke ("Destroy", 0.5f);
		}
		else
			Destroy(gameObject);

	}
	
	/*public void Activate(Transform obj)
	{
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			transform.position = hit.point;
			transform.rotation = hit.transform.rotation;
		}
	}*/
}
