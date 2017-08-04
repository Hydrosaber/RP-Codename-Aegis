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
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag.Equals("Creep")){
			if (enemies.Count == 0) {
				enemies.Add (coll.gameObject);
				//to take into account of an empty list
				return;
			}
			if (enemies.Contains (coll.gameObject)) {
				return;
				//stops if the list already has the enemy
			}
			for (int i = 0; i < enemies.Count; i++) {
				Creep enemy = enemies[i].GetComponent<Creep> ();
				if(enemy.GetProgress()<coll.gameObject.GetComponent<Creep>().GetProgress()){
					enemies.Insert (i, coll.gameObject);
					//insterts the target on the list in terms of how long has it existed on the map
					return;
				}
			}
			enemies.Add (coll.gameObject);
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag.Equals("Creep")){
			enemies.Remove (other.gameObject);
			//removes after target leaves the range
		}
	}
}
