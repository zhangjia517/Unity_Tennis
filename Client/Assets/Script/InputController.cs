using UnityEngine;

public class InputController : MonoBehaviour
{
    public float MoveSpeed = 1.0f;

    private RoleController m_RoleController;

    private void Start()
    {
        m_RoleController = RoleController.thisScript;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_RoleController.HitBall(PLAYER_HIT.zhengshou);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_RoleController.HitBall(PLAYER_HIT.fanshou);
        }

        #region 人物移动

        if (m_RoleController.m_curPlayerState == PLAYER_STATE.Move)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                m_RoleController.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed * 0.6f, Space.World);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                m_RoleController.gameObject.transform.Translate(Vector3.back * Time.deltaTime * MoveSpeed * 0.6f, Space.World);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                m_RoleController.gameObject.transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed * 0.75f, Space.World);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                m_RoleController.gameObject.transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed * 0.75f, Space.World);
            }
        }

        #endregion 人物移动
    }
}