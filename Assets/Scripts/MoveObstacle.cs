using UnityEngine;

public class MoveObstacle : Manager
{

	[SerializeField]
	private float speed;								//Speed of Obstacles
	private float randomOffset;							//To Randomize obstacles
	private void Start()
	{
		speed = 3f;
		randomOffset = 2f;
	}
	

	private void Update () 										
	{
		if (gameUi!=null && gameUi.activeSelf == true) 								//Null Reference check
		{
			transform.position += Time.deltaTime * speed * Vector3.left;			//Move Obstacles left

			if (transform.position.x < -3.1f) 										
			{	
				float randomHeight = UnityEngine.Random.Range (-randomOffset, randomOffset);		//Randomizing Obstacles
				transform.position = new Vector3 (3.2f, randomHeight, transform.position.z);
			}
		}
	}
}
