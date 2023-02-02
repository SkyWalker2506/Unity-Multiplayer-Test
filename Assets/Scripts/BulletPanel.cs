using TMPro;
using UnityEngine;

public class BulletPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _bulletText;

    private void OnEnable()
    {
        GameEventsManager.OnBulletChanged += UpdateBulletText;
    }

    private void OnDisable()
    {
        GameEventsManager.OnBulletChanged -= UpdateBulletText;
    }

    private void UpdateBulletText()
    {
        _bulletText.SetText($"Bullet: Color {GameInfo.Player.CurrentBullet.Color}, Size {GameInfo.Player.CurrentBullet.Size}");
    }
}