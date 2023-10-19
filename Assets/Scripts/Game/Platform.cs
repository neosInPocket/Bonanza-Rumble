using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
	[SerializeField] private GameObject spikes;
	[SerializeField] private GameObject coin;
	
	private void Start()
	{
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
			return true;
		}
	}
}
