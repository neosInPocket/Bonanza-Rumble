using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	[SerializeField] private GameObject deathEffect;
	private bool isDead;
	
	public void Kill()
	{
		if (isDead) return;
		isDead = true;
		StartCoroutine(DeathEffect());
	}
	
	private IEnumerator DeathEffect()
	{
		GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
		var effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(1);
		Destroy(effect);
		Destroy(gameObject);
	}
}
