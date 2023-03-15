using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Complete
{
    public static class TankPool<Tank> where Tank : TankAI
    {
        private static Stack<Tank> pool = new Stack<Tank>();
        
        public static void PushTank(Tank tank)
        {
            tank.gameObject.SetActive(false);
            pool.Push(tank);
        }

        public static Tank PopTank()
        {
            if (pool.Count > 0)
            {
                Tank tank = pool.Pop();
                tank.gameObject.SetActive(true);
                return tank;
            }
            else
            {
                if(typeof(Tank) == typeof(TankAISpitter))
                {
                    GameObject go = GameManager.Instance.SpawnTankAISpitter();
                    Tank tank = go.GetComponent<Tank>();
                    return tank;
                }
                else
                {
                    GameObject go = GameManager.Instance.SpawnTankAICharger();
                    Tank tank = go.GetComponent<Tank>();
                    return tank;
                }
            }
        }
    }
}
