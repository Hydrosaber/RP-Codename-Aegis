using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creep : MonoBehaviour {
	[SerializeField]
	private int healthMax;
	private int health;
	private float progress;
	[SerializeField]
	private int speedTier;
	private Rigidbody2D body;
	private Vector2 speedOrientation;
	private float changeCooldown;
	private float speedMultiplier;
	[SerializeField]
	private GameObject nextTier;
	[SerializeField]
	private Image healthBar;
	[SerializeField]
	private float z;
	// Use this for initialization
	void Start () {
		health = healthMax;
		if(z==0){
			z = gameObject.transform.rotation.eulerAngles.z + 90f;
		}
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
		progress += Time.deltaTime*speedTier;
		if (changeCooldown > 0) {
			changeCooldown -= Time.deltaTime;
		} else if (changeCooldown > -100) {
			ResetSpeed ();
			changeCooldown = -100;
		}
	}
	public float GetProgress(){
		return progress;
	}
	public void SetProgress(float x){
		progress = x;
	}
	public void Damage(int dam){
		health -= dam;
		if (health <= 0) {
			Death ();
		}
		healthBar.fillAmount = health / healthMax;
	}
	public void Damage(int dam, string type){
		if(type=="Glue"){
			UpdateSpeed (0.5f);
		}
		if(type=="Frozen"){
			UpdateSpeed (0);
		}
		health -= dam;
		if (health <= 0) {
			Death ();
		}
		healthBar.fillAmount = (float)health / healthMax;
	}
	void Death(){
		if (!(nextTier == null)) {
			GameObject kin = Instantiate (nextTier, transform.position, transform.rotation);
			kin.GetComponent<Creep> ().SetProgress (progress);
			kin.GetComponent<Creep> ().Rotate (z);
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
		speedMultiplier = 1;
		Rotate (z);
	}
	public void Rotate(float angle){
		if(body==null){
			body = gameObject.GetComponent<Rigidbody2D> ();
		}
		float radians = angle * Mathf.PI / 180;
		float x = Mathf.Cos (radians);
		float y = Mathf.Sin (radians);
		float c = Mathf.Sqrt (Mathf.Pow(x,2)+Mathf.Pow(y,2));
		float multiplier = Mathf.Abs((speedTier * speedMultiplier * 0.5f) / c);
		speedOrientation.x = x * multiplier;
		speedOrientation.y = y * multiplier;
		body.velocity = speedOrientation;
		z = angle;
	}
}
