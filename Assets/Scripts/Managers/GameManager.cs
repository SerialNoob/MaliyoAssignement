using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public DanfoData m_carData;

    public UnityEvent OnGameEnd;
    public UnityEvent OnGameStart;
    public UnityEvent<float> OnScoreAvailable;
    public UnityEvent<string> OnAchievementAvailable;
    public TextMeshProUGUI m_displayText;

    private float m_trackedTime;
    private float m_mileage;
    private bool m_edgingRefuel;
    // Start is called before the first frame update
    void Awake()
    {

        m_carData.Reset();

        if (Globals.USE_SEED_GENERATION)
        {
            Random.InitState(Globals.SEED_STRING.GetHashCode());
        }

        Time.timeScale=0;

        m_mileage=0;
        OnGameStart.Invoke();
    }

    public void ComputeCollision()
    {
        m_carData.RemoveLifePoint();
    }

    public void StartGame()
    {
        Time.timeScale=1;
    }

    public void ComputeCollection()
    {
        m_carData.IncreaseFuelPoint();
        if (m_edgingRefuel)
        {
            Debug.Log("Close shave Achievement !");
            //TODO: GPS Call here
            OnAchievementAvailable.Invoke(Globals.CLOSESHAVEACHIEVEMENT_ID);
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_carData == null)
        {
            return;
        }

        m_trackedTime+=Time.deltaTime;

        m_edgingRefuel= m_trackedTime>m_carData.m_fuelMileage-.5f && m_trackedTime<m_carData.m_fuelMileage && m_carData.m_fuelLevel<2;

        if (m_trackedTime >= m_carData.m_fuelMileage)
        {
            
            m_carData.RemoveFuelPoint();
            if (m_carData.GetGameState())
            {
                OnGameEnd.Invoke();
                OnScoreAvailable.Invoke(m_mileage);
                Time.timeScale=0;
                Analytics.CustomEvent("PartyOver", new Dictionary<string, object>()
                {
                    { "Mileage", m_mileage},
                    { "GameTime", Time.timeSinceLevelLoad },
                    { "PositionOscreenAtDeath", this.transform.position }
                });
            }
            m_trackedTime=0.0f;
        }

        m_mileage+=Time.deltaTime;
        m_displayText.text=((int)m_mileage).ToString();
    }

}
