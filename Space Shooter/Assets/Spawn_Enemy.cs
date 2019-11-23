using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
	public GameObject enemy;
	public TextMeshProUGUI rend;
    private float encryption = 345.678f;

    void Start()
    {
    	PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("ScoreSave", 0));
    	PlayerPrefs.SetInt("Wave", PlayerPrefs.GetInt("HighWave", 0));
    	Color c = rend.color;
    	c.a = 0f;
    	rend.color = c;
    	InvokeRepeating("enemyWave", 3f, 45f);
    }

    private void enemyWave()
    {
    	PlayerPrefs.SetInt("Wave", PlayerPrefs.GetInt("Wave") + 1);
        if (PlayerPrefs.GetInt("Wave") > PlayerPrefs.GetInt("highScoreWave", 0))
            PlayerPrefs.SetInt("highScoreWave", PlayerPrefs.GetInt("Wave"));

        if (PlayerPrefs.GetInt("SavedState", 0) == 0) {
            for (int i = 0; i < 11; i++) {
                for (int j = 0; j < 5; j++) {
                    PlayerPrefs.SetInt(string.Format("Enemy {0} {1}", i, j), 1);
                    PlayerPrefs.SetFloat(string.Format("Enemy {0} {1} PosX", i, j), encryption);
                    PlayerPrefs.SetFloat(string.Format("Enemy {0} {1} PosY", i, j), encryption);
                }
            }
        }

    	for (int i = 0; i < 11; i++)
    	{
    		for (int j = 0; j < 5; j++)
    		{
                string preference = string.Format("Enemy {0} {1}", i, (int)j);
                if (PlayerPrefs.GetInt(preference) == 1)
                {
                    Vector3 pos = new Vector3(i-5, j+5.5f, 0);
                    if (PlayerPrefs.GetFloat(preference + " PosX") != encryption &&
                        PlayerPrefs.GetFloat(preference + " PosY") != encryption) {
                        pos.x = PlayerPrefs.GetFloat(preference + " PosX");
                        pos.y = PlayerPrefs.GetFloat(preference + " PosY");
                    }
                    GameObject obj = Instantiate(enemy, pos, Quaternion.identity);
                    PlayerPrefs.SetFloat(preference + " PosX", pos.x);
                    PlayerPrefs.SetFloat(preference + " PosY", pos.y);
                    obj.name = preference;
                    obj.transform.SetParent(GameObject.Find("Enemies").transform);
                }
	    	}
    	}

        PlayerPrefs.SetInt("SavedState", 0);
    	rend.text = "Wave " + PlayerPrefs.GetInt("Wave").ToString();
    	StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
    	for (float f = 0.05f; f <= 1; f += 0.05f)
    	{
	    	Color c = rend.color;
	    	c.a = f;
	    	rend.color = c;
	    	yield return new WaitForSeconds(0.02f);
    	}

    	yield return new WaitForSeconds(1f);

    	for (float f = 1f; f >= -0.05f; f -= 0.05f)
    	{
	    	Color c = rend.color;
	    	c.a = f;
	    	rend.color = c;
	    	yield return new WaitForSeconds(0.02f);
    	}
    }
}
