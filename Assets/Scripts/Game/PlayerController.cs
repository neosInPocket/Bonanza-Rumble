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
	public bool isSpawned;
	public Action CoinCollected;
	public Action SpikesCollision;
	
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
	
	private void OnDestroy()
	{
		EnhancedTouchSupport.Disable();
		TouchSimulation.Disable();
	}
	
	public void Enable()
	{
		Touch.onFingerDown += SpawnAttractor;
	}
	
	public void Disable()
	{
		Touch.onFingerDown -= SpawnAttractor;
	}
}
