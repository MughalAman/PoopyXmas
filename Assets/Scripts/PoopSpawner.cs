using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PoopSpawner : MonoBehaviour
{

  //Variables

  [SerializeField] private GameObject poopSpawnPoint;
  [SerializeField] private GameObject Santa;
  [SerializeField] private GameObject poopGO;

  public float poopRate = 1f;
  public int score;
  public int lives = 3;

  public TextMeshProUGUI ScoreText;
  public TextMeshProUGUI livesText;
  public TextMeshProUGUI startText;

  public bool GameOver = true;
  public bool IsPlaying = false;

    void Start(){
      FindObjectOfType<AudioManager>().Play("BG_Music");
    }

    void Update(){
      //update the score | make a system for this
          ScoreText.text = "SCORE: " + score.ToString();
          livesText.text = "LIVES: " + lives.ToString();
          if(Input.GetKey(KeyCode.Space))
          {
            GameOver = false;
          }

          if(GameOver == false)
          {
              if(IsPlaying == false)
              {
                  poopSpawnPoint = GameObject.Find("PoopSpawnPoint");
                  if(poopSpawnPoint != null)
                    StartCoroutine(Poop());
                    ScoreText.gameObject.SetActive(true);
                    livesText.gameObject.SetActive(true);
                    startText.gameObject.SetActive(false);

              }
          }

    }

    public void TakeDamage(){
      lives--;
      if(lives <= 0){
        StopAllCoroutines();
        SceneManager.LoadScene(0);
      }
    }

    public IEnumerator Poop()
     {
         IsPlaying = true;
         while (GameOver == false)
         {
             //spawn poop.
             Instantiate(poopGO, poopSpawnPoint.transform.position, Quaternion.identity);
             yield return new WaitForSeconds(poopRate);
         }
     }

}
