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
    private TrailRenderer m_trail;

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
        m_trail = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
    }

    public void SetRolePos()
    {
        m_trail.enabled = false;
        m_startPos = new Vector3(m_RoleController.transform.position.x, 0.2f, m_RoleController.transform.position.z);
        m_endPos = new Vector3(m_RoleController.transform.position.x - 1f, 0.05f, 1.8f);
        gameObject.transform.position = m_startPos;

        m_p1 = ErYuanYiCiForZeroPoint(m_startPos, m_endPos, 0);
        m_p2 = ErYuanYiCiForZeroPoint(m_startPos, m_endPos, 1);
        m_p3 = ErYuanYiCiForZeroPoint(m_startPos, m_endPos, 1.5f);
        m_p4 = ErYuanYiCiForZeroPoint(m_startPos, m_endPos, 1.7f);
        m_p5 = ErYuanYiCiForZeroPoint(m_startPos, m_endPos, 1.75f);
    }

    public void Move()
    {
        m_trail.enabled = true;
        iTween.Stop(gameObject);
        gameObject.MoveTo(new Vector3[] {new Vector3(m_p1.x, 0.45f, m_p1.z),
                                         new Vector3(m_p2.x, 0.05f, m_p2.z),
                                         new Vector3(m_p3.x, 0.15f, m_p3.z),
                                         new Vector3(m_p4.x, 0.05f, m_p4.z),
                                         new Vector3(m_p5.x, 0.07f, m_p5.z),
                                         m_endPos,
                          },
                          2f,
                          0f,
                          EaseType.linear);
    }

    public Vector3 ErYuanYiCiForZeroPoint(Vector3 s, Vector3 e, float zPos)
    {
        float k, b;
        k = (e.x - s.x) / (e.z - s.z);
        b = s.x - (k * s.z);

        Vector3 centPos = new Vector3(zPos * k + b, 0.5f, zPos);
        return centPos;
    }
}