using UnityEngine;
using System.Collections;

public class AccurateLob : MonoBehaviour
{
	public Transform target;
	public GameObject bomb;

	void Update ()
	{
		RaycastHit hit = new RaycastHit();
		Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (cameraRay.origin,cameraRay.direction,out hit, 100)) {
			target.position = hit.point;
		}
		
		if (Input.GetMouseButtonDown(0)) {
			GameObject newBomb = (GameObject)Instantiate(bomb);
			Bomb newBombScript = newBomb.GetComponent<Bomb>();
			newBombScript.targetPosition = target.position;
		}
	}
}