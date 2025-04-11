using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private Rigidbody2D rb;
        private Animator animator;

        private Vector2 moveInput;
        private Vector2 lastMoveDir = Vector2.down;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            Walk();
        }

        private void Walk()
        {
            GetLastMoveDir();
            float moveX = 0f;
            float moveY = 0f;
            moveX = GetHorizontalMovement(moveX);
            moveY = GetVerticalMovement(moveY);
            moveInput = new Vector2(moveX, moveY).normalized;
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            animator.SetFloat("MoveX", lastMoveDir.x);
            animator.SetFloat("MoveY", lastMoveDir.y);
            animator.SetBool("IsMoving", moveInput.magnitude > 0.1f);
        }

        private static float GetVerticalMovement(float moveY)
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) moveY = -1f;
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) moveY = 1f;
            return moveY;
        }

        private static float GetHorizontalMovement(float moveX)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) moveX = -1f;
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) moveX = 1f;
            return moveX;
        }

        private void GetLastMoveDir()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) lastMoveDir = Vector2.up;
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) lastMoveDir = Vector2.down;
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) lastMoveDir = Vector2.left;
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) lastMoveDir = Vector2.right;
        }

        void FixedUpdate()
        {
            rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        }
        
        public Vector2 GetLookDirection()
        {
            return lastMoveDir;
        }

    }
}