using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelDisplay : MonoBehaviour
{
    public DanfoData m_dataSet; // Dependency can be moved up 
    public Transform m_rootBarDisplay;
    private List<Image> m_barDisplayLs;

    // Start is called before the first frame update
    void Start()
    {
        m_barDisplayLs=new List<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i<Globals.MAX_FUEL; i++)
        {
            m_rootBarDisplay.GetChild(i).gameObject.SetActive(i<m_dataSet.m_fuelLevel);
        }
    }
}
