using UnityEngine;
using TMPro;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public enum EnemyState
{
    Level1,
    Level2
}

public class Enemy : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Player player;
    public Animator animator;
    public GameObject enemyAttackCollider;
    public GameObject wood;

    [Header("Enemy Info")]
    public EnemyState enemyState;
    public int level;
    public TextMeshProUGUI levelText;
    [SerializeField] private List<Transform> wayPoints;

    private NavMeshAgent navMeshAgent;
    private int currentTarget;
    private float distance;
    private bool targetReached;
    private bool isRotating;

    private const float TargetReachedDistance = 1.0f;
    private const float WaypointChangeDelay = 2.0f;
    private const float RotationDuration = 2.0f;
    private const float RotationAmount = 180.0f;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        levelText.text = string.Format("Lv. {0}", level);
        UpdateLevelTextColor();
    }

    private void Update()
    {
        UpdateLevelTextColor();

        if (enemyState == EnemyState.Level2 && !isRotating)
        {
            StartCoroutine(Level2Movement());
        }
        else if (enemyState == EnemyState.Level1)
        {
            StartCoroutine(Level1Movement());
        }
    }

    private IEnumerator Level1Movement()
    {
        if (wayPoints.Count > 0 && wayPoints[currentTarget] != null)
        {
            navMeshAgent.SetDestination(wayPoints[currentTarget].position);
            distance = Vector3.Distance(transform.position, wayPoints[currentTarget].position);

            if (distance < TargetReachedDistance)
            {
                animator.SetBool("Move", false);
            }
            else
            {
                animator.SetBool("Move", true);
            }

            if (distance < TargetReachedDistance && !targetReached)
            {
                targetReached = true;
                yield return new WaitForSeconds(WaypointChangeDelay);
                targetReached = false;
                currentTarget = (currentTarget + 1) % wayPoints.Count;
            }
        }
    }

    private IEnumerator Level2Movement()
    {
        isRotating = true;

        float startRotation = transform.rotation.eulerAngles.y;
        float targetRotation = startRotation + RotationAmount;

        while (true)
        {
            float startTime = Time.time;
            float endTime = startTime + RotationDuration;

            while (Time.time < endTime)
            {
                float t = (Time.time - startTime) / RotationDuration;
                float newRotation = Mathf.Lerp(startRotation, targetRotation, t);
                transform.rotation = Quaternion.Euler(0, newRotation, 0);
                yield return null;
            }

            yield return new WaitForSeconds(WaypointChangeDelay);

            startRotation = transform.rotation.eulerAngles.y;
            targetRotation = startRotation + RotationAmount;
        }
    }

    private void UpdateLevelTextColor()
    {
        if (player != null)
        {
            if (player.level < level)
            {
                levelText.color = Color.red;
            }
            else if (player.level > level)
            {
                levelText.color = Color.green;
            }
            else
            {
                levelText.color = Color.white;
            }
        }
    }

    public void AttackPoint()
    {
        enemyAttackCollider.SetActive(true);
    }

    public void AttackEnd()
    {
        enemyAttackCollider.SetActive(false);
    }
}
