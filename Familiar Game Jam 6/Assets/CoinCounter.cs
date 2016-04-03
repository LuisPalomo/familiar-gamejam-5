using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "" + GameManager.Instance.coins;
    }
}
