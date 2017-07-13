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
		target = null;
		//turretHead = GetComponentInChildren<Transform> ().gameObject;
	}
	void Update(){
		if (target) {
			LookAt2D (target);
			turretHead.GetComponent<TurretFiring> ().changeEnemy (true);
			target = null;
		} else {
			switch (targetMethod) {
				case 0:
					target = range.GetComponent<TurretScout> ().GetFirst ();
					break;
			}
			turretHead.GetComponent<TurretFiring> ().changeEnemy (target);
		}
	}
	public GameObject GetTarget(){
		return target;
	}
	void LookAt2D(GameObject target){
		Quaternion rotation = Quaternion.LookRotation
			(target.transform.position - turretHead.transform.position, Vector3.back);
		turretHead.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
	}
	public void changeTargetMethod(int x){
		targetMethod = x;
	}
}
