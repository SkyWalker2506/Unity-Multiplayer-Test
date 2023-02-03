using TMPro;
using UnityEngine;

public class BulletPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _bulletText;

    private void OnEnable()
    {
        GameEventsManager.OnGameStarted += SetBulletUpdate;
    }

    void SetBulletUpdate()
    {
        PlayerBehaviour.Instance.OnBulletDataChanged += UpdateBulletText;
        UpdateBulletText(PlayerBehaviour.Instance.BulletData);
    }

    private void OnDisable()
    {
        PlayerBehaviour.Instance.OnBulletDataChanged -= UpdateBulletText;
        GameEventsManager.OnGameStarted -= SetBulletUpdate;
    }

    private void UpdateBulletText(BulletData bulletData)
    {
        _bulletText.SetText($"Bullet: Color {bulletData.Color}, Size {bulletData.Size}");
    }
}