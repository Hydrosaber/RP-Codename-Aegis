using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour {
	[SerializeField]
	private int startMoney;
	private int currentAmt;
	// Use this for initialization
	void Start () {
		currentAmt = startMoney;
	}
	public int TakeMoney (int amount){
		currentAmt -= amount;
		return amount;
	}
	public void DepositMoney(int amount){
		currentAmt += amount;
	}
	public void Restart(){
		currentAmt = startMoney;
	}
}
