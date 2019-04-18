using System.Collections.Generic;
using UnityEngine;

public class FixedUpdateController : MonoBehaviour
{
    private readonly List<IFixedUpdate> _fixedUpdateList = new List<IFixedUpdate>();
    
    public void AddFixedUpdate(IFixedUpdate fixedUpdate)
    {
        _fixedUpdateList.Add(fixedUpdate);
    }

    public void RemoveFixedUpdate(IFixedUpdate fixedUpdate)
    {
        _fixedUpdateList.Remove(fixedUpdate);
    }

    private void FixedUpdate()
    {
        foreach (IFixedUpdate fixedUpdate in _fixedUpdateList)
        {
            fixedUpdate.OnFixedUpdate();
        }
    }
}
