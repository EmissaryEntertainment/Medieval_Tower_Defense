﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Created as a parent to the Tower class.
/// This allows the Tower class to inherit from MonoBehaviour
/// </summary>
public class TowerClass : MonoBehaviour
{
    /// <summary>
    /// Main controlling class for all turrets available in the game.
    /// Encapsulates all tower data except for cost into a private variable
    /// </summary>
    public class Tower
    {
        private int attackPower;
        private int towerCost;
        private int attackRange;
        private string towerType;
        private GameObject nextTower;
        private GameObject rangeIdentifier;
        private int gameTicks;

        /// <summary>
        /// Constructs and assigns values for tower based on the tag of the tower in the unity editor.
        /// The only public variable that each tower controls for itself is the cost of the tower
        /// </summary>
        /// <param name="_towerType">
        /// This should be the tag of the tower
        /// </param>
        /// <param name="_rangeIdentifier">
        /// Range identifer object attatched to the tower
        /// </param>
        /// <param name="_towerCost">
        /// The cost of the Tower from it's towerCost variable
        /// </param>
        /// <param name="_gameTicks">
        /// Tracks gameticks from FixedUpdate for the automated tests
        /// </param>
        public Tower(string _towerType, GameObject _rangeIdentifier, int _towerCost, int _gameTicks)
        {
            towerType = _towerType;
            if (towerType == "MachineGunLvl1")
            {
                attackPower = 10;
                towerCost = _towerCost;
                attackRange = 7;
                gameTicks = _gameTicks;
                nextTower = Resources.Load("MachineGun_Lvl2") as GameObject;
                rangeIdentifier = _rangeIdentifier;
            }
            else if (towerType == "MachineGunLvl2")
            {
                attackPower = 25;
                towerCost = _towerCost;
                attackRange = 10;
                gameTicks = _gameTicks;
                nextTower = Resources.Load("MachineGun_Lvl3") as GameObject;
                rangeIdentifier = _rangeIdentifier;
            }
            else if (towerType == "MachineGunLvl3")
            {
                attackPower = 40;
                towerCost = _towerCost;
                attackRange = 12;
                gameTicks = _gameTicks;
                nextTower = null;
                rangeIdentifier = _rangeIdentifier;
            }
        }

        public int GetAttackPower()
        {
            return attackPower;
        }

        public int GetTowerCost()
        {
            return towerCost;
        }

        public int GetAttackRange()
        {
            return attackRange;
        }

        public void SetRangeIdentifier(int _attackRange)
        {
            rangeIdentifier.transform.localScale = new Vector3(_attackRange, .1f, _attackRange);

        }

        public GameObject GetNextTower()
        {
            return nextTower;
        }

        public void UpgradeTower(GameObject _currentTower)
        {
            Instantiate(nextTower, _currentTower.transform.position, _currentTower.transform.rotation, _currentTower.transform.parent.transform);
        }

        public void TrackTarget(Transform _turret, Transform _enemyPosition)
        {
            _turret.LookAt(_enemyPosition);
        }

        public int GetGameTicks()
        {
            return gameTicks;
        }
        public void IncrementGameTicks()
        {
            gameTicks++;
        }
    }
}
