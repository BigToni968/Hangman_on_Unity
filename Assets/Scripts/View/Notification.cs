using UnityEngine;

public enum NotificationType
{
    Win,
    Lose
}

public interface INotificationView
{
    public void Show(NotificationType notification);
}

public class Notification : MonoBehaviour, INotificationView
{
    [SerializeField] private Transform _win;
    [SerializeField] private Transform _lose;

    public void Show(NotificationType notification)
    {
        if (notification == NotificationType.Win)
            _win.gameObject.SetActive(true);
        else
            _lose.gameObject.SetActive(true);
    }
}