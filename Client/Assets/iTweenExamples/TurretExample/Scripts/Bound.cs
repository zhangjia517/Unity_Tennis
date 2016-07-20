using UnityEngine;
using System.Collections;

public class Bound : MonoBehaviour {
	void OnTriggerEnter (Collider other) {
		Destroy(other.transform.parent.gameObject);
	}
}