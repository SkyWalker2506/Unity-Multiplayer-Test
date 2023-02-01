using UnityEngine;

public  class ScorePanel : MonoBehaviour
{
    [SerializeField] private Transform _scorePanelObjectHolder;
    [SerializeField] private ScorePanelObject _scorePanelObjectPrefab;

    public void AddScorePanelObject(string userName)
    {
        ScorePanelObject scorePanelObject = Instantiate(_scorePanelObjectPrefab, _scorePanelObjectHolder);
        scorePanelObject.SetUserName(userName);
        scorePanelObject.SetScore(0);
    }
}