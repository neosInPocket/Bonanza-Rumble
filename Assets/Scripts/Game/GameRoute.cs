using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRoute : MonoBehaviour
{
	[SerializeField] private TMP_Text levelCaption;
	[SerializeField] private HealthRenderer healthRenderer;
	[SerializeField] private LevelProgress levelProgress;
	[SerializeField] private PlayerController player;
	[SerializeField] private Tutorial tutorial;
	[SerializeField] private CountDown countDown;
	[SerializeField] private GameResultScreen gameResultScreen;
	[SerializeField] private Transform platformContainer;
	[SerializeField] private Transform attractorContainer;
	[SerializeField] private ObjectSpawner objectSpawner;
	private int lifesCount;
	private int currentPoints;
	private int currentMaxPoints;
	private int currentLevelCoins;
	
	private void Start()
	{
		player.SpikesCollision += OnPlayerDamaged;
		player.CoinCollected += OnPlayerCoinCollected;
		
		StartGame();
	}
	
	public void StartGame()
	{
		objectSpawner.Initialize();
		gameResultScreen.Hide();
		SaveSystem.Load();
		DestroyObjects();
		player.ReturnToSpawn();
		
		lifesCount = SaveSystem.LifesUpgrade;
		currentPoints = 0;
		currentMaxPoints = GetLevelMaxPoints();
		currentLevelCoins = GetLevelCoins();
		
		levelCaption.text = "Level " + SaveSystem.Level;
		RefreshUI();
		
		if (SaveSystem.IsFirstGameTime == "yes")
		{
			SaveSystem.IsFirstGameTime = "no";
			SaveSystem.Save();
			tutorial.TutorialEnd += OnTutorialEnd;
			tutorial.Play();
		}
		else
		{
			PlayCountDown();
		}
	}
	
	private void OnTutorialEnd()
	{
		PlayCountDown();
	}
	
	private void PlayCountDown()
	{
		countDown.CountDownEnd += OnCountDownEnd;
		countDown.Play();
	}
	
	private void OnCountDownEnd()
	{
		countDown.CountDownEnd -= OnCountDownEnd;
		player.Enable();
	}
	
	private void OnPlayerDamaged()
	{
		lifesCount--;
		RefreshUI();
		CheckLose();
	}
	
	private void OnPlayerCoinCollected()
	{
		currentPoints += 2;
		RefreshUI();
		CheckWin();
	}
	
	private void CheckLose()
	{
		if (lifesCount != 0)
		{
			player.TakeDamage();
		}
		else
		{
			gameResultScreen.Show(false, 0);
			player.Disable();
		}
	}
	
	private void CheckWin()
	{
		if (currentPoints >= currentMaxPoints)
		{
			currentPoints = currentMaxPoints;
			RefreshUI();
			SaveSystem.Level++;
			SaveSystem.Coins += currentLevelCoins;
			SaveSystem.Save();
			gameResultScreen.Show(true, currentLevelCoins);
			player.Disable();
		}
	}
	
	private void RefreshUI()
	{
		healthRenderer.Refresh(lifesCount);
		levelProgress.Refresh(currentPoints, currentMaxPoints);
	}
	
	private int GetLevelMaxPoints()
	{
		var level = SaveSystem.Level;
		return (int)(level * Mathf.Log(level) + 5);
	}
	
	private int GetLevelCoins()
	{
		var level = SaveSystem.Level;
		return (int)(Mathf.Pow(level, 1/4) * Mathf.Log(100 * level) + 50);
	}
	
	private void OnDestroy()
	{
		player.SpikesCollision -= OnPlayerDamaged;
		player.CoinCollected -= OnPlayerCoinCollected;
	}
	
	public void DestroyObjects()
	{
		foreach (Transform child in platformContainer)
		{
			Destroy(child.gameObject);
		}	
		
		foreach (Transform child in attractorContainer)
		{
			Destroy(child.gameObject);
		}	
	}
	
	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
