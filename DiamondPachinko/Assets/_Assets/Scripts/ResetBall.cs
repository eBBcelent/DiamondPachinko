using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ResetBall : MonoBehaviour
{
    public UnityEvent callback;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.SetActive(false);
        callback?.Invoke();
    }
}
