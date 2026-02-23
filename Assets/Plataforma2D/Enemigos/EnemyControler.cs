
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Normal,
    Flying
}

public enum EnemyState
{
    Idle,
    Patrol
}

public class EnemyControler : MonoBehaviour
{
    [Header("Basic Data")]
    StatsComponent stats;

    [SerializeField] EnemyType enemyType= EnemyType.Normal;
    [SerializeField] EnemyState enemyState= EnemyState.Idle;


    [Header("Idle state")]
    [SerializeField] float idleTime = 1f;
    [SerializeField] float idleTimer = 0f;

    [Header("patrol state")]
    [SerializeField] List<Transform> patrolsPoints;
    List<Vector3> patrolsPositions;
    [SerializeField] int target=0;

    Rigidbody2D rb;
    //IGrounded2D grounded2D;

    void Start()
    {
        stats = GetComponent<StatsComponent>();
        rb = GetComponent<Rigidbody2D>();
        //grounded2D = GetComponentChildren<IGrounded2D>();
        target = 0;

        //Inicilize patrols positions to avoid witch us
        patrolsPositions = new();
        foreach (Transform point in patrolsPoints)
        {
            patrolsPositions.Add(point.position);
        }
        patrolsPositions.Add(transform.position);

        //si es enemigo volador, desactivo la gravedad
        if (enemyType == EnemyType.Flying) rb.gravityScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyState)
        {
            case EnemyState.Idle:
                UpdateIdle();
                break;
            case EnemyState.Patrol:
                UpdatePatrol();
                break;
        }
    }
    void UpdateIdle()
    {
        idleTimer += Time.deltaTime;
        if (idleTime < idleTimer)
        {
            idleTime = 0f;
            enemyState = EnemyState.Patrol;
        }
    }
    void UpdatePatrol()
    {
        if(Vector2.Distance(transform.position, patrolsPositions[target]) > 1.5f)//si no hemos llegado, avanzamos hasta el objetivo
        {
            int targetDirectionX = patrolsPositions[target].x > transform.position.x ? 1 : -1;
            if (Mathf.Abs(patrolsPositions[target].x - transform.position.x) < 0.1f) targetDirectionX = 0;
            int targetDirectionY = patrolsPositions[target].y > transform.position.y ? 1 : -1;
            if (Mathf.Abs(patrolsPositions[target].y - transform.position.y) < 0.1f) targetDirectionY = 0;


            rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, stats.stats.moveSpeed * targetDirectionX, stats.stats.moveSpeed);
            rb.linearVelocityY = Mathf.Lerp(rb.linearVelocityY, stats.stats.moveSpeed * targetDirectionY, stats.stats.moveSpeed);
        }
        else //si hemos llegado
        {
            rb.linearVelocityX = 0;
            rb.linearVelocityY = 0;
            target =(target +1)% patrolsPositions.Count; //pasamos añ siguiente objetivo
            enemyState = EnemyState.Idle;
        }


    }
}
