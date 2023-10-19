using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
	[SerializeField] private Animator animator;
	public Action CountDownEnd;
	
	public void Play()
	{
		StartCoroutine(PlayAnimation());
	}
	
	private IEnumerator PlayAnimation()
	{
		animator.SetTrigger("play");
		yield return new WaitForSeconds(3f);
		CountDownEnd?.Invoke();
	}
}
