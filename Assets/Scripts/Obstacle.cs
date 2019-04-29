using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : GameControl
{
	private void OnCollisionEnter2D(Collision2D coll)
	{	
		isDead = true;
		//if(coll.collider.GetComponent<GameControl>()!=null)
		if(isDead)
		{
			SceneManager.LoadScene (0);
		}
	}
}