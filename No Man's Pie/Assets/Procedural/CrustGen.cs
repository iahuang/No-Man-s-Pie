using UnityEngine;
using System.Collections;

public class CrustGen : MonoBehaviour {
	int pieID;
	Color crustClr;
	float devi;
	int size;
	float gen_r = 1;
	float gen_deg = 0;
	int gen_rot = 0;
	float step = 0;
	public GameObject blob;
	float roughness = 0;
	float blobsize = 10;
	// Use this for initialization
	void Start () {
		step = gen_r * 2 * Mathf.PI;
		pieID = GetComponent<PlanetVars> ().pieID;
		Random.seed = pieID;
		crustClr = new Color (Random.value, Random.value * 0.9f, Random.value * 0.2f);
		devi = Random.value * 0.05f;
		size = Random.Range (50, 100);

		while (Random.value < 0.6) {
			blobsize += Random.value*5f;
		}
		roughness = Random.value*30;

		while (!Gen_Blob()) {
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Gen_Blob ();
	}
	Color Gen_Clr () {
		return new Color(crustClr.r+(Random.value*(devi*2)-devi),crustClr.g+(Random.value*(devi*2)-devi),crustClr.b+(Random.value*(devi*2)-devi));
	}
	Quaternion Gen_Rot () {
		return new Quaternion (Random.value*360, Random.value*360, Random.value*360,Random.value);
	}
	bool Gen_Blob () {
		GameObject nBlob = Instantiate (blob, new Vector3 (Mathf.Cos (Mathf.Deg2Rad*gen_deg) * gen_r+Random.value*blobsize*0.7f, 
			Random.value*roughness
			, Mathf.Sin (Mathf.Deg2Rad*gen_deg) * gen_r+Random.value*roughness), Gen_Rot()) as GameObject;
		nBlob.GetComponent<Renderer>().material.color = Gen_Clr();
		nBlob.transform.localScale = new Vector3 (blobsize + (Random.value)*roughness,blobsize + (Random.value)*blobsize*0.7f,blobsize + (Random.value)*roughness);
		gen_deg += 360/step*blobsize;
		if (gen_deg >= 360) {
			gen_deg = 0;
			gen_r+=blobsize;
			step = gen_r * 2 * Mathf.PI;
			if (gen_r/blobsize >= size) {
				return true;
			}
		}
		return false;

	}
}
