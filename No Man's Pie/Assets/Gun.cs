using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public int cdtime = 1000;
	public int cdown = 0;
	public GameObject ray;
	public float damage = 1;
	bool shooting = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			shooting = true;

			//nbullet.GetComponent<Rigidbody> ().velocity = transform.forward * 32;
		}
		if (Input.GetMouseButtonUp (0)) {
			shooting = false;
		}
		if (!shooting) {
			ray.transform.localScale = Vector3.zero;
		}
		else {
			ray.transform.localScale = new Vector3(1,1,1);
			ray.transform.rotation = transform.rotation;
			ray.transform.localPosition = new Vector3 (0.5f, -1, 0);
		}
	}
}
