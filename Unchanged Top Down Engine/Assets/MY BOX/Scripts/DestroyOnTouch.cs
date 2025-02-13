using UnityEngine;

public class DestroyOnTouchHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Destroy(gameObject);
    }
}
