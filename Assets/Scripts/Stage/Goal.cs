using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private Score _score;

    private void Start()
    {
        _scorePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == Singleton.Player)
        {
            ReachGoal();
        }
    }

    public void ReachGoal()
    {
        _scorePanel.SetActive(true);
        Singleton.Player.SetActive(false);
        _score.ShowScore();
    }
}
