using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Enemies
{
    [System.Serializable]
    public class EnemyCard : MonoBehaviour
    {
        [UnityEngine.HideInInspector]
        public int _cardID = -1;
        public ENEMYTYPE _type = ENEMYTYPE.UNSET;
        public int _spawnOnTic = -1;
        public bool _loops = false;
        public bool _reversed = false;
        public bool _used = true;
        public SPAWNSIDE _side = SPAWNSIDE.RIGHT;
        public ROUTENAMES _route = ROUTENAMES.UNSET;
        public int _amount = 0;
        [UnityEngine.Range(0.05f, 4.0f)]
        public float _interval = 0.3f;
    }
}
