using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeapStack : MonoBehaviour
{
    class Knight
    {
        public int hp;
        public int attack;

        public void Attack()
        {
            attack = 10;
        }

        public void Clone()
        {

        }
    }

    struct Mage
    {
        public int hp;
        public int attack;
    }

    void Start()
    {
        Mage mage;
        mage.hp = 100;
        mage.attack = 50;

        Mage mage2 = mage;
        mage2.hp = 0;

        Knight knight = new Knight();
        knight.hp = 100;
        knight.attack = 10;

        //Knight knight2 = knight.Clone();
    }

    void KillKinght(Knight knight)
    {
        knight.hp = 0;
    }

    void KillMage(Mage mage)
    {
        mage.hp = 0;
    }
}
