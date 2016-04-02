using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour {

    public Vector2 cursorDir;//variable de direccion de nuestro cursor
    public float mouseSens=2;//+-+
    public float sensPlus;
    public float sensMin;
    public float time = 4;
    float timeA;
    string powerWhat = "NORMAL";


    // Use this for initialization
    void Start () {
        timeA = time;
	}
	
	// Update is called once per frame
	void Update () {

        Cursor.lockState = CursorLockMode.Locked;

        switch (powerWhat)
        {
            case "NORMAL":
                break;
            case "REVERSETIME":
                if (timeA == time)
                {
                    mouseSens = mouseSens * (-1);
                }
                timeA -= Time.deltaTime;
                if (timeA < 0)
                {
                    mouseSens = mouseSens * (-1);
                    timeA = time;
                    powerWhat = "NORMAL";
                }
                break;
            case "SENSPLUS":
                if (timeA == time)
                {
                    mouseSens = mouseSens + sensPlus;
                }
                timeA -= Time.deltaTime;
                if (timeA < 0)
                {
                    mouseSens = mouseSens - sensPlus;
                    timeA = time;
                    powerWhat = "NORMAL";
                }
                break;
            case "SENSMIN":
                if (timeA == time)
                {
                    mouseSens = mouseSens - sensMin;
                }
                timeA -= Time.deltaTime;
                if (timeA < 0)
                {
                    mouseSens = mouseSens + sensMin;
                    timeA = time;
                    powerWhat = "NORMAL";
                }
                break;
        }

	}
    void FixedUpdate()
    {
        cursorDir = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        GetComponent<Rigidbody2D>().velocity=cursorDir*mouseSens;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Damage")){
            powerWhat = "REVERSETIME";
        }else if (coll.gameObject.tag.Equals("DownRever"))
        {

        }

    }
    
}
