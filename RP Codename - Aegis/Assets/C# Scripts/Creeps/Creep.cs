using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : MonoBehaviour {
	private float progress;
	[SerializeField]
	private int speedTier;
	private Rigidbody2D body;
	private Vector2 speedOrientation;
	private float changeCooldown;
	private float speedMultiplier;
	[SerializeField]
	private GameObject nextTier;
	// Use this for initialization
	void Start () {
		changeCooldown = -100f;
		body = gameObject.GetComponent<Rigidbody2D> ();
		progress = 0;
		if(speedTier<=0){
			speedTier = 1;
		}
		speedMultiplier = 1;
		ResetSpeed ();
	}
	// Update is called once per frame
	void Update () {
		progress += Time.deltaTime;
		if (changeCooldown > 0) {
			changeCooldown -= Time.deltaTime;
		} else if (changeCooldown > -100) {
			ResetSpeed ();
			changeCooldown = -100;
		}
	}
	public float getProgress(){
		return progress;
	}
	public void setProgress(float x){
		progress = x;
	}
	public void damage(){
		if (!(nextTier == null)) {
			var kin = Instantiate (nextTier, transform.position, transform.rotation);
			kin.GetComponent<Creep> ().setProgress (progress);
		}
		Destroy (gameObject);
	}
	public void UpdateSpeed(float multiplier){
		speedOrientation.x /= speedMultiplier;
		speedOrientation.y /= speedMultiplier;
		speedMultiplier *= multiplier;
		speedOrientation.x *= speedMultiplier;
		speedOrientation.y *= speedMultiplier;
		body.velocity = speedOrientation;
		changeCooldown = 3.0f;
	}
	public void ResetSpeed(){
		Rotate (gameObject.transform.rotation.eulerAngles.z+90);
	}
	public void Rotate(float angle){
		float radians = angle * Mathf.PI / 180;
		float x = Mathf.Cos (radians);
		float y = Mathf.Sin (radians);
		float c = Mathf.Sqrt (Mathf.Pow(x,2)+Mathf.Pow(y,2));
		float multiplier = Mathf.Abs((speedTier * speedMultiplier * 0.5f) / c);
		speedOrientation.x = x * multiplier;
		speedOrientation.y = y * multiplier;
		body.velocity = speedOrientation;
		gameObject.transform.rotation = Quaternion.Euler (0, 0, angle-90);
	}
}
