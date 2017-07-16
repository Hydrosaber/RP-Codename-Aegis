//Eriq Taing
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
		//for purchases
		currentAmt -= amount;
		return amount;
		//for depositing money to allies
	}
	public void DepositMoney(int amount){
		currentAmt += amount;
		//donations
	}
	public void Restart(){
		currentAmt = startMoney;
		//when game over and restart
	}
}
