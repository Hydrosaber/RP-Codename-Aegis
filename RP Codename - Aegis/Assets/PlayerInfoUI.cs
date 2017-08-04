using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//need to break the script up and make another group for player group as a whole
public class PlayerInfoUI : MonoBehaviour {
	[SerializeField]
	private GameObject[] playerUIs;
	private List<GameObject> players;
	[SerializeField]
	private Text healthUI;
	private int health;
	// Use this for initialization
	void Start () {
		health = 300;
		if (players == null) {
			players = new List<GameObject> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		healthUI.text = "Health: " + health;
	}
	public void UpdateAmtPlayers(){
		int amtP = players.Count;
		switch (amtP){
		case 4:
			playerUIs [3].SetActive (true);
			playerUIs [2].SetActive (true);
			playerUIs [1].SetActive (true);
			playerUIs [0].SetActive (true);
			break;
		case 3:
			playerUIs [2].SetActive (true);
			playerUIs [1].SetActive (true);
			playerUIs [0].SetActive (true);
			break;
		case 2:
			playerUIs [1].SetActive (true);
			playerUIs [0].SetActive (true);
			break;
		default:
			playerUIs [0].SetActive (true);
			break;
		}
	}
	public void Profit(int amt){
		for(int i=0;i<players.Count;i++){
			players[i].GetComponent<Player> ().GiveMoney (amt);
		}
	}
	public GameObject AddPlayer(GameObject p){
		if (players == null) {
			players = new List<GameObject> ();
		}
		players.Add (p);
		UpdateAmtPlayers ();
		Debug.Log (players.IndexOf (p));
		return playerUIs[players.IndexOf (p)];
	}
	public void CreepDamage (int amt){
		health -= amt;
		if(health<0){
			health = 0;
		}
	}
	public List<GameObject> GetPlayers(){
		return players;
	}
}
