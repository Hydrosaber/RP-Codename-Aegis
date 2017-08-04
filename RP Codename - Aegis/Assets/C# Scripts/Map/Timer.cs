using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	public IEnumerator Wait(float time){
		yield return new WaitForSeconds (time);
	}
}
