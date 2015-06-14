using UnityEngine;
using System.Collections;

public class ScrapSpawn : MonoBehaviour {

	public GameObject scrap;
	private DayNightManager timeManager;

	private int count = 300; // temp timer

	void Start()
	{
		//timeManager = GameObject.Find ("DayNightManager").GetComponent<DayNightManager> ();
	}

	// Update is called once per frame
	void Update () 
	{
		// TODO: sync spawn to timer
		//if (timeManager.timeText) {
		//}

		if (count == 0) 
		{
			for(int i=0; i < 100; i++)
			{
				Instantiate(scrap, this.transform.position, this.transform.rotation);
			}
			count = 300;
		}

		if (count <= 180 && count >= 90) 
		{
			this.transform.GetComponent<Collider>().isTrigger = true;
		} 
		else 
		{
			this.transform.GetComponent<Collider>().isTrigger = false;
		}

		count = count - 1;
	}
}
