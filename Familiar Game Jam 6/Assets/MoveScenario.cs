using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Extensions.System.Colections;

public class MoveScenario : MonoBehaviour {

    public float speed = 0.3f;
    private int numPieces = 0;
    public int maxPieces = 10;
    public List<GameObject> pieces;
    public GameObject finalPiece;

	// Use this for initialization
	void Start () {

        //GameObject piece = (GameObject)Instantiate(pieces.RandomItem(), transform.position + new Vector3(3f, -0.4f), Quaternion.identity);
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
            if(numPieces < maxPieces)
            {
                numPieces++;
                GameObject piece = (GameObject)Instantiate(pieces.RandomItem(), new Vector3(3, -0.4f), Quaternion.identity);
                piece.transform.SetParent(this.transform);

                this.GetComponent<BoxCollider2D>().offset += new Vector2(1, 0);
            }
            else
            {
                GameObject piece = (GameObject)Instantiate(finalPiece, new Vector3(3, -0.4f), Quaternion.identity);
                piece.transform.SetParent(this.transform);
            }
            
        }
    }
}
