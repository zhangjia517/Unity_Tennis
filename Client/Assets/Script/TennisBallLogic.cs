using UnityEngine;

public class TennisBallLogic : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
    }

    public void SetRolePos()
    {
        gameObject.transform.position = new Vector3(RoleController.thisScript.transform.position.x, 0.2f, RoleController.thisScript.transform.position.z);
    }

    public void Move()
    {
        iTween.Stop(gameObject);

        gameObject.MoveTo(new Vector3[] { new Vector3(RoleController.thisScript.transform.position.x, 0.3f, 0),
                                          new Vector3(RoleController.thisScript.transform.position.x, 0.05f, 0.666f),
                                          new Vector3(RoleController.thisScript.transform.position.x, 0.15f, 1.3f)},
                                   1f, 0f, EaseType.linear);
    }
}