using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   #region GetInstance
   public static GameManager Instance;


   private void Awake()
   {
      Instance = this;
   }
   #endregion

   [SerializeField] private Bird _bird;
   [SerializeField] private GameObject _GameOverPanal;

   public void RestartGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   public void GameStart()
   {
      _bird.GameStart();
      PipeSpawner.Instance.SpawnePipe();
      PipeSpawner.Instance.StartSpawne();
   }

   public void GameOver()
   {
      _GameOverPanal.SetActive(true);
      PipeSpawner.Instance.StopSpawne();
   }
   
}
