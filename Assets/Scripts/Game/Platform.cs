using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
	[SerializeField] private GameObject spikes;
	[SerializeField] private GameObject coin;
	[SerializeField] private Transform playerSpawnPoint;
	[SerializeField] private bool isSpawnPlatform;
	public Transform PlayerSpawnPoint => playerSpawnPoint;
	public bool hasSpikes;
	
	private void Start()
	{
		if (isSpawnPlatform) return;
		
		var isSpawnSpikes = SpawnSpikes();
		
		if (isSpawnSpikes == true)
		{
			coin.SetActive(false);
		}
	}
	
	private bool SpawnSpikes()
	{
		var rnd = Random.Range(0, 2);
		
		if (rnd == 0)
		{
			spikes.SetActive(false);
			return false;
		}
		else
		{
			hasSpikes = true;
			return true;
		}
	}
}
