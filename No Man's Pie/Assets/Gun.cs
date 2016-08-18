using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public int cdtime = 1000;
	public int cdown = 0;
	public GameObject bullet;
	public float damage = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject nbullet = Instantiate (bullet, transform.position + transform.forward, transform.rotation) as GameObject;
		nbullet.rigidbody.velocity = transform.forward * 32;
	}
}
