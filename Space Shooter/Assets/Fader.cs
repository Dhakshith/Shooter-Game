using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Fader : MonoBehaviour
{
	public Image panel;
    void Start()
    {
    	panel.color = new Color(0, 0, 0, 255);
    	StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
    	panel.enabled = true;
    	for (float f = 1f; f >= -0.01f; f -= 0.01f)
    	{
	    	Color c = Color.black;
	    	c.a = f;
	    	panel.color = c;
	    	yield return new WaitForSeconds(0.02f);
    	}
    	panel.enabled = false;
    }

    private IEnumerator FadeIn(int lvl)
    {
    	panel.enabled = true;
    	for (float f = 0.01f; f <= 1; f += 0.01f)
    	{
	    	Color c = Color.black;
	    	c.a = f;
	    	panel.color = c;
	    	yield return new WaitForSeconds(0.02f);
    	}
        PlayerPrefs.SetInt("Fading", 0);

    	if (lvl >= 0)
    		SceneManager.LoadScene(lvl);
    	else if (lvl == -2)
    		Application.Quit();
    }

    public void FadeInAnim(int lvl)
    {
        if (PlayerPrefs.GetInt("Fading", 0) == 0) {
            PlayerPrefs.SetInt("Fading", 1);
            StartCoroutine(FadeIn(lvl));
            PlayerPrefs.SetInt("Fading", 0);
        }
    }
}
