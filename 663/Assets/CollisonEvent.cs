using UnityEngine;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTriggerEnter;

    private void _onTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            _onTriggerEnter?.Invoke();
        }
    }
}
