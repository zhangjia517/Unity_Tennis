using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController thisScript;
    public TennisBallLogic m_Ball = null;

    private void Awake()
    {
        thisScript = this;
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}