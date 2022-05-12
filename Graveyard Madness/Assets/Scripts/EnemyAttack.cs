using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float timeToAttack;
    [SerializeField] private float startTimeToAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;

    public bool dalamJankauan;
    public Animator animator;


    void Start()
    {
        dalamJankauan = GetComponent<EnemyChase>().isAttackRange;
        timeToAttack -= Time.deltaTime;
    }

    void Update()
    {
        Attack();
        timeToAttack -= Time.deltaTime;
    }

    public void Attack()
    {
        if (timeToAttack <= 0 && !dalamJankauan)
        {
            animator.SetBool("isAttack", true);
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
            {
                GameObject.Find("Player").GetComponent<Player>().health -= damage;
                Debug.Log("Musuh Menyerang");
                timeToAttack = startTimeToAttack;
            }
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            animator.SetBool("isAttack", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }


}
