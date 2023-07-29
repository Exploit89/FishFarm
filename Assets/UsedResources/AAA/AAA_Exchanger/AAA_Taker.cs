using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AAA_Taker : MonoBehaviour
{
    [SerializeField] private List<AAAStack> _stacks;
    [SerializeField] private AAAStackMover _stackMover;

    public List<AAAStack> GetStacks()
    {
        List<AAAStack> stacks = new List<AAAStack>();
        stacks = _stacks;
        return stacks;
    }
}
