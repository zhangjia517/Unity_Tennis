using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController thisScript;
    public TennisBallLogic m_Ball = null;

    void Awake()
    {
        thisScript = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
