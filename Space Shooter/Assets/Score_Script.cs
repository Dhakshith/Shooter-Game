using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score_Script : MonoBehaviour
{
	[Header("Score")]
	public TextMeshProUGUI score;
	public TextMeshProUGUI highScore;
	public TextMeshProUGUI newHighScore;

	[Header("Wave")]
	public TextMeshProUGUI wave;
	public TextMeshProUGUI highWave;

	void Start()
	{
		score.text = PlayerPrefs.GetInt("Score").ToString();
		highScore.text = PlayerPrefs.GetInt("highScore").ToString();
		if (PlayerPrefs.GetInt("High", 0) == 1)
		{
			newHighScore.text = "NEW HIGH SCORE!";
			PlayerPrefs.SetInt("High", 0);
		} else
		{
			newHighScore.text = "  ";
		}
		wave.text = PlayerPrefs.GetInt("Wave").ToString();
		highWave.text = PlayerPrefs.GetInt("highScoreWave", 1).ToString();
	}
}