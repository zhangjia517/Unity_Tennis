using UnityEngine;
public class MovePoint : MonoBehaviour {
	void OnDrawGizmos(){
		Gizmos.color=Color.magenta;
		Gizmos.DrawWireSphere(transform.position,.25f);	
	}
}
