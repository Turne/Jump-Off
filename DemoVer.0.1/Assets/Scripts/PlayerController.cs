using UnityEngine;
namespace MyGame
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D playeRigidbody2D;

        public int forcePower;

        // Use this for initialization
        void Start()
        {
            playeRigidbody2D = GetComponent<Rigidbody2D>();
            //playeRigidbody2D.AddForce(new Vector2(5 * forcePower, 0));

        }

        // Update is called once per frame
        void Update()
        {


            float xAxis = Input.GetAxis("Horizontal");
            if (Input.GetKey(KeyCode.D))
            {
                playeRigidbody2D.AddForce(new Vector2(xAxis * forcePower, 0));
            }

            if (Input.GetKey(KeyCode.A))
            {
                playeRigidbody2D.AddForce(new Vector2(xAxis * forcePower, 0));
            }
        }

    }
}