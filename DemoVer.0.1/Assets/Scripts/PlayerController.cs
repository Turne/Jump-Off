using System.Collections;
using UnityEngine;

namespace MyGame
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D playeRigidbody2D;
        public int forcePower;

        Vector3 mousePos;
        bool activeInput;//手势识别使用


        // Use this for initialization
        void Start()
        {
            playeRigidbody2D = GetComponent<Rigidbody2D>();
            //playeRigidbody2D.AddForce(new Vector2(5 * forcePower, 0));

        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }


            if (Input.GetMouseButtonDown(0))
            {
                activeInput = true;
                mousePos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0) && activeInput)
            {
                Vector3 vec = Input.mousePosition - mousePos;

                if (vec.magnitude > 20)
                {
                    float angleXFloat = Vector3.Dot(Vector3.right, vec.normalized);
                    float angleX = Mathf.Acos(angleXFloat) * Mathf.Rad2Deg;

                    if (angleX < 45)//Right
                    {
                        playeRigidbody2D.AddForce(new Vector2(vec.magnitude * forcePower, 0));
                    }
                    else if (angleX >= 135)//Left
                    {
                        playeRigidbody2D.AddForce(new Vector2(-vec.magnitude * forcePower, 0));
                    }
                    //   Debug.Log(inputDirection);
                    activeInput = false;
                }

            }

        }



        //float xAxis = Input.GetAxis("Horizontal");
        //if (Input.GetKey(KeyCode.D))
        //{
        //    playeRigidbody2D.AddForce(new Vector2(xAxis * forcePower, 0));
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    playeRigidbody2D.AddForce(new Vector2(xAxis * forcePower, 0));
        //}
    }


    //IEnumerator OnMouseDown()
    //  {
    //将物体由世界坐标系转化为屏幕坐标系 ，由vector3 结构体变量ScreenSpace存储，以用来明确屏幕坐标系Z轴的位置  
    //Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(transform.position);
    ////完成了两个步骤，1由于鼠标的坐标系是2维的，需要转化成3维的世界坐标系，2只有三维的情况下才能来计算鼠标位置与物体的距离，offset即是距离  
    //Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z));

    ////当鼠标左键按下时  
    //while (Input.GetMouseButton(0))
    //{
    //    playeRigidbody2D.AddForce(new Vector2(offset.x * forcePower, 0));
    //    //这个很主要  
    //    yield return new WaitForFixedUpdate();
    //}
    //  }
    //}
}