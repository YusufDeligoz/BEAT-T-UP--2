using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public Sağ_BeatScroller sagBS;

    public Sol_BeatScroller solBS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;
    public int scorePerMissedNote = 50;

    public Text scoreText;

    private sHAKE shake;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<sHAKE>();

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                sagBS.hasStarted = true;
                solBS.hasStarted = true;

                theMusic.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");
       // currentScore += scorePerNote;
          scoreText.text = "Score:" + currentScore;

        if (shake != null)
        {
            shake.CamShake(); // sHAKE scriptindeki uygun fonksiyonu çağırın
        }
    }
    public void NormalHit()
    {
        currentScore += scorePerNote;
        NoteHit();
        normalHits++;
    }
    public void GoodHit()
    {
        currentScore += scorePerGoodNote;
        NoteHit();
        goodHits++;
    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote;
        NoteHit();
        perfectHits++;
    }
    public void NoteMissed()
    {
        currentScore -= scorePerMissedNote;
        Debug.Log("Note Missed");
        missedHits++;
    }
}
