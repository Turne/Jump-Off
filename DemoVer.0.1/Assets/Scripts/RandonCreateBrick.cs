using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class RandonCreateBrick : MonoBehaviour
    {
        private float right;
        private float left;
        private float top;
        private float down;
        private float allMoveDist = 0f;
        private static int createIndex = 0;
        private ObjectPool gameObjectPool = new ObjectPool(5);

        public Transform L_Vertical;
        public Transform R_Vertical;
        public GameObject cubePrefab;
        public float intervalCreate = 1f;
        public float brickMoveSpeed = 1f;

        // Use this for initialization
        void Start()
        {
            right = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x;
            top = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y;
            left = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
            down = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

            right -= 2.5f;
            left -= 2.5f;
            CreateBricks();
        }

        // Update is called once per frame
        void Update()
        {
            RecycleObject();
            WallRecycle();
            allMoveDist += brickMoveSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x,
                transform.position.y + Time.deltaTime * brickMoveSpeed, transform.position.z);

            L_Vertical.parent.position = new Vector3(L_Vertical.parent.position.x,
                L_Vertical.parent.position.y + Time.deltaTime * brickMoveSpeed, L_Vertical.parent.position.z);

            if (allMoveDist >= intervalCreate)
            {
                allMoveDist = 0f;
                CreateBricks();
            }
        }

        private void CreateBricks()
        {
            float x = right / 2;
            if (createIndex == 0)
            {
                x = Random.Range(right / 2f, right);
                createIndex = 1;
            }
            else if (createIndex == 1)
            {
                x = Random.Range(0f, right / 2f);
                createIndex = 2;
            }
            else if (createIndex == 2)
            {
                x = Random.Range(-right / 2f, 0);
                createIndex = 3;
            }
            else if (createIndex == 3)
            {
                x = Random.Range(-right, -right / 2f);
                createIndex = 4;
            }
            else if (createIndex == 4)
            {
                x = Random.Range(-right / 2f, 0);
                createIndex = 5;
            }
            else if (createIndex == 5)
            {
                x = Random.Range(0f, right / 2f);
                createIndex = 0;
            }

            GameObject go = gameObjectPool.Spawn(cubePrefab);
            go.name = cubePrefab.name;
            go.transform.SetParent(transform);
            go.transform.position = new Vector3(x, down - intervalCreate, 0);
        }

        private void RecycleObject()
        {
            foreach (var temp in transform.GetComponentsInChildren<Transform>())
            {
                if (temp != transform && temp.position.y > top + 2f)
                {
                    gameObjectPool.DeSpawn(temp.gameObject);
                }
            }
        }

        private void WallRecycle()
        {
            Transform[] tranVertical_L = L_Vertical.GetComponentsInChildren<Transform>();
            Transform[] tranVertical_R = R_Vertical.GetComponentsInChildren<Transform>();
            for (int i = 0; i < tranVertical_L.Length; i++)
            {
                if (tranVertical_L[i] != L_Vertical && tranVertical_L[i].position.y > top + 2f)
                {
                    tranVertical_L[i].position = new Vector3(tranVertical_L[i].position.x,
                        tranVertical_L[i].position.y - 15f, tranVertical_L[i].position.z);

                    tranVertical_R[i].position = new Vector3(tranVertical_R[i].position.x,
                        tranVertical_R[i].position.y - 15f, tranVertical_R[i].position.z);
                }
            }
        }
    }
}