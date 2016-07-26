using UnityEngine;

public class InputController : MonoBehaviour
{
    public float MoveSpeed = 1.0f;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            RoleController.thisScript.HitBall(PLAYER_HIT.zhengshou);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            RoleController.thisScript.HitBall(PLAYER_HIT.fanshou);
        }

        #region 人物移动

        if (Input.GetKey(KeyCode.UpArrow))
        {
            RoleController.thisScript.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed * 0.8f, Space.World);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            RoleController.thisScript.gameObject.transform.Translate(Vector3.back * Time.deltaTime * MoveSpeed * 0.8f, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RoleController.thisScript.gameObject.transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            RoleController.thisScript.gameObject.transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed, Space.World);
        }

        #endregion 人物移动
    }
}