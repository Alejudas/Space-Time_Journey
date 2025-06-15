using UnityEngine;
using UnityEngine.Events;

public class Puzzle1 : MonoBehaviour
{
    [SerializeField] Valvulas valvulueUnlock;
    [SerializeField] UnityEvent OnUnlock;
    private void Update()
    {
        if (valvulueUnlock.OnActive == true)
        {
            OnUnlock.Invoke();
        }
    }
}
