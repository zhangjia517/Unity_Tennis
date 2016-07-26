using UnityEngine;

public class Waypoint : MonoBehaviour {
	void OnDrawGizmos(){
		Gizmos.color=Color.yellow;
		Gizmos.DrawWireSphere(transform.position,1);
	}
}
