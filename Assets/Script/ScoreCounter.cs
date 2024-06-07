using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _ScoreText;

   [SerializeField] private TextMeshProUGUI _CurrentScore;
   
   [SerializeField] private TextMeshProUGUI _BestScore;
   
   private int _Score;
   private void Start()
   {
      _BestScore.text = DataSave.Instance.LoadData().ToString();
      int.TryParse(_ScoreText.text, out _Score);
   }

   public void PlayAgain()
   {
      _Score = 0;
      _ScoreText.text = _Score.ToString();
   }

   public void ScoreIncrese()
   {
      _Score++;
      _ScoreText.text = _Score.ToString();
   }

   public void SetScore()
   {
      _CurrentScore.text = _Score.ToString();
      int.TryParse(_BestScore.text, out int  _BestScores);
      if (_BestScores < _Score)
      {
         DataSave.Instance.SaveData(_Score);
         _BestScore.text = _Score.ToString();
      }
   }
}
