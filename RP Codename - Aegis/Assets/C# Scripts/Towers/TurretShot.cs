using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShot : MonoBehaviour {
	[SerializeField]
	private int damage;
	[SerializeField]
	private GameObject splash;
	[SerializeField]
	private string typeDamage;
	private bool hasHit;
	private GameObject parent;
	void Start(){
		hasHit = false;
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag=="Creep"&&!hasHit){
			if(!string.IsNullOrEmpty(typeDamage)){
				other.gameObject.GetComponent<Creep> ().Damage (damage, typeDamage);
			}else{
				other.gameObject.GetComponent<Creep> ().Damage (damage);
			}
			hasHit = true;
			if(splash){
				var s = Instantiate (splash, gameObject.transform);
				Destroy (s, 0.2f);
			}
			Destroy (gameObject);
		}
	}
}
