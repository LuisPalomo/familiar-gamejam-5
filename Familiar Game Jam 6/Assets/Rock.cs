using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

    public GameObject spawner;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "RockDestroyer")
        {
            GetComponent<Rigidbody2D>().Sleep();
            transform.position = spawner.transform.position;

        }
    }
}
