using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DayNightManager : MonoBehaviour {


	//movement of sun
	public Light sun;
	public float secondsInFullDay = 1440f;
	[Range(0,1)]
	public float currentTimeOfDay = 0;
	[HideInInspector]
	public float timeMultiplier = 1f;

	float sunInitialIntensity;

	//updates clock
	public Text timeText;
	private int hours, minutes, seconds;
	private float lastUpdate, timePassed;
	private const float LENGTHOFSECOND = 0.1f;
	private bool switched;
	private string amPM;

	void Awake()
	{
		switched = false;
		amPM = "AM";
		timeText = GetComponentInChildren<Text> ();
	}

	void OnEnable()
	{
		Timer.Tick += UpdateTime;
	}

	void OnDisable()
	{
		Timer.Tick -= UpdateTime;
	}

	void Start() {
		sunInitialIntensity = sun.intensity;
	}
	
	void Update() {
//		UpdateSun();
//		
//		currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
//		
//		if (currentTimeOfDay >= 1) {
//			currentTimeOfDay = 0;
//		}
	}

	public void UpdateTime(float currentTime)
	{
		//calculations done to make 12 minutes = 1 "day" of game time

		timePassed += (currentTime - lastUpdate);
	
		if (timePassed >= LENGTHOFSECOND) {
			seconds++;
			timePassed = 0;
		}

		if (seconds >= 60) 
		{
			minutes++;
			seconds = 0;
		}

		if (minutes >= 60) 
		{
			hours++;
			minutes = 0;
		}

		if (hours == 12) 
		{
			if(amPM.Equals("AM") && !switched)
			{
				amPM = "PM";
				Debug.Log(amPM);
				switched = true;
			}
			if(amPM.Equals("PM") && !switched)
			{
				amPM = "AM";
				Debug.Log(amPM);
				switched = true;
			}

		}
		else if (hours > 12) 
		{
			hours = 1;
			switched = false;
		}
		if (timeText != null)
			timeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes,seconds) + " " + amPM;

		lastUpdate = currentTime;
	}


	
	void UpdateSun() {
		sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
		
		float intensityMultiplier = 1;
		if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
			intensityMultiplier = 0;
		}
		else if (currentTimeOfDay <= 0.25f) {
			intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
		}
		else if (currentTimeOfDay >= 0.73f) {
			intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
		}
		
		sun.intensity = sunInitialIntensity * intensityMultiplier;
	}
}
