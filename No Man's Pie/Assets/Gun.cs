using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public int cdtime = 1000;
	public int cdown = 0;
	public GameObject ray;
	public float damage = 128;
	bool shooting = false;
	GameObject selected;
	float hp = 10;
	float maxhp = 10;
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
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward,out hit, 100)) {
				if (Vector3.Distance (hit.collider.gameObject.transform.position, transform.position) > 1f) {
					if (hit.collider.gameObject == selected) {
						hp -= damage/(float)(hit.collider.gameObject.GetComponent<Collider>().bounds.size.magnitude);

					} else {
						hp = maxhp;
						selected = hit.collider.gameObject;
					}
					if (hp <= 0) {
						Destroy (selected);
						hp = maxhp;
					}
				}
			}
		}
	}
	void DrawQuad(Rect position, Color color) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}
	void OnGUI () {
		DrawQuad (new Rect (0, 0, (maxhp-hp)*(Screen.width/maxhp),20), new Color (1, 0, 0));

	}
}
