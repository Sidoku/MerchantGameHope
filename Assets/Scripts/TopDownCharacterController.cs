using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float moveSpeed;
        [SerializeField] private float sprintSpeed;
        [SerializeField][Range(0, 1)] private float currentStamina;
        [SerializeField][Range(0, 0.2f)] private float sprintStaminaLoss;
        [SerializeField] private float staminaRegen;
        [SerializeField] private GameObject staminaBar;
        [SerializeField] private SpriteRenderer staminaFill;
        [SerializeField] private float maxWidth;

        [SerializeField] private Rigidbody2D rb;
        private Vector2 dir;

        private enum MoveState
        {
            Recovering,
            Walking,
            Sprinting
        }

        [SerializeField] private MoveState moveState;

        private Animator animator;

       // public SpriteRenderer playerSpriteRenderer;
       // public SpriteRenderer playerShadowRenderer;

       // public Collider2D playerCollision;

       // public Rigidbody2D playerRigidBody2D;

        private void Start()
        {
            maxWidth = staminaFill.size.x;
            currentStamina = 1;
            moveState = MoveState.Walking;
            animator = GetComponent<Animator>();
         //   playerCollision = GetComponentInChildren<Collider2D>();
        }

       // [Header("Jumping")]
       // public AnimationCurve jumpCurve;

       // bool isJumping = false;


        private void Update()
        {
            if(moveState != MoveState.Recovering)
            {
                moveState = Input.GetKey(KeyCode.LeftShift) ? MoveState.Sprinting : MoveState.Walking;
                dir = Vector2.zero;
                if (Input.GetKey(KeyCode.A))
                {
                    dir.x = -1;
                    animator.SetInteger("Direction", 3);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    dir.x = 1;
                    animator.SetInteger("Direction", 2);
                }

                if (Input.GetKey(KeyCode.W))
                {
                    dir.y = 1;
                    animator.SetInteger("Direction", 1);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    dir.y = -1;
                    animator.SetInteger("Direction", 0);
                }
                /*if(Input.GetKey(KeyCode.Space))
                {
                    Jump(1.0f, 0.0f);
                }*/

                dir.Normalize();
                animator.SetBool("IsMoving", dir.magnitude > 0);
                if (moveState == MoveState.Sprinting && currentStamina > 0 && dir != Vector2.zero)
                {
                    currentStamina -= sprintStaminaLoss * Time.deltaTime;
                    rb.velocity = sprintSpeed * dir;
                }
                else
                {
                    currentStamina += staminaRegen * Time.deltaTime;
                    rb.velocity = moveSpeed * dir;
                }
            }
            else
            {
                if (currentStamina >= 1)
                {
                    moveState = MoveState.Walking;
                }
                currentStamina += staminaRegen * Time.deltaTime;
            }
            
            currentStamina = Mathf.Clamp(currentStamina, 0, 1);
            staminaBar.SetActive(!(currentStamina >= 1));
            staminaFill.size = new Vector2(currentStamina * maxWidth, staminaFill.size.y);
            if (currentStamina <= 0)
            {
                rb.velocity = Vector2.zero;
                moveState = MoveState.Recovering;
            }
        }

       /* public void Jump(float jumpHeightScale, float jumpPushScale)
        {
            if(!isJumping)
            {
                StartCoroutine(JumpCo(jumpHeightScale, jumpPushScale));
            }
        }

        private IEnumerator JumpCo(float jumpHeightScale, float jumpPushScale)
        {
            isJumping = true;

            float jumpStartTime = Time.time;
            float jumpDuration = 1.0f;                         //playerRigidBody2D.velocity.magnitude * 0.25f;

            jumpHeightScale = jumpHeightScale * playerRigidBody2D.velocity.magnitude * 0.5f;
            jumpHeightScale = Mathf.Clamp(jumpHeightScale, 0.0f, 1.0f);

            //Disable collisions
            playerCollision.enabled = false;

            while (isJumping) 
            {
                //Percentage 0 - 1.0 of where we are in the jump process
                float jumpCompletedPercentage = (Time.time - jumpStartTime) / jumpDuration;
                jumpCompletedPercentage = Mathf.Clamp01(jumpCompletedPercentage);

                //Increase the scale of the sprite
                playerSpriteRenderer.transform.localScale = Vector3.one + Vector3.one * jumpCurve.Evaluate(jumpCompletedPercentage) * jumpHeightScale;

                //Increase the scale of the shadow
                playerShadowRenderer.transform.localScale = playerSpriteRenderer.transform.localScale * 0.75f;

                //Offset shadow position

                playerShadowRenderer.transform.localPosition = new Vector3(1, -1, 0.0f) * 3 * jumpCurve.Evaluate(jumpCompletedPercentage)* jumpHeightScale;

                if (jumpCompletedPercentage == 1.0f)
                    break;

                yield return null;
            }

            playerSpriteRenderer.transform.localScale = Vector3.one;

            //Reset the shadows position and scale
            playerShadowRenderer.transform.localPosition = Vector3.zero;
            playerShadowRenderer.transform.localScale = playerSpriteRenderer.transform.localScale;

            //Enable the collider after landing
            playerCollision.enabled = true;

            //Change jump state
            isJumping= false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Jump"))
            {
                //Get the jump data
                JumpData jumpData = collision.GetComponent<JumpData>();
                Jump(jumpData.jumpHeightScale, jumpData.jumpPushScale);
            }
        }*/
    }
}
