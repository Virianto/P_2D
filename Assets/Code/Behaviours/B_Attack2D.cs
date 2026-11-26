using System.Collections;
using UnityEngine;

public class B_Attack2D : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    Collider2D attackCollider;

    [SerializeField]
    float attackDuration = 0.5f;

    #endregion





    #region METHODS

    public void Attack()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        EnableAttackCollider();
        yield return new WaitForSeconds(attackDuration);
        DisableAttackCollider();
    }

    public void EnableAttackCollider()
    {
        attackCollider.enabled = true;
    }

    public void DisableAttackCollider()
    {
        attackCollider.enabled = false;
    }

    #endregion
}
