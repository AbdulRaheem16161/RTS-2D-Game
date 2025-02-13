using UnityEngine;

[ExecuteAlways]
public class BaseScript : MonoBehaviour
{
    [SerializeField] protected bool a;


    void Update()
    {
        TestValue();
    }

    public virtual void TestValue()
    {
       a = true;
    }

}
