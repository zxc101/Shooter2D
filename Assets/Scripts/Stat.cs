using UnityEngine;

namespace Shooter2D.Stats
{
    [System.Serializable]
    public class Stat
    {
        [SerializeField] private int _baseValue;

        public int GetValue()
        {
            return _baseValue;
        }
    }
}
