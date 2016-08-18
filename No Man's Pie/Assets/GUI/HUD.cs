using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	int pieID;
	float pdist = 0;
	float temp = 170;
	// Use this for initialization
	void Start () {
		
		pieID = GetComponent<PlanetVars> ().pieID;
		Random.seed = pieID;
		pdist = Random.Range (2, 12)+Random.value;

		temp = temp / pdist*Random.value*1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI () {
		GUI.skin.label.fontSize = 40;
		GUI.Label (new Rect (10, Screen.height-45, 1000, 1000), (int)temp+" ºC");
	}
}
