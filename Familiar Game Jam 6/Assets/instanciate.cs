using UnityEngine;
using System.Collections;

public class instanciate : MonoBehaviour {

    public AudioClip music;

	// Use this for initialization
	void Start () {
        var gm = GameManager.Instance;
        var am = AudioManager.Instance;
        AudioManager.Instance.PlayMusic(music);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
