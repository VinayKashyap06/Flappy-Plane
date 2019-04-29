using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour 
{
	protected GameObject currentPlane;
	protected GameObject disabledPlane;
	private GameObject temp;
	protected GameObject gameUi;
	protected GameObject homeUi;
	protected GameObject obstacle;

	private void Awake()
	{
		
		homeUi = GameObject.FindWithTag ("HomeUI");

		gameUi = GameObject.FindWithTag ("GameUI");

		currentPlane = GameObject.FindWithTag ("RedPlane");

		disabledPlane =  GameObject.FindWithTag ("GreenPlane");

		obstacle = GameObject.FindWithTag ("Obstacle");

	}

	private void Start()
	{
		if (gameUi != null && homeUi != null && currentPlane != null && disabledPlane != null && obstacle!=null) 			//Check for null refernce
		{
			currentPlane.SetActive (true);																					//Default Active Plane
			disabledPlane.SetActive (false);
			gameUi.SetActive (false);
			homeUi.SetActive (true);																						//Default Active Canvas
			obstacle.SetActive (false);
			currentPlane.GetComponent<Animator> ().enabled = false;															//Stop Animator
			disabledPlane.GetComponent<Animator> ().enabled = false;
			currentPlane.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Kinematic;
			disabledPlane.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Kinematic;
		} 
	}

	private void Update()
	{
		CheckTouch ();
	}

	public void ChangePlanes ()
	{
		if (currentPlane != null && disabledPlane != null) 
		{
			currentPlane.SetActive (false);																	//Switch Planes
			disabledPlane.SetActive (true);
		}

		temp = currentPlane;
		currentPlane = disabledPlane;
		disabledPlane = temp;
	}		

	public void MenuButton()																				//Menu Button UI function
	{
		SceneManager.LoadScene (0);
	}


	public void CheckTouch()
	{
       
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Debug.Log("UI");
                ChangePlanes();                                                                                         //Call Plane Switch
            }
            else                                                                                                            //Any other touch
            {
                if (homeUi != null && gameUi != null)                                                                       //Check for Null reference
                {
                    homeUi.SetActive(false);
                    gameUi.SetActive(true);                                                                             //Enable Game view
                    obstacle.SetActive(true);
                    currentPlane.GetComponent<Animator>().enabled = true;                                                   //Enable Animation and Dynamics
                    currentPlane.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
	}
}