using UnityEngine;
using System.Collections;

public class HelixDead : MonoBehaviour {

    public float velHelix;

	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(0,0,Time.deltaTime* velHelix);
	}
}
