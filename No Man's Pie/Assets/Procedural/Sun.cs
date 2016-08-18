using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {
	int pieID = 0;
	float pdist = 0;
	float dlen = 24;
	float dtime = 0;

	// Use this for initialization
	void Start () {
		Random.seed = pieID;
		pieID = GetComponent<PlanetVars> ().pieID;
		pdist = Random.Range (2, 12)+Random.value;
		dtime = 10 / pdist;


	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (new Vector3 (0, 0, 0), new Vector3 (1, 0, 0), 1*Time.deltaTime/dlen);
	}

}
