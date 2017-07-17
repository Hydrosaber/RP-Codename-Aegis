using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacer : MonoBehaviour {
	[SerializeField]
	private GameObject towerPF, indicatorPF, towerTopAppearance, GMaster;
	private GameObject indicator;
	public void StartTowerPlacing(){
		indicator = Instantiate (indicatorPF, gameObject.transform.position, gameObject.transform.rotation);
		indicator.SetActive (true);
		towerTopAppearance.SetActive (false);
		gameObject.GetComponent<Image> ().color = new Color (0,0,0,0);
	}
	public void EndPlacing(){
		if(indicator.GetComponent<TowerPlacingIndicator>().IsValid()){
			GMaster.GetComponent<GameMaster> ().SpawnTower(indicator.transform, towerPF);
		}
		towerTopAppearance.SetActive (true);
		gameObject.GetComponent<Image> ().color = new Color (255,255,255,255);
		Destroy (indicator);
	}

}
