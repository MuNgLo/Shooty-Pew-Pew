using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enemies
{
    [System.Serializable]
    public class EnemyCard
    {
        [UnityEngine.HideInInspector]
        public int _cardID = -1;
        public int _spawnOnTic = -1;
        public bool _used = true;
        public string _route = string.Empty;
        public int _amount = 0;
        [UnityEngine.Range(0.05f, 4.0f)]
        public float _interval = 0.3f;
    }
}
