using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DanfoData m_carData;

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
        m_trackedTime+=Time.deltaTime;

        if (m_trackedTime >= m_carData.m_fuelMileage)
        {
            m_trackedTime=0.0f;
            m_carData.RemoveFuelPoint();
        }
    }

}
