using UnityEngine;
public class LookPoint : MonoBehaviour {
	void OnDrawGizmos(){
		Gizmos.color=Color.cyan;
		Gizmos.DrawWireSphere(transform.position,.25f);	
	}
}