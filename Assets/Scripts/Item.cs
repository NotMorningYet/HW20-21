using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidBody;

    public void SetKinematic()
    {
        _rigidBody.isKinematic = true;
    }

    public void SetPhysic()
    {
        _rigidBody.isKinematic = false;
    }
}
