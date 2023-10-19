using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
	[SerializeField] private AudioSource musicSource;
	
	private void Start()
	{
		SaveSystem.Load();
		musicSource.volume = SaveSystem.MusicVolume;
	}
	
	public void ChangeMusicVolume(float value)
	{
		musicSource.volume = value;
	}
	
	public void SaveMusicVolume()
	{
		SaveSystem.MusicVolume = musicSource.volume;
		SaveSystem.Save();
	}
}
