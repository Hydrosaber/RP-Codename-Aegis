using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {
	[SerializeField]
	private GameObject playerUI;
	private int localPlayer;
	[SerializeField]
	private GameObject start;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}
	public GameObject AddPlayer(GameObject p){
		return playerUI.GetComponent<PlayerInfoUI> ().AddPlayer (p);
	}
	public void Profit(int amt){
		playerUI.GetComponent<PlayerInfoUI>().Profit(amt);
	}
	public void SpawnTower(Transform p, GameObject t){
		List<GameObject> players = playerUI.GetComponent<PlayerInfoUI>().GetPlayers();
		if (players[localPlayer].GetComponent<Player>().CanSpend(t.GetComponentInChildren<TurretInfo>().getPrice())) {
			players [localPlayer].GetComponent<Player> ().TakeMoney (t.GetComponentInChildren<TurretInfo> ().getPrice ());
			GameObject tower = Instantiate (t, p.position, p.rotation);
			players [localPlayer].GetComponent<Player> ().AddTurret (tower);
		}
	}
	public void StartTestCreepWave(int choice){
		start.GetComponent<CreepSpawner> ().NewWave(choice);
	}
	public void CreepDamage (int amt){
		playerUI.GetComponent<PlayerInfoUI> ().CreepDamage (amt);
	}
	public void Death(){
		
	}
	public void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
