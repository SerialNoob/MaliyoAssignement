using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public DifficultyUnit[] m_difficultiesList;
    public AnimationCurve m_progressionCurve;

    public DifficultyUnit GetProperDifficultyUnit(float _currentMileage)
    {
        Debug.Log((int)m_progressionCurve.Evaluate(_currentMileage));
        return m_difficultiesList[(int)m_progressionCurve.Evaluate(_currentMileage)];
    }
}
