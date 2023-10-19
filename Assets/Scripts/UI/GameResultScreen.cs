using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameResultScreen : MonoBehaviour
{
	[SerializeField] private TMP_Text resultCaption;
	[SerializeField] private TMP_Text coinsText;
	[SerializeField] private GameObject coinContainer;
	
	
	public void Show(bool isWin, int coinsAdded)
	{
		if (!isWin)
		{
			resultCaption.text = "You lose";
			coinContainer.gameObject.SetActive(false);
		}
		else
		{
			resultCaption.text = "You win";
			coinsText.text = "+" + coinsAdded;
		}
	}
}
