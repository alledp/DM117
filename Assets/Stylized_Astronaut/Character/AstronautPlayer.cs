using UnityEngine;
using System.Collections;

namespace AstronautPlayer
{

	public class AstronautPlayer : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

        private PlayerInventory playerInventory;
        //private TimerComponent timerComponent;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		public float gravity = 20.0f;

        public float jumpSpeed;
        private float ySpeed;

        public int numberOfItems;
        //public float elapsedTime;

		void Start () {

			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
            playerInventory = GetComponent<PlayerInventory>();
            //timerComponent = GetComponent<TimerComponent>();

		}

		void Update (){

            numberOfItems = playerInventory.getNumberOfItems();

            PlayerPrefs.SetString("total_score", numberOfItems.ToString());

            //elapsedTime = timerComponent.getElapsedTime();

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
            float magnitude = Mathf.Clamp01(moveDirection.magnitude) * speed;
            moveDirection.Normalize();

            ySpeed += Physics.gravity.y * Time.deltaTime;

            if (controller.isGrounded)
            {
                ySpeed = -0.5f;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ySpeed = jumpSpeed;
                    anim.SetTrigger("jump");
                }
            }
            
            Vector3 velocity = moveDirection * magnitude;
            velocity.y = ySpeed;

            controller.Move(velocity * Time.deltaTime);

            if(moveDirection != Vector3.zero)
            {
                anim.SetBool("isWalking", true);
                
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed *= 2;
                anim.SetBool("isRunning", true);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed /= 2;
                anim.SetBool("isRunning", false);
            }

        }

    }
}
