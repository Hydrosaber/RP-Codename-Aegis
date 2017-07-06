using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour {
	[System.Serializable]
	private int startMoney;
	private int currentAmt;
	// Use this for initialization
	void Start () {
		currentAmt = startMoney;
	}
	public int takeMoney (int amount){
		currentAmt -= amount;
		return amount;
	}
	public void depositMoney(int amount){
		currentAmt += amount;
	}
}
