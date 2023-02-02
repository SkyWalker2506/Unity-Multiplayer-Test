using TMPro;
using UnityEngine;

public class TargetPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _targetText;

    private void OnEnable()
    {
        TargetManager.OnTargetChanged += UpdateTargetText;
    }

    private void OnDisable()
    {
        TargetManager.OnTargetChanged -= UpdateTargetText;
    }

    private void UpdateTargetText()
    {
        _targetText.SetText($"Target: Color {GameInfo.CurrentBullet.Color}, Size {GameInfo.CurrentBullet.Size}");
    }
}