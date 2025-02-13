using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Destroy(gameObject);
    }
}
