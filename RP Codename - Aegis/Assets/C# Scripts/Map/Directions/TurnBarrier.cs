using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBarrier : MonoBehaviour {
	public int turnAngle;
	private Quaternion rot;
	// Use this for initialization
	void Start () {
		rot = gameObject.GetComponent<Transform> ().rotation;
		rot *= Quaternion.Euler (0, 0, turnAngle);
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag=="Creep"){
			other.gameObject.GetComponent<Creep> ().Rotate (rot.eulerAngles.z+90);
		}
	}
}
