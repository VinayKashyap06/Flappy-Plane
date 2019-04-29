using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : Manager 
{

	[SerializeField]
	private float jumpForce = 150f;
	private Rigidbody2D rb;
	protected bool isDead= false;

	private void Start() 
	{
		rb= GetComponent<Rigidbody2D> ();										//RigidBody Component
	}

	private void Update () 
	{
		if (gameUi != null && gameUi.activeSelf == true && isDead==false)			
		{
			CheckForInput ();														//Call Input function
		}
		if (currentPlane!=null) 
		{
			CheckDeath ();
			if(isDead)
			{
				SceneManager.LoadScene (0);
			}																		//Load Home
		}
	}

	public void CheckForInput()
	{
		if (Input.touchCount==1) 													//Read Tap
		{
			if (Input.GetTouch (0).phase== TouchPhase.Began) {

				rb.velocity = Vector2.zero;
				rb.AddForce (Vector2.up * jumpForce);
			}
		}
	}

	public void CheckDeath()
	{
		if (currentPlane.transform.localPosition.y < -4f || currentPlane.transform.localPosition.y > 4f) 
		{
			isDead = true;
		}
	}
}
