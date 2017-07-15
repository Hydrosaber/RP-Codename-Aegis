using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFiring : MonoBehaviour {
	[SerializeField]
	private float cooldown;
	private float timer;
	[SerializeField]
	private GameObject ammo;
	private bool hasEnemy;
	void Start () {
		if (cooldown <= 0) {
			cooldown = 20;
			//fire cooldown default: 20 sec
		}
		timer = 0;
		//so that it will fire once the enemy reaches in the range
		hasEnemy = false;
	}
	void LateUpdate () {
		if(timer>0){
			timer = timer - Time.deltaTime;
			//depletes timer until it reaches past 0
		}
		if(timer<=0&&hasEnemy){
			//after cooldown, it waits for an enemy to appear
			StartCoroutine(Fire ());
			//uses coroutine so that it can wait a moment before firing, as not doing so results in firing before turning
			timer = cooldown;
			//resets cooldown;
		}
	}
	IEnumerator Fire (){
		yield return new WaitForSecondsRealtime (0.000001f);
		//waiting a moment to aim
		var tempShot = Instantiate (ammo, transform.position-(Vector3.back/2), transform.rotation);
		tempShot.GetComponent<Rigidbody2D> ().velocity = tempShot.transform.up * 10;
		//NetworkServer.Spawn (tempShot);
		Destroy (tempShot, 1.0f);
		//destroys the object to conserve space and processing
	}
	public void changeEnemy(bool hE){
		hasEnemy = hE;
	}
}
