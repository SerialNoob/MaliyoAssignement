using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public DanfoData m_carData;

    public UnityEvent OnGameEnd;

    private float m_trackedTime;
    // Start is called before the first frame update
    void Awake()
    {

        m_carData.Reset();

        if (Globals.USE_SEED_GENERATION)
        {
            Random.InitState(Globals.SEED_STRING.GetHashCode());
        }

    }

    public void ComputeCollision()
    {
        m_carData.RemoveLifePoint();
    }

    public void ComputeCollection()
    {
        m_carData.IncreaseFuelPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_carData == null)
        {
            return;
        }

        m_trackedTime+=Time.deltaTime;

        if (m_trackedTime >= m_carData.m_fuelMileage)
        {
            m_trackedTime=0.0f;
            m_carData.RemoveFuelPoint();
            if (m_carData.GetGameState())
                OnGameEnd.Invoke();
        }


    }

}
