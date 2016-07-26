using UnityEngine;
using System.Collections;

public class Gizmo : MonoBehaviour{
	void OnDrawGizmos () {
		Gizmos.DrawWireSphere(transform.position,1);
	}
}

