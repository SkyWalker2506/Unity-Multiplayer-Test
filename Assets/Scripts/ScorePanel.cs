using System;
using System.Collections.Generic;
using UnityEngine;

public  class ScorePanel : MonoBehaviour
{
    [SerializeField] private Transform _scorePanelObjectHolder;
    [SerializeField] private ScorePanelObject _scorePanelObjectPrefab;
    private List<string> _users = new List<string>();
    public void AddScorePanelObject(string userName)
    {
        if (_users.Contains(userName))
        {
            return;
        }
        
        ScorePanelObject scorePanelObject = Instantiate(_scorePanelObjectPrefab, _scorePanelObjectHolder);
        scorePanelObject.SetUserName(userName);
        scorePanelObject.SetScore(0);
        _users.Add(userName);
    }
}