using UnityEngine;
using UnityEngine.UI;
public class ScoreUpdate : MonoBehaviour 
{
	public Text scoreText;
	public Text bestText;
	public int counter;
	private int bestno,newBest;

	public void Start()
	{
		counter = 0;																	//0 when game is not started
		bestText.text += PlayerPrefs.GetInt ("Best:",0).ToString ();						//Retrieve the last high score
	}

	public void OnTriggerEnter2D()										//update Score
	{
		counter++;
			scoreText.text = "Score:"+ counter.ToString();
			

		if(counter > PlayerPrefs.GetInt("Best:"))										//Check for high score
			{
				PlayerPrefs.SetInt ("Best:",counter);
				bestText.text ="Best:"+ counter.ToString ();
			}
	}

	public void Update()
	{
		if(Input.GetButtonDown("Jump"))												//Reset highscore. For editor purpose only.
		{
				PlayerPrefs.DeleteAll();
		}
	}
}