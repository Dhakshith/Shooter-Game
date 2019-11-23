using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
	public ParticleSystem effect;

    void Start()
    {
    	GetComponent<Rigidbody>().velocity = new Vector3(0f, -0.25f, 0f);
    }

    void OnCollisionEnter(Collision hit)
    {
    	if (hit.gameObject.name == "Player" || hit.gameObject.tag == "Enemy_destroyer")
    	{
            PlayerPrefs.SetInt("HighWave", 0);
            PlayerPrefs.SetInt("ScoreSave", 0);

            if (PlayerPrefs.GetInt("Fading", 0) == 0)
            {
    	    	Destroy(gameObject);
                Fader obj = Camera.main.GetComponent<Fader>();
                obj.FadeInAnim(2);
            }
    	}
    	else if (hit.gameObject.tag == "Laser")
    	{
            PlayerPrefs.SetInt(name, 0);
	        Destroy();
	    	Destroy(hit.gameObject);
	    	PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + 1);
	    	if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("highScore"))
            {
	    		PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("Score"));
                PlayerPrefs.SetInt("High", 1);
            }
    	}
    }

    void Destroy()
    {
    	Destroy(gameObject);
    	Instantiate(effect, transform.position, Quaternion.identity);
    }
}
