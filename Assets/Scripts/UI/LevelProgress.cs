using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class LevelProgress : MonoBehaviour
{
	[SerializeField] private Image inner;
	[SerializeField] private TMP_Text text;
	
	public void Refresh(int currentPoints, int allPoints)
	{
		text.text = currentPoints + "/" + allPoints;
		inner.fillAmount = currentPoints * allPoints;
	}
}
