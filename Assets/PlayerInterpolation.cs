using UnityEngine;
using System.Collections;

public class PlayerInterpolation : MonoBehaviour {

	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	
	private Vector3 syncStartPosition = Vector3.zero;
	private Quaternion syncStartRotation = Quaternion.identity;
	private Quaternion syncEndRotation = Quaternion.identity;
	private Vector3 syncEndPosition = Vector3.zero;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!GetComponent<NetworkView>().isMine)			
			SyncedMovement();

	}
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		
		Vector3 syncPosition = Vector3.zero;
		Quaternion syncRotation = Quaternion.identity;
		Vector3 syncVelocity = Vector3.zero;
		
		if (stream.isWriting)
		{
			syncPosition = transform.position;
			stream.Serialize(ref syncPosition);
			
			syncVelocity = GetComponent<Rigidbody>().velocity;
			stream.Serialize(ref syncVelocity);
			
			syncRotation = transform.rotation;
			stream.Serialize(ref syncRotation);
		}
		else
		{
			stream.Serialize(ref syncPosition);
			
			stream.Serialize(ref syncVelocity);
			
			stream.Serialize(ref syncRotation);
			
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncStartPosition = transform.position;
			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			
			syncStartRotation = transform.rotation;
			syncEndRotation = syncRotation;
		}
	}
	
	void SyncedMovement(){	
		syncTime += Time.deltaTime;
		if(Vector3.Distance(syncStartPosition, syncEndPosition) > 30.0f)
		{
			transform.position = syncEndPosition;
		}
		else
		{
			transform.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
		}	
		transform.rotation = Quaternion.Lerp(syncStartRotation, syncEndRotation, syncTime / syncDelay); 
	}
}
