using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
	[SerializeField] private PlayerController player;
	[SerializeField] private Transform firstPlatform;
	[SerializeField] private Transform secondPlatform;
	[SerializeField] private Transform spawnPlatform;
	[SerializeField] private GameObject[] platformPrefabs;
	[SerializeField] private Transform platformContainer;
	[SerializeField] private float xSpawnOffset;
	private float spawnDistance;
	private Transform lastPlatform;
	private Transform prevPlatform;
	private Transform mainPlatform;
	
	private void Start()
	{
		spawnDistance = Mathf.Abs(firstPlatform.transform.position.y - secondPlatform.transform.position.y);
		lastPlatform = secondPlatform;
		prevPlatform = firstPlatform;
		mainPlatform = spawnPlatform;
	}
	
	private void Update()
	{
		if (player.transform.position.y > mainPlatform.transform.position.y)
		{
			var screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
			var length = platformPrefabs.Length;
			var rnd = Random.Range(0, length);
			
			var rnd1 = Random.Range(-screenBounds.x + 0.5f, -xSpawnOffset);
			var rnd2 = Random.Range(xSpawnOffset, screenBounds.x - 0.5f);
			var rnd3 = Random.Range(0, 2);
			
			mainPlatform = prevPlatform;
			prevPlatform = lastPlatform;
			
			if (rnd3 == 0)
			{
				var newPlatformPos = new Vector2(rnd1, lastPlatform.transform.position.y + spawnDistance);
				lastPlatform = Instantiate(platformPrefabs[rnd], newPlatformPos, Quaternion.identity, platformContainer).transform;
			}
			else
			{
				var newPlatformPos = new Vector2(rnd2, lastPlatform.transform.position.y + spawnDistance);
				lastPlatform = Instantiate(platformPrefabs[rnd], newPlatformPos, Quaternion.identity, platformContainer).transform;
			}
		}
	}
}
