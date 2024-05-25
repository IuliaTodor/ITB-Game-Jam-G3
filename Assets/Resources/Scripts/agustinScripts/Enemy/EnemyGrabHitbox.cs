using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyGrabHitbox : MonoBehaviour
{
    [SerializeField] private bool _isEnemyGrabed;
    public bool isEnemyGrabed { get {  return _isEnemyGrabed; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Prey"))
            Grab(other.transform);
    }

    private void Grab(Transform prey)
    {
        _isEnemyGrabed = true;
        prey.SetParent(transform);
        prey.localPosition = Vector3.zero;
    }
}
