using UnityEngine;
using System.Collections;

public class SpellSacredPoolPreview : MonoBehaviour {

	private bool isOnPreview = false;
	public LayerMask layer;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			transform.parent.position = hit.point;
			transform.parent.transform.rotation = hit.transform.rotation;
		}
	}
	
	
}
