using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button_Scripts : MonoBehaviour
{
	public TextMeshProUGUI score;

    void Update()
    {
    	score.text = PlayerPrefs.GetInt("Score").ToString();
    }

    public void Pause()
    {
	    if (Time.timeScale == 1)
	        PauseGame();
	    else if (Time.timeScale == 0)
	        ContinueGame();	
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void SaveState()
    {
        if (Time.timeScale == 1) {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    string preference = string.Format("Enemy {0} {1}", i, (int)j);
                    if (PlayerPrefs.GetInt(preference) == 1)
                    {
                        PlayerPrefs.SetFloat(preference + " PosX", GameObject.Find(preference).transform.position.x);
                        PlayerPrefs.SetFloat(preference + " PosY", GameObject.Find(preference).transform.position.y + 1);
                    }
                }
            }

            PlayerPrefs.SetInt("HighWave", PlayerPrefs.GetInt("Wave", 0) - 1);
            PlayerPrefs.SetInt("ScoreSave", PlayerPrefs.GetInt("Score", 0));
            PlayerPrefs.SetInt("SavedState", 1);
            if (PlayerPrefs.GetInt("Fading", 0) == 0) {
                Fader obj = Camera.main.GetComponent<Fader>();
                obj.FadeInAnim(2);
            }
        }
    }
}