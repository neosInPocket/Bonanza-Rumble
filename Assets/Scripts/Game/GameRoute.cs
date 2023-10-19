using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameRoute : MonoBehaviour
{
	[SerializeField] private TMP_Text levelCaption;
	[SerializeField] private PlayerController player;
	[SerializeField] private Tutorial tutorial;
	[SerializeField] private CountDown countDown;
	[SerializeField] private GameResultScreen gameResultScreen;
	
	private void Start()
	{
		SaveSystem.Load();
		SaveSystem.IsFirstGameTime = "no";
		SaveSystem.Save();
		
		player.SpikesCollision += OnPlayerDamaged;
		player.CoinCollected += OnPlayerCoinCollected;
	}
	
	public void StartGame()
	{
		SaveSystem.Load();
		
		if (SaveSystem.IsFirstGameTime == "yes")
		{
			tutorial.TutorialEnd += OnTutorialEnd;
			tutorial.Play();
		}
		else
		{
			PlayCountDown();
		}
		
		levelCaption.text = "Level " + SaveSystem.Level;
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
		
	}
	
	private void OnPlayerCoinCollected()
	{
		
	}
	
	private void CheckBattleResult()
	{
		
	}
	
	private void OnDestroy()
	{
		player.SpikesCollision -= OnPlayerDamaged;
		player.CoinCollected -= OnPlayerCoinCollected;
	}
}
