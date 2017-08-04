using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepSpawner : MonoBehaviour {
	[SerializeField]
	private GameObject[] creeps;
	[SerializeField]
	private int[] creepCounts;
	[SerializeField]
	private int wave;
	private int groupAmount;
	[SerializeField]
	private GameObject gameMaster;
	private float spawnDelay, timer;
	private int selection;
	void Start () {
		selection = 0;
		wave = 1;
		spawnDelay = 1f;
		timer = spawnDelay;
	}
	void Update () {
		timer -= Time.deltaTime;
		if(timer<=0&&groupAmount>0){
			GameObject nextCreep = Instantiate (creeps [selection], gameObject.transform.position, creeps[selection].transform.rotation);
			nextCreep.GetComponent<Creep> ().SetGameMaster (gameMaster);
			groupAmount--;
			timer = spawnDelay;
		}
	}
	public void NewWave(int choice){
		selection = choice;
		groupAmount = creepCounts [selection];
	}

}
