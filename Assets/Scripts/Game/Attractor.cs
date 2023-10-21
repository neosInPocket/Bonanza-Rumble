using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attractor : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private float charge;
	[SerializeField] private GameObject deathEffect;
	[SerializeField] private ParticleSystem[] ps;
	private bool isInitialized;
	private Rigidbody2D attracted;
	private bool isDead;
	private int[] chargeValues = { 170, 210, 260, 300 }; 
	public void Initialize(Rigidbody2D rigidbody)
	{
		charge = chargeValues[SaveSystem.AttractionUpgrade];
		attracted = rigidbody;
		attracted.gravityScale = 0;
		attracted.totalForce = Vector2.zero;
		isInitialized = true;	
		StartCoroutine(WaitFor3Seconds());
	}
	
	private void Update()
	{
		if (!isInitialized) return;
		
		attracted.AddForce(CalculateForce(charge, attracted.transform, transform), ForceMode2D.Force);
	}
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<PlayerController>(out PlayerController player))
		{
			if (isDead) return;
			isInitialized = false;
			attracted.gravityScale = 1;
			attracted.totalForce = Vector2.zero;
			Kill();
		}
	}
	
	private Vector2 CalculateForce(float charge, Transform attracted, Transform attractor)
	{
		var difference = attractor.position - attracted.position;
		var distance = difference.magnitude;
		var direction = difference.normalized;
		var force = Mathf.Pow(charge, 2) / Mathf.Pow(distance, 2);
		
		return force * direction * Time.deltaTime;
	}
	
	private void Kill()
	{
		if (isDead) return;
		DisableParticleSystems();
		isDead = true;
		StartCoroutine(PlayDeathEffect());
	}
	
	private IEnumerator PlayDeathEffect()
	{
		spriteRenderer.color = new Color(0, 0, 0, 0);
		var effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
		attracted.gameObject.GetComponent<PlayerController>().isSpawned = false;
		yield return new WaitForSeconds(1f);
		Destroy(effect);
		Destroy(gameObject);
	}
	
	private void DisableParticleSystems()
	{
		foreach (var particleSystem in ps)
		{
			particleSystem.Stop();
			particleSystem.Clear();
		}
	}
	
	private IEnumerator WaitFor3Seconds()
	{
		yield return new WaitForSeconds(2.5f);
		if (isDead) yield break;
		attracted.totalForce = Vector2.zero;
		attracted.gravityScale = 1;
		Kill();
	}
}
