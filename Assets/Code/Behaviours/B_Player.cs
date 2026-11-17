using UnityEngine;

/// <summary>
/// Aqui va el enunciado del proposito de esta clase
/// </summary>
public class B_Player : MonoBehaviour
{
    #region ATTRIBUTES
    [SerializeField]
    KeyCode leftKey = KeyCode.A;
    [SerializeField]
    KeyCode rightKey = KeyCode.D;
    [SerializeField]
    KeyCode jumpKey = KeyCode.W;
    [SerializeField]
    KeyCode downKey = KeyCode.S;

    [SerializeField]
    [Range(0, 10)]
    float playerSpeed = 1;
    #endregion


    #region METHODS
    private void Update()
    {
        if (Input.GetKey(leftKey))
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(rightKey))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(jumpKey))
        {
            transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(downKey))
        {
            transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);
        }
    }
    #endregion
}
