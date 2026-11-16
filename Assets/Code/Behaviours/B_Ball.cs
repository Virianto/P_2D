using UnityEngine;

/// <summary>
/// Control de la bola
/// </summary>
public class B_Ball : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField]
    GameObject joint;
    public M_GameManager gameManager;
    GameObject boost;

    #endregion

    #region METHODS

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Wall_1"))
        {
            //boost = collision.gameObject;
            //boost.GetComponent<BoxCollider2D>().isTrigger = false;
            joint.GetComponent<SliderJoint2D>().enabled = true;
            joint.GetComponent<SliderJoint2D>().useMotor = false;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        
    //}

    #endregion
}
