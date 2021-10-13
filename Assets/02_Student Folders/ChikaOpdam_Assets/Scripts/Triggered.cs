using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    [Tooltip("Representes group that will trigger together")]
    public int groupColor;

    gimmickManager m_gimmicManager;

    private void Start()
    {
        m_gimmicManager = GameObject.FindObjectOfType<gimmickManager>();
        DebugUtility.HandleErrorIfNullFindObject<gimmickManager, Triggered>(m_gimmicManager, this);

        // Register as part of group
        if (!m_gimmicManager.triggereds.Contains(this))
        {
            m_gimmicManager.triggereds.Add(this);
        }
    }
}
