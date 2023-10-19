using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
	[SerializeField] private Image[] gravityUpgradesPoints;
	[SerializeField] private Image[] lifesUpgradesPoints;
	[SerializeField] private Button gravityButton;
	[SerializeField] private Button lifesButton;
	[SerializeField] private TMP_Text coinsAmount;
	
	public void Refresh()
	{
		SaveSystem.Load();
		RefreshPoints();
		coinsAmount.text = SaveSystem.Coins.ToString();
		
		if (SaveSystem.Coins < 50 || SaveSystem.AttractionUpgrade == 3)
		{
			gravityButton.interactable = false;
		}
		
		if (SaveSystem.Coins < 100 || SaveSystem.LifesUpgrade == 3)
		{
			lifesButton.interactable = false;
		}
	}
	
	public void BuyLifesUpgrade()
	{
		SaveSystem.Coins -= 100;
		SaveSystem.LifesUpgrade++;
		SaveSystem.Save();
		Refresh();
	}
	
	public void BuyGravityUpgrade()
	{
		SaveSystem.Coins -= 50;
		SaveSystem.AttractionUpgrade++;
		SaveSystem.Save();
		Refresh();
	}
	
	private void RefreshPoints()
	{
		foreach (var gravity in gravityUpgradesPoints)
		{
			gravity.color = new Color(1, 1, 1, 0);
		}
		
		for (int i = 0; i < SaveSystem.AttractionUpgrade; i++)
		{
			gravityUpgradesPoints[i].color = new Color(1, 1, 1, 1);
		}
		
		foreach (var life in lifesUpgradesPoints)
		{
			life.color = new Color(1, 1, 1, 0);
		}
		
		for (int i = 0; i < SaveSystem.LifesUpgrade; i++)
		{
			lifesUpgradesPoints[i].color = new Color(1, 1, 1, 1);
		}
	}
}
