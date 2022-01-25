using UnityEngine;
using UnityEngine.Events;

public class Card : MonoBehaviour
{
    [SerializeField] private GameObject active;
    [SerializeField] private GameObject notActive;
    [SerializeField] private int id = 0;
    [SerializeField] private bool isActive = false;

    public bool IsActive { get => isActive; private set => isActive = value; }
    public int ID { get => id; private set => id = value; }

    public UnityEvent activateEvent;
    public UnityEvent deactivateEvent;
    private void Start()
    {
        Deactivate();
    }

    public void Activate()
    {
        activateEvent?.Invoke();
        active.SetActive(true);
        notActive.SetActive(false);
        isActive = true;
    }

    public void Deactivate()
    {
        deactivateEvent?.Invoke();
        active.SetActive(false);
        notActive.SetActive(true);
        isActive = false;
    }
}
