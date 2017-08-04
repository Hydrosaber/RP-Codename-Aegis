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
		green.a = 0.2f;
		red = Color.red;
		red.a = 0.2f;
		counter = 0;
		isValid = false;
		isGreen = true;
		turretRange.GetComponent<SpriteRenderer> ().color = green;
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
		counter++;
	}
	void OnTriggerExit2D(Collider2D other){
		counter--;
	}
	public bool IsValid(){
		return isValid;
	}
}
