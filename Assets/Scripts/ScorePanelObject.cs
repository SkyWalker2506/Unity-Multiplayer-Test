using TMPro;
using UnityEngine;

public class ScorePanelObject : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _scoreText;

    public void SetUserName(string userName)
    {
        _nameText.SetText(userName);
    }

    public void SetScore(int score)
    {
        _scoreText.SetText(score.ToString());
    }
    
}