//Eriq Taing
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAimingTargeting : MonoBehaviour {
	private int targetMethod;
	[SerializeField]
	private GameObject target;
	[SerializeField]
	private GameObject turretHead;
	[SerializeField]
	private GameObject range;
	// Use this for initialization
	void Start () {
		targetMethod = 0;
		//determines what method to call in TurretScout
		//0 - First Enemy,
		target = null;
		//just in case, so that it doesn't have any predifined targets, and will call the targeting method
		//turretHead = GetComponentInChildren<Transform> ().gameObject;
	}
	void Update(){
		if (target) {
			LookAt2D (target);
			//to face turret top to target creep
			turretHead.GetComponent<TurretFiring> ().changeEnemy (true);
			//to start the turret to fire at the target
			target = null;
			//to reset targeting
		} else {
			switch (targetMethod) {
				case 0://first
					target = range.GetComponent<TurretScout> ().GetFirst ();
					break;
			}
			turretHead.GetComponent<TurretFiring> ().changeEnemy (target);
			//To fire at the target, should it exist, as it would return true if it existed, false otherwise
		}
	}
	void LookAt2D(GameObject target){
		Quaternion rotation = Quaternion.LookRotation
			(target.transform.position - turretHead.transform.position, Vector3.back);
		//looks at targets position, in terms of turretHead being "origin", and the Vector3.back being what is up (dog)
		turretHead.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
		//flatens the rotation so that the object doesn't look warped
	}
	public void changeTargetMethod(int x){
		targetMethod = x;
		//to change targeting method (yet to be implemented in UI)
	}
}
