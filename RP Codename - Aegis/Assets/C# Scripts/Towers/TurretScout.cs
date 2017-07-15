using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScout : MonoBehaviour {
	[SerializeField]
	private List<GameObject> enemies;
	void Start () {
		enemies = new List<GameObject> ();
	}
	public GameObject GetFirst(){
		enemies.RemoveAll (obj => obj == null);
		if (enemies.Count == 0) {
			return null;
			//if has no enemies in range, returns null
		}
		return enemies [0];
		//returns oldest enemy
	}
	void OnTriggerStay2D(Collider2D coll){
		if(coll.gameObject.tag.Equals("Creep")){
			if (enemies.Count == 0) {
				enemies.Add (coll.gameObject);
				//to take into account of an empty list
			}
			if (enemies.Contains (coll.gameObject)) {
				return;
				//stops if the list already has the enemy
			}
			for (int i = 0; i < enemies.Count; i++) {
				Creep enemy = coll.gameObject.GetComponent<Creep> ();
				if(enemy.GetProgress()>enemies[i].GetComponent<Creep>().GetProgress()){
					enemies.Insert (i, coll.gameObject);
					//insterts the target on the list in terms of how long has it existed on the map
				}
			}
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag.Equals("Creep")){
			enemies.Remove (other.gameObject);
			//removes after target leaves the range
		}
	}
}
