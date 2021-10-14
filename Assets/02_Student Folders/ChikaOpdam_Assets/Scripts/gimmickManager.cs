using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gimmickManager : MonoBehaviour
{
    public List<Trigger> triggers { get; private set; }
    public List<Triggered> triggereds { get; private set; }

    private void Awake()
    {
        triggereds = new List<Triggered>();
        triggers = new List<Trigger>();
    }

}
