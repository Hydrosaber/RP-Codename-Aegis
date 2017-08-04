using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCastle : MonoBehaviour {
	[SerializeField]
	private GameObject gameMaster;
	void OnTriggerEnter2D(Collider2D coll){
		GameObject intruder = coll.gameObject;
		if(intruder.tag=="Creep"){
			gameMaster.GetComponent<GameMaster> ().CreepDamage (intruder.GetComponent<Creep>().GetDamage());
			Object.Destroy (intruder);
		}
	}
}
