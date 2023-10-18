using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderPlatforms : MonoBehaviour
{
	[SerializeField] private BoxCollider2D left;
	[SerializeField] private SpriteRenderer leftRenderer;
	[SerializeField] private SpriteRenderer rightRenderer;
	[SerializeField] private BoxCollider2D right;
	
	private void Start()
	{
		var screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		
		left.transform.position = new Vector2(-screenBounds.x - leftRenderer.bounds.size.x / 2, 0);
		right.transform.position = new Vector2(screenBounds.x + rightRenderer.bounds.size.x / 2, 0);
		
		left.size = new Vector2(left.size.x, screenBounds.y * 2);
		right.size = new Vector2(right.size.x, screenBounds.y * 2);
	}
}
