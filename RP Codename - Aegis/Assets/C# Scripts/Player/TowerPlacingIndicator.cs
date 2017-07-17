using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacingIndicator : MonoBehaviour {
	[SerializeField]
	private GameObject turretRange;
	private int counter;
	private bool isValid, isGreen;
	private Color green, red;
	// Use this for initialization
	void Start () {
		green = Color.green;
		green.a = 30;
		red = Color.red;
		red.a = 30;
		counter = 0;
		isValid = false;
		isGreen = true;
		turretRange.GetComponent<SpriteRenderer> ().color = Color.green;
	}
	// Update is called once per frame
	void Update () {
		var mouse = Input.mousePosition;
		mouse.z = 58;
		gameObject.transform.position = Camera.main.ScreenToWorldPoint(mouse);
		isValid = counter == 0;
		if(isValid&&!isGreen){
			turretRange.GetComponent<SpriteRenderer> ().color = green;
			isGreen = true;
		}else if(!isValid&&isGreen){
			turretRange.GetComponent<SpriteRenderer> ().color = red;
			isGreen = false;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("collided");
		counter++;
	}
	void OnTriggerExit2D(Collider2D other){
		Debug.Log ("something cleared");
		counter--;
	}
	public bool IsValid(){
		return isValid;
	}
}
