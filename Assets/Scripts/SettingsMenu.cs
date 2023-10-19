using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
	[SerializeField] private Slider slider;
	
	public void Refresh()
	{
		SaveSystem.Load();
		slider.value = SaveSystem.MusicVolume;
	}
}
