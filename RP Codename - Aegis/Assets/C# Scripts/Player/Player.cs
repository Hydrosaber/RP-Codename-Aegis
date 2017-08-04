using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private int amtMoney;
	private List<GameObject> turrets;
	private bool isLocalPlayer;
	private GameObject UI;
	[SerializeField]
	private GameObject GM;
	void Start () {
		amtMoney = 300;
		turrets = new List<GameObject> ();
		UI = GM.GetComponent<GameMaster> ().AddPlayer(gameObject);
		//adding the player to a list for easier transactions
		UpdateMoney ();
	}
	public int TakeMoney(int amt){
		amtMoney -= amt;
		UpdateMoney();
		return amt;
	}
	public void GiveMoney(int amt){
		amtMoney += amt;
		UpdateMoney();
	}
	public bool CanSpend(int amt){
		return amtMoney - amt >= 0;
	}
	public void AddTurret(GameObject n){
		turrets.Add (n);
	}
	private void UpdateMoney(){
		UI.GetComponent<PlayerInfoBarManager> ().UpdateMoney (amtMoney);
	}
}
