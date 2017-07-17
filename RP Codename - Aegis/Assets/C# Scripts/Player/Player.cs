using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private int amtMoney;
	private List<GameObject> turrets;
	private bool isLocalPlayer;
	[SerializeField]
	private GameObject GM;
	private int player;
	void Start () {
		amtMoney = 300;
		turrets = new List<GameObject> ();
		player = GM.GetComponent<GameMaster> ().AddPlayer(gameObject);
		//adding the player to a list for easier transactions
	}
	public int takeMoney(int amt){
		amtMoney -= amt;
		return amt;
	}
	public void giveMoney(int amt){
		amtMoney += amt;
	}
	public bool canSpend(int amt){
		return amtMoney - amt >= 0;
	}
	public void AddTurret(GameObject n){
		turrets.Add (n);
	}
}
