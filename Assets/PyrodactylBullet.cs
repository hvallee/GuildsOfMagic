using UnityEngine;
using System.Collections;

public class PyrodactylBullet : MonoBehaviour {

	public Vector3 target;
	public GameObject blood;
	
	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody>().AddForce((target - transform.position).normalized * Time.deltaTime * 150.0f, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			col.gameObject.SendMessageUpwards("LowerHealth", 10);
			Network.Instantiate(blood, col.transform.position, Quaternion.identity, 0);
		}
		Network.Destroy(this.gameObject);
	}
}
