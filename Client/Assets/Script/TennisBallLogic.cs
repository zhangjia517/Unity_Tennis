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

    public void SetPath(float rightOffset)
    {
        Debug.Log(rightOffset);
        m_trail.Clear();
        m_startPos = new Vector3(m_RoleController.transform.position.x, 0.25f, m_RoleController.transform.position.z + 0.1f);
        float tX = 0;
        if (rightOffset > 0) tX = 1.1f;
        if (rightOffset < 0) tX = -1.1f;
        m_endPos = new Vector3(tX, 0.005f, 1.8f);
        gameObject.transform.position = m_startPos;

        m_p1 = ErYuanYiCiForZeroPoint(m_startPos, m_endPos, 0, 0.45f);
        m_p2 = ErYuanYiCiForZeroPoint(m_startPos, m_endPos, 1, 0.005f);
        m_p3 = ErYuanYiCiForZeroPoint(m_startPos, m_endPos, 1.5f, 0.15f);
        m_p4 = ErYuanYiCiForZeroPoint(m_startPos, m_endPos, 1.7f, 0.005f);
        m_p5 = ErYuanYiCiForZeroPoint(m_startPos, m_endPos, 1.75f, 0.07f);
    }

    public void Move()
    {
        iTween.Stop(gameObject);
        gameObject.MoveTo(new Vector3[] {m_p1,
                                         m_p2,
                                         m_p3,
                                         m_p4,
                                         m_p5,
                                         m_endPos,
                          },
                          2f,
                          0f,
                          EaseType.linear);
    }

    public Vector3 ErYuanYiCiForZeroPoint(Vector3 s, Vector3 e, float zPos, float height)
    {
        float k, b;
        k = (e.x - s.x) / (e.z - s.z);
        b = s.x - (k * s.z);

        Vector3 centPos = new Vector3(zPos * k + b, height, zPos);
        return centPos;
    }
}