using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemies {
    public class EnemyManager : MonoBehaviour
    {
        public GameObject _enemyPrefab;
        public List<EnemyCard> _cards = new List<EnemyCard>();

        private void Awake()
        {
            Core.enemies = this;
            _enemyPrefab.SetActive(false);
        }
        void Start()
        {
            GameEvents.OnRunTic.AddListener(TicUpdate);
            GameEvents.OnEndRun.AddListener(RunEndCleanup);
            for (int i = 0; i < _cards.Count; i++)
            {
                _cards[i]._cardID = i;
            }
        }

        private void RunEndCleanup()
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
                GameObject newEnemy = Instantiate(_enemyPrefab);
                newEnemy.transform.SetParent(this.transform);
                EnemyMover mover = newEnemy.GetComponent<EnemyMover>();
                EnemyCourse course = Core.Routes.GetRoute(card._route);
                mover._route = course.Name;
                mover._plotCourse = course.Plots;
                newEnemy.transform.position = course.Spawnpoint.position;
                newEnemy.GetComponent<EnemyHealth>().ResetToSpawnValues();
                mover.ResetOnSpawn();
                newEnemy.SetActive(true);
                yield return new WaitForSeconds(card._interval);
            }
        }
    }
}