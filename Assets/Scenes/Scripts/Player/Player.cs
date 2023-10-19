using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Components")]
    public Animator animator;
    [SerializeField] private JoystickMove moveStick;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private GameObject attackCollider;

    [Header("Player Info")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    public int level;
    public TextMeshProUGUI levelText;
    public bool isDead;

    private Vector2 moveInput;

    private void Start()
    {
        if (moveStick != null)
        {
            moveStick.onStickValueUpdated += MoveStickUpdated;
        }

        level = 1;
        if (levelText != null)
        {
            levelText.text = "Lv. " + level.ToString();
        }
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (characterController == null)
            return;

        characterController.Move(new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime * moveSpeed);

        if (moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(moveInput.x, 0, moveInput.y));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        float speed = moveInput.magnitude;
        animator.SetFloat("Speed", speed);
    }

    private void MoveStickUpdated(Vector2 inputValue)
    {
        if (!isDead)
        {
            moveInput = inputValue;
            gameObject.SetActive(true);
        }
    }

    public void AttackPoint()
    {
        if (attackCollider != null)
        {
            attackCollider.SetActive(true);
        }
    }

    public void AttackEnd()
    {
        if (attackCollider != null)
        {
            attackCollider.SetActive(false);
        }
    }
}
