using UnityEngine;

public class TennisBallLogic : MonoBehaviour
{
    private Vector3 m_startPos = new Vector3();
    private Vector3 m_endPos = new Vector3();

    private Vector3 m_p1 = new Vector3();
    private Vector3 m_p2 = new Vector3();
    private Vector3 m_p3 = new Vector3();
    private Vector3 m_p4 = new Vector3();
    private Vector3 m_p5 = new Vector3();

    private RoleController m_RoleController;

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
        m_RoleController = RoleController.thisScript;
    }

    private void Update()
    {
    }

    public void SetRolePos()
    {
        m_startPos = new Vector3(m_RoleController.transform.position.x, 0.2f, m_RoleController.transform.position.z);
        m_endPos = new Vector3(m_RoleController.transform.position.x - 1f, 0.05f, 1.5f);

        m_p1 = ErYuanYiCiForZeroPoint(m_startPos, m_endPos);
        m_p2 = Vector3.Lerp(StartPos, EndPos, 0.7f);
        m_p3 = Vector3.Lerp(StartPos, EndPos, 0.85f);
        m_p4 = Vector3.Lerp(StartPos, EndPos, 0.9f);
        m_p5 = Vector3.Lerp(StartPos, EndPos, 0.95f);

        gameObject.transform.position = m_startPos;
    }

    public void Move()
    {
        iTween.Stop(gameObject);

        gameObject.MoveTo(new Vector3[] {new Vector3(m_p1.x, 0.45f, m_p1.z),
                                         new Vector3(m_p2.x, 0.05f, m_p2.z),
                                         new Vector3(m_p3.x, 0.2f, m_p3.z),
                                         new Vector3(m_p4.x, 0.05f, m_p4.z),
                                         new Vector3(m_p5.x, 0.1f, m_p5.z),
                                         m_endPos,
                          },
                          2f,
                          0f,
                          EaseType.linear);
    }

    public Vector3 ErYuanYiCiForZeroPoint(Vector3 s, Vector3 e)
    {
        float k, b;
        k = (e.x - s.x) / (e.z - s.z);
        b = s.x - (k * s.z);

        Vector3 centPos = new Vector3(b, 0.5f, 0);
        return centPos;
    }
}