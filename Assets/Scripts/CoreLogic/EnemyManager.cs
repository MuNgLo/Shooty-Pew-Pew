using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemies {
    public class EnemyManager : MonoBehaviour
    {
        public int EnemyCount { get { return CountEnemies(); } private set {} }

        public GameObject _basicEnemyPrefab;
        public GameObject _shooterEnemyPrefab;
        public GameObject _spammerEnemyPrefab;
        public List<EnemyCard> _cards = new List<EnemyCard>();
        private Transform _deck;
        private void Awake()
        {
            Core.enemies = this;
            _basicEnemyPrefab.SetActive(false);
            _shooterEnemyPrefab.SetActive(false);
            _spammerEnemyPrefab.SetActive(false);
        }
        void Start()
        {
            GameEvents.OnRunTic.AddListener(TicUpdate);
            GameEvents.OnEndRun.AddListener(Cleanup);
            GameEvents.OnStartRun.AddListener(Cleanup);
            _deck = this.transform.parent.Find("EnemyCards");
            if(_deck == null) { Debug.LogError("Could not find EnemyCards!"); return; }
            int i = 0;
            foreach (Transform child in _deck)
            {
                if (child.GetComponent<EnemyCard>())
                {
                    _cards.Add(child.GetComponent<EnemyCard>());
                    _cards[i]._cardID = i;
                    i++;
                }
            }
        }

        private int CountEnemies()
        {
            int i = 0;
            foreach (Transform child in transform)
            {
                i++;
            }
            return i;
        }

        private void Cleanup()
        {
            foreach(Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            foreach(EnemyCard card in _cards)
            {
                card._used = false;
            }
        }

        void TicUpdate(int tic)
        {
            List<EnemyCard> ticCards = _cards.FindAll(p => p._spawnOnTic <= tic && p._used == false);
            foreach(EnemyCard card in ticCards)
            {
                StartCoroutine("SpawnCard", card);
            }
        }

        IEnumerator SpawnCard(EnemyCard card)
        {
            _cards.Find(p => p._cardID == card._cardID)._used = true;
            for (int i = 0; i < card._amount; i++)
            {
                
                EnemyCourse course = new EnemyCourse() { Name = ROUTENAMES.UNSET };
                switch (card._side)
                {
                    case SPAWNSIDE.TOP:
                        course = Core.Routes.GetVerticalRoute(card._route);
                        break;
                    case SPAWNSIDE.RIGHT:
                        course = Core.Routes.GetRightRoute(card._route);
                        break;
                    default:
                        course = Core.Routes.GetRightRoute(card._route);
                        break;
                }
                if (course.Name != ROUTENAMES.UNSET)
                {
                    GameObject newEnemy = GrabEnemyPrefab(card._type);
                    if (newEnemy != null)
                    {
                        newEnemy.transform.SetParent(this.transform);
                        EnemyMover mover = newEnemy.GetComponent<EnemyMover>();
                        mover._loop = card._loops;
                        mover._route = course.Name;
                        mover._plotCourse.AddRange(course.Plots);
                        if (card._reversed)
                        {
                            mover._plotCourse.RemoveAt(mover._plotCourse.Count - 1);
                            mover._plotCourse.Reverse();
                            mover._plotCourse.Add(course.Spawnpoint);
                            newEnemy.transform.position = course.AltSpawnpoint.position;
                        }
                        else
                        {
                            newEnemy.transform.position = course.Spawnpoint.position;
                        }
                        if (mover._loop)
                        {
                            mover._plotCourse.RemoveAt(mover._plotCourse.Count -1);
                        }
                        newEnemy.GetComponent<EnemyHealth>().ResetToSpawnValues();
                        mover.ResetOnSpawn();
                        newEnemy.SetActive(true);
                    }
                }else{
                    Debug.LogWarning($"EnemyManager:: Could not find valid route on enemy card with id [{card._cardID}]");
                }
                yield return new WaitForSeconds(card._interval);
            }
        }

        private GameObject GrabEnemyPrefab(ENEMYTYPE type)
        {
            switch (type)
            {
                case ENEMYTYPE.UNSET:
                    return null;
                case ENEMYTYPE.BASIC:
                    return Instantiate(_basicEnemyPrefab);
                case ENEMYTYPE.SHOOTER:
                    return Instantiate(_shooterEnemyPrefab);
                case ENEMYTYPE.SPAMMER:
                    return Instantiate(_spammerEnemyPrefab);
                default:
                    return Instantiate(_basicEnemyPrefab);
            }
        }
    }
}