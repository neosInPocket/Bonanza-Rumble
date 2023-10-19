using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private Attractor attractorPrefab;
	[SerializeField] private Transform attractorContainer;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private SpriteRenderer spriteRenderer; 
	[SerializeField] private Transform spawnPlatform; 
	[SerializeField] private CameraBehaviour cameraBehaviour; 
	public bool isSpawned;
	public Action CoinCollected;
	public Action SpikesCollision;
	private Transform currentSafePlatform;
	
	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}
	
	private void SpawnAttractor(Finger finger)
	{
		if (isSpawned) return;
		isSpawned = true;
		
		var worldPosition = Camera.main.ScreenToWorldPoint(finger.screenPosition);
		var attractor = Instantiate(attractorPrefab, worldPosition, Quaternion.identity, attractorContainer);
		attractor.Initialize(rb);
	}
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.TryGetComponent<Coin>(out Coin coin))
		{
			CoinCollected?.Invoke();
			coin.Kill();
			return;
		}
		
		if (collider.gameObject.TryGetComponent<Spikes>(out Spikes spikes))
		{
			SpikesCollision?.Invoke();
			return;
		}
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent<Platform>(out Platform platform))
		{
			if (platform.hasSpikes) return;
			
			currentSafePlatform = platform.transform;
		}
	}
	
	public void TakeDamage()
	{
		transform.position = currentSafePlatform.GetComponent<Platform>().PlayerSpawnPoint.position;
		cameraBehaviour.UpdatePosition();
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0;
		StopCoroutine(Flash());
		StartCoroutine(Flash());
	}
	
	private IEnumerator Flash()
	{
		for (int i = 0; i < 6; i++)
		{
			spriteRenderer.color = new Color(1, 1, 1, 0);
			yield return new WaitForSeconds(0.3f);
			spriteRenderer.color = new Color(1, 1, 1, 1);
			yield return new WaitForSeconds(0.3f);
		}
	}
	
	private void OnDestroy()
	{
		EnhancedTouchSupport.Disable();
		TouchSimulation.Disable();
	}
	
	public void Enable()
	{
		currentSafePlatform = spawnPlatform;
		Touch.onFingerDown += SpawnAttractor;
	}
	
	public void Disable()
	{
		Touch.onFingerDown -= SpawnAttractor;
	}
	
	public void ReturnToSpawn()
	{
		transform.position = spawnPlatform.GetComponent<Platform>().PlayerSpawnPoint.position;
		cameraBehaviour.UpdatePosition();
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0;
	}
}
