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
        private string towerType;
        private GameObject rangeIdentifier;

        public Tower(string _towerType, GameObject _rangeIdentifier)
        {
            towerType = _towerType;
            if(towerType == "MachineGunLvl1")
            {
                attackPower = 20;
                towerCost = 100;
                attackRange = 10;
                rangeIdentifier = _rangeIdentifier;
            }
            else if(towerType == "EMPLvl1")
            {
                attackPower = 25;
                towerCost = 200;
                attackRange = 7;
                rangeIdentifier = _rangeIdentifier;
            }
            
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
