using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class ObjectPool
    {
        private List<GameObject> gameObjectPool = new List<GameObject>();
        private int capacity;

        public ObjectPool(int capacity)
        {
            this.capacity = capacity;
        }

        /// <summary>
        /// 取对象池中的一个对象
        /// </summary>
        /// <param name="poolObject"></param>
        /// <returns></returns>
        public GameObject Spawn(GameObject go)
        {
            GameObject temp = null;
            for (int i = 0; i < gameObjectPool.Count; i++)
            {
                temp = gameObjectPool[i];
                temp.SetActive(true);
                gameObjectPool.RemoveAt(i);
                return temp;
            }

            temp = GameObject.Instantiate(go);
            return temp;
        }

        /// <summary>
        /// 将对象放回对象池中
        /// </summary>
        /// <param name="go"></param>
        public void DeSpawn(GameObject go)
        {
            go.SetActive(false);
            gameObjectPool.Add(go);
            KeepPoolCount();
        }

        private void KeepPoolCount()
        {
            while (gameObjectPool.Count > capacity)
            {
                GameObject go = gameObjectPool[0];
                gameObjectPool.RemoveAt(0);
                GameObject.Destroy(go);
            }
        }
    }
}
