using UnityEngine;
using System.Collections;

public class EnemyLoot : MonoBehaviour {

	public int[] lootID;
	public int[] lootAmount;
	public Item[] loot;
	public int maxLoot;
	ItemDatabase itemDatabase;
	
	// Use this for initialization
	void Start () 
	{
		itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
		loot = new Item[100];
		FillLootTable();
	}
	
	// Update is called once per frame
	public void Loot() 
	{
		if(Network.isServer)
		{
			if(GameObject.FindGameObjectWithTag("Player") != null)
			{
				Network.Instantiate(Resources.Load<GameObject>("Prefabs/Particles/MagicGlobe"), transform.position, Quaternion.identity, 0);
				for(int i = 0; i < maxLoot; i++)
				{
					int randomLoot = Random.Range(0, 100);
					GameObject resource = Resources.Load<GameObject>(loot[randomLoot].itemModel);
					resource.GetComponent<DroppedItem>().item = loot[randomLoot];
					GameObject dropInstance = Network.Instantiate(resource, transform.position, Quaternion.identity, 0) as GameObject;
					Vector3 randomPos = new Vector3(transform.position.x + Random.Range(-1, 1), transform.position.y + 1, transform.position.z + Random.Range(-1, 1));
					dropInstance.transform.position = randomPos;
					dropInstance.GetComponent<Rigidbody>().AddForce(Vector3.up * 10.0f, ForceMode.Impulse);
				}
				
			}
		}
	}
	
	void FillLootTable()
	{
		int k = 0;
		for(int i = 0; i < lootID.Length; i++)
		{
			for(int j = 0; j < lootAmount[i]; j++)
			{	
				loot[k] = getItem(lootID[i]);
				k++;
			}
		}
	}
	
	Item getItem(int id)
	{
		Item item = new Item();
		for(int i = 0; i < itemDatabase.items.Count; i++)
		{
			if(itemDatabase.items[i].itemID == id)
			{
				item = itemDatabase.items[i];
				break;
			}
		}
		return item;
	}
}
