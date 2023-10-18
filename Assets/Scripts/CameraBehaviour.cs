using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
	[SerializeField] private PlayerController player;
	[SerializeField] private float offset;
	[SerializeField] private float acceleration;
	
	private float distance => Mathf.Abs(player.transform.position.y + offset - transform.position.y);
	
	private void Update()
	{
		transform.position = new Vector2(transform.position.x, transform.position.y + acceleration * distance * Time.deltaTime);
	}
}
