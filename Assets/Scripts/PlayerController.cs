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
	
	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
		Touch.onFingerDown += SpawnAttractor;
	}
	
	private void SpawnAttractor(Finger finger)
	{
		var worldPosition = Camera.main.ScreenToWorldPoint(finger.screenPosition);
		var attractor = Instantiate(attractorPrefab, worldPosition, Quaternion.identity, attractorContainer);
		attractor.Initialize(rb);
	}
	
	private void OnDestroy()
	{
		EnhancedTouchSupport.Disable();
		TouchSimulation.Disable();
	}
}
