using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrapManager : MonoBehaviour {

	public int scrapTotal;
	public static int scrapAmount;

	private Text scrapText;
	private float lastUpdate, timePassed;
	private int count;
	private bool buttonPressed;

	void OnEnable()
	{
		Timer.Tick += AddScrap;

	}
	void OnDisable()
	{
		Timer.Tick += AddScrap;

	}

	// Use this for initialization
	void Start () {
		scrapAmount = 0;
		buttonPressed = false;
		//scrapText = this.GetComponent<Text>();

//		scrapText.text = scrapAmount + "/" + scrapTotal;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//scrap collection
	public void CollectScrap()
	{

	}

	//function that checks to add scrap every frame
	//there might be better way to do it
	public void AddScrap(float currentTime)
	{

		timePassed += (currentTime - lastUpdate);

		//if collection is started, for 5 seconds add 1 scrap/sec
		if (timePassed >= 1 && buttonPressed && count <= 5) {
			count++;
			scrapAmount++;
			timePassed = 0;
			scrapText.text = scrapAmount.ToString ();
		}
		if (count >= 5) {
			buttonPressed = false;
		}

		lastUpdate = currentTime;
	}

	
	//function to refine scrap
	public void RefineScrap()
	{
	}
}
