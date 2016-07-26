using UnityEngine;

public class TennisBallLogic : MonoBehaviour
{
    private Vector3 m_startPos = new Vector3();
    private Vector3 m_endPos = new Vector3();

    private Vector3 m_p1 = new Vector3();

    public Vector3 StartPos
    {
        get
        {
            return m_startPos;
        }

        set
        {
            m_startPos = value;
        }
    }
    public Vector3 EndPos
    {
        get
        {
            return m_endPos;
        }

        set
        {
            m_endPos = value;
        }
    }

    private void Start()
    {
        m_startPos = new Vector3(RoleController.thisScript.transform.position.x, 0.2f, RoleController.thisScript.transform.position.z);
        m_endPos = new Vector3(RoleController.thisScript.transform.position.x + 1, 0.05f, 1.6f);

        m_p1 = Vector3.Lerp(StartPos, EndPos, 0.35f);
        Debug.Log(m_p1);
    }

    private void Update()
    {
    }

    public void SetRolePos()
    {
        gameObject.transform.position = new Vector3(RoleController.thisScript.transform.position.x,
                                                    0.2f,
                                                    RoleController.thisScript.transform.position.z);
    }

    public void Move()
    {
        iTween.Stop(gameObject);

        gameObject.MoveTo(new Vector3[] { 
                                          //new Vector3(RoleController.thisScript.transform.position.x, 0.05f, 0.666f),

                                          //new Vector3(RoleController.thisScript.transform.position.x, 0.15f, 1.3f),
                                          //new Vector3(RoleController.thisScript.transform.position.x, 0.05f, 1.5f),

                                          //new Vector3(RoleController.thisScript.transform.position.x, 0.08f, 1.55f),

                                          new Vector3(m_p1.x, 0.3f, m_p1.z),
                                          m_endPos,
                          }, 2f,
                          0f,
                          EaseType.linear);
    }
}