using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyGrabHitbox : MonoBehaviour
{
    [SerializeField] private bool _isEnemyGrabed;
    public bool isEnemyGrabed { get {  return _isEnemyGrabed; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Prey"))
            if (other.gameObject.TryGetComponent(out MipController mipController) && !mipController.isGrabbed)
                Grab(mipController);
    }

    private void Grab(MipController prey)
    {
        _isEnemyGrabed = true;
        prey.Grab();
        prey.transform.SetParent(transform);
        prey.transform.localPosition = Vector3.zero;
    }
}
