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
        [SerializeField] private SpriteRenderer balanceFill;
        [SerializeField] private float maxStaminaWidth;
        [SerializeField] private float maxBalanceWidth;

        Inventory inventory;

        public float period;

        [SerializeField] private Sprite[] sprites;
        [SerializeField] private SpriteRenderer playerSprite;
        
        [SerializeField] private Rigidbody2D rb;
        private Vector2 dir;

        private float balanceValue;
        private int inventoryWeight;


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
            maxStaminaWidth = staminaFill.size.x;
            maxBalanceWidth = balanceFill.size.x;

            currentStamina = 1;
            moveState = MoveState.Walking;
            animator = GetComponent<Animator>();
            //   playerCollision = GetComponentInChildren<Collider2D>();

            // The value for amount the meter should be filled to
            balanceValue = 0;

            // The weight of the total inventory
            inventoryWeight = 0;

            // The time period between losing balance again
            period = 0.0f;

            StartCoroutine("CheckBalance");
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
                    playerSprite.sprite = sprites[2];
                    // animator.Play(moveState == MoveState.Walking ? "Walk A" : "Run A");
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    dir.x = 1;
                    animator.SetInteger("Direction", 2);
                    playerSprite.sprite = sprites[3];
                    // animator.Play(moveState == MoveState.Walking ? "Walk D" : "Run D");
                }

                if (Input.GetKey(KeyCode.W))
                {
                    dir.y = 1;
                    animator.SetInteger("Direction", 1);
                    playerSprite.sprite = sprites[0];
                    // animator.Play(moveState == MoveState.Walking ? "Walk W" : "Run W");
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    dir.y = -1;
                    animator.SetInteger("Direction", 0);
                    playerSprite.sprite = sprites[1];
                    // animator.Play(moveState == MoveState.Walking ? "Walk S" : "Run S");
                }
                if(Input.GetKey(KeyCode.K))
                {
                    if(balanceValue >= 0.2f)
                    {
                        balanceValue -= 0.2f;
                    }                  
                }
                if (Input.GetKey(KeyCode.L))
                {
                    if(balanceValue <=0.8f)
                    {
                        balanceValue -= 0.2f;
                    }
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
            staminaFill.size = new Vector2(currentStamina * maxStaminaWidth, staminaFill.size.y);
            if (currentStamina <= 0)
            {
                rb.velocity = Vector2.zero;
                moveState = MoveState.Recovering;
            }

            if(period > 10f)
            {
                inventoryWeight = inventory.GetTotalItemCount();
                if (inventoryWeight >= 5)
                {
                    balanceValue += 0.2f;
                }
                Mathf.Clamp(balanceValue, 0, 1);
                balanceFill.size = new Vector2(balanceValue * maxBalanceWidth, balanceFill.size.y);

                period = 0;
            }
            period += Time.deltaTime;
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
