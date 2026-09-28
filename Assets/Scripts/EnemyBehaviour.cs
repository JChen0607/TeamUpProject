using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayacastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    #endregion

    void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayacastLength, raycastMask);
        }

        if (hit.collider != null)
        {
         EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            StopAttack();
        }
    }

    void onTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && cooling == false)
            {
                timer = intTimer;
                cooling = true;
            }
        }
    }
    void Move()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("SpearStab"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;
        anim.SetBool("Attack", true);
    }

    void StopAttack()
    {
        attackMode = false;
        cooling = false;
        anim.SetBool("Attack", false);
    }

    void RaycastDebugger()
    {
       if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayacastLength, Color.red);
        }
        else
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayacastLength, Color.green);
        }
    }
}