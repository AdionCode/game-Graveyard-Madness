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
            GameObject.Find("Player").GetComponent<Player>().health -= damage;
            timeToAttack = startTimeToAttack;
            Debug.Log("Musuh Menyerang");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }


}
