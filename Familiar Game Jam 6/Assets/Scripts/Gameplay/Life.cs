using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	public float velocidad;



	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (new Vector2 (velocidad, 0),Space.World);
	}
} 
