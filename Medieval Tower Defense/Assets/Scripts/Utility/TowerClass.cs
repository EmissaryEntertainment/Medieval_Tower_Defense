using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerClass : MonoBehaviour
{
    public class Tower
    {
        private int attackPower;
        private int towerCost;
        private int attackRange;
        private GameObject rangeIdentifier;

        public Tower(int _attackPower, int _towerCost, int _attackRange, GameObject _rangeIdentifier)
        {
            attackPower = _attackPower;
            towerCost = _towerCost;
            attackRange = _attackRange;
            rangeIdentifier = _rangeIdentifier;
        }

        public void SetAttackPower(int _attackPower)
        {
            attackPower = _attackPower;
        }
        public int GetAttackPower()
        {
            return attackPower;
        }

        public void SetTowerCost(int _towerCost)
        {
            towerCost = _towerCost;
        }
        public int GetTowerCost()
        {
            return towerCost;
        }

        public void SetAttackRange(int _attackRange)
        {
            attackRange = _attackRange;
        }
        public int GetAttackRange()
        {
            return attackRange;
        }

        public void SetRangeIdentifier(int _attackRange)
        {
            rangeIdentifier.transform.localScale = new Vector3(_attackRange, .1f, _attackRange);

        }

        public void TrackTarget(Transform _turret, Transform _enemyPosition)
        {
            _turret.LookAt(_enemyPosition);
        }
        public void Attack(GameObject _enemy)
        {
            
        }
    }
}
