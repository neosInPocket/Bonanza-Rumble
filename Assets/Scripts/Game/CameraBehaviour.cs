using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CameraBehaviour : MonoBehaviour
{
	[SerializeField] private Transform cameraPosition;
	[SerializeField] private PlayerController player;
	[SerializeField] private float amplitude;
	[SerializeField] private float delta;
	[SerializeField] private float offset;
	
	private void Update()
	{
		if (cameraPosition.transform.position.y > player.transform.position.y)  return;
		
		transform.position = new Vector3(transform.position.x, transform.position.y + CalculateSpeed() * Time.deltaTime, transform.position.z);
	}
	
	private float CalculateSpeed()
	{
		var distance = player.transform.position.y - cameraPosition.transform.position.y;
		int direction = (int)(distance / Mathf.Abs(distance));
		var newDistance = distance;
		
		return amplitude * direction * Mathf.Abs(newDistance);
	}
}
