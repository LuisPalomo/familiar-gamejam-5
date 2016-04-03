using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "x" + GameManager.Instance.lives;
	}
}
