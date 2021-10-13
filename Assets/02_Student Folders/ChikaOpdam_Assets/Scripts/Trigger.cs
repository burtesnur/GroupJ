using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [Tooltip("Representes group that will be triggered by this")]
    public int groupColor;

    gimmickManager m_gimmicManager;
    private void Start()
    {
        m_gimmicManager = GameObject.FindObjectOfType<gimmickManager>();
        DebugUtility.HandleErrorIfNullFindObject<gimmickManager, Trigger>(m_gimmicManager, this);

        // Register as part of group
        if (!m_gimmicManager.triggers.Contains(this))
        {
            m_gimmicManager.triggers.Add(this);
        }
    }
}
