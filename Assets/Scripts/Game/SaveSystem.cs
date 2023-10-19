using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
	public static int Level;
	public static int Coins;
	public static int LifesUpgrade;
	public static int AttractionUpgrade;
	public static string IsFirstGameTime;
	
	public static void Save()
	{
		PlayerPrefs.SetInt("Coins", Coins);
		PlayerPrefs.SetInt("Level", Level);
		PlayerPrefs.SetInt("LifesUpgrade", LifesUpgrade);
		PlayerPrefs.SetInt("AttractionUpgrade", AttractionUpgrade);
		PlayerPrefs.SetString("IsFirstGameTime", IsFirstGameTime);
	}
	
	public static void Load()
	{
		Level = PlayerPrefs.GetInt("Level", 1);
		Coins = PlayerPrefs.GetInt("Coins", 100);
		LifesUpgrade = PlayerPrefs.GetInt("LifesUpgrade", 1);
		AttractionUpgrade = PlayerPrefs.GetInt("AttractionUpgrade", 0);
		IsFirstGameTime = PlayerPrefs.GetString("IsFirstGameTime", "yes");
	}
}
