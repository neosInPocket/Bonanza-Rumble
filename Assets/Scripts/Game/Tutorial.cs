using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
	public Action TutorialEnd;
	
	public void Play()
	{
		TutorialEnd?.Invoke();
	}
}
