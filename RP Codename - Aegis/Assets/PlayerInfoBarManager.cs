using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoBarManager : MonoBehaviour {
	[SerializeField]
	private Text playerName, amtMoney;
	[SerializeField]
	private GameObject isLocal;
	public void UpdateName(string n){
		playerName.text = n;
	}
	public void UpdateMoney(int amt){
		amtMoney.text = "$" + amt;
	}
	public void setLocal(bool state){
		isLocal.SetActive (state);
	}
}
