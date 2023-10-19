using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Finger = UnityEngine.InputSystem.EnhancedTouch.Finger;
using UnityEngine.InputSystem.EnhancedTouch;

public class Tutorial : MonoBehaviour
{
	[SerializeField] GameObject mainContainer; 
	[SerializeField] private TMP_Text text;
	public Action TutorialEnd;
	
	private void Start()
	{
		EnhancedTouchSupport.Enable();
		TouchSimulation.Enable();
	}
	
	public void Play()
	{
		mainContainer.SetActive(true);
		text.text = "Welcome to Candy Magnetics!";
		Touch.onFingerDown += Phrase1;
	}
	
	private void Phrase1(Finger finger)
	{
		Touch.onFingerDown -= Phrase1;
		Touch.onFingerDown += Phrase2;
		text.text = "Control your candy by placing electromagnetic sources nearby!";
	}
	
	private void Phrase2(Finger finger)
	{
		Touch.onFingerDown -= Phrase2;
		Touch.onFingerDown += Phrase3;
		text.text = "Be aware of spikes that sometomes appear on platforms";
	}
	
	private void Phrase3(Finger finger)
	{
		Touch.onFingerDown -= Phrase3;
		Touch.onFingerDown += Phrase4;
		text.text = "Collect coins and buy different upgrades, such as maximum health amount";
	}
	
	private void Phrase4(Finger finger)
	{
		Touch.onFingerDown -= Phrase4;
		Touch.onFingerDown += LastPhrase;
		text.text = "Good luck!";
	}
	
	private void LastPhrase(Finger finger)
	{
		Touch.onFingerDown -= LastPhrase;
		gameObject.SetActive(false);
		TutorialEnd?.Invoke();
	}
	
	private void OnDestroy()
	{
		EnhancedTouchSupport.Disable();
		TouchSimulation.Disable();
	}
	
}
