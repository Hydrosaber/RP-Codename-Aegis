using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepGroup : ScriptableObject{
	private GameObject creep;
	private int amount;
	private bool startSpawn;
	private Transform spawnPlace;
	private float cooldown;
	private GameObject gm;
	private Timer watch;
	public void init(GameObject c, int amt, float cd, Transform t, GameObject master, Timer ti){
		creep = c;
		amount = amt;
		cooldown = cd;
		gm = master;
		spawnPlace = t;
		watch = ti;
	}
	public void SpawnGroup(){
		for (int i = 0; i < amount; i++) {
			GameObject nextCreep = Instantiate (creep, spawnPlace.position, creep.transform.rotation);
			nextCreep.GetComponent<Creep> ().SetGameMaster (gm);
			watch.Wait (cooldown);
		}
	}
}
