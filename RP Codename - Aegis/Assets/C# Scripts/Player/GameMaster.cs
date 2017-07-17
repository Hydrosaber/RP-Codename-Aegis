using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
	private List<GameObject> players;
	private int localPlayer;
	// Use this for initialization
	void Start () {
		players=new List<GameObject>();
	}

	// Update is called once per frame
	void Update () {
		
	}
	public int AddPlayer(GameObject p){
		players.Add (p);
		return players.IndexOf (p);
	}
	public void SpawnTower(Transform p, GameObject t){
		if (players[localPlayer].GetComponent<Player>().canSpend(t.GetComponentInChildren<TurretInfo>().getPrice())) {
			players [localPlayer].GetComponent<Player> ().takeMoney (t.GetComponentInChildren<TurretInfo> ().getPrice ());
			GameObject tower = Instantiate (t, p.position, p.rotation);
			players [localPlayer].GetComponent<Player> ().AddTurret (tower);
		}
	}
}
