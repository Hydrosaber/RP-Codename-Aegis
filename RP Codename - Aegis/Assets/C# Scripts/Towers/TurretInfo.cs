using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretInfo : MonoBehaviour {
	[SerializeField]
	private string turretName;
	[SerializeField]
	private int cost, creepCount;
	// Use this for initialization
	void Start () {
		if (string.IsNullOrEmpty (turretName)) {
			turretName="Unknown";
		}
		if(cost<=0){
			cost = 150;
		}
	}
	public int getPrice(){
		return cost;
	}
	public string getName(){
		return turretName;
	}
}
