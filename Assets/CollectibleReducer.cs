using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleReducer : MonoBehaviour
{
    private Transform[] m_contents;


    // Start is called before the first frame update
    public void Reduce(int _count)
    {
        m_contents=this.GetComponentsInChildren<Transform>();

        for (int i = 0; i<m_contents.Length; i++)
        {
            m_contents[i].gameObject.SetActive(i<_count);
        }
    }


}
