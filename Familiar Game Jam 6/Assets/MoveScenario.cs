using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Extensions.System.Colections;

public class MoveScenario : MonoBehaviour {

    public float speed = 0.3f;
    public List<GameObject> piezas;

	// Use this for initialization
	void Start () {

        //GameObject piece = (GameObject)Instantiate(piezas.RandomItem(), transform.position + new Vector3(3f, -0.4f), Quaternion.identity);
        //piece.transform.SetParent(this.transform);

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ScenarioGen")
        {
            GameObject piece = (GameObject)Instantiate(piezas.RandomItem(), transform.position + new Vector3(3f, -0.4f), Quaternion.identity);
            piece.transform.SetParent(this.transform);
        }
    }
}
