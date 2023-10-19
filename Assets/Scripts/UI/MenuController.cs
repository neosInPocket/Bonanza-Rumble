using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	private void Start()
	{
		//ClearProgress();
	}
	
	public void LoadGameScene()
	{
		SceneManager.LoadScene("GameScene");
	}
	
	private void ClearProgress()
	{
		SaveSystem.Level = 1;
		SaveSystem.AttractionUpgrade = 0;
		SaveSystem.Coins = 100;
		SaveSystem.LifesUpgrade = 1;
		SaveSystem.IsFirstGameTime = "yes";
		SaveSystem.MusicVolume = 1f;
		SaveSystem.Save();
	}
}
