using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;


public class DynamicMusicSystem : MonoBehaviour
{
    public static DynamicMusicSystem instance;
    [SerializeField] protected List<DynamicSong> songs;
    protected float beatsPassed;
    protected float measuresPassed;
    protected int currentSongIndex;
    protected int phase = -1;
    [SerializeField] protected TextMeshProUGUI debugText;
    protected string debugString;
    protected int skipQueue = 0;
    protected Coroutine skipCoroutine = null;
    protected float initialTime;
    protected float offsetTime;

    [SerializeField] protected AudioSource audioSource, backupAudioSource;


    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple DMS detected. Destroying duplicate");
            Destroy(this);
        }
    }

    void Update()
    {
        if (audioSource.time >= songs[currentSongIndex].endLoopTime && phase == 0)
        {
            debugString = "Last Operation: Looped song";
            audioSource.time = songs[currentSongIndex].beginLoopTime;
        }
        if (phase >= 0)
        {
            float totalTime = Time.time - initialTime + offsetTime;
            beatsPassed = totalTime * songs[currentSongIndex].bpm / 60;
            measuresPassed = totalTime * songs[currentSongIndex].bpm / 60 / songs[currentSongIndex].beatsPerMeasure;
        }

        string debugTextStr = "Dynamic Music System \n";
        debugTextStr += debugString + "\n";
        debugTextStr += "Phase: " + phase + ", Song: " + songs[currentSongIndex].songName + "\n";
        debugTextStr += "Time: " + Mathf.Floor(audioSource.time * 100f) / 100f + "\n";
        
        debugTextStr += "Beats: " + Mathf.Floor(beatsPassed * 100f)/100f + ", Measures: " + Mathf.Floor(measuresPassed * 100f)/100f;
        debugText.text = debugTextStr;
        

    }
    public void beginPlay()
    {
        beatsPassed = -songs[currentSongIndex].beginLoopTime * songs[currentSongIndex].bpm / 60;
        measuresPassed = beatsPassed / songs[currentSongIndex].beatsPerMeasure;
        audioSource.clip = songs[0].loop;
        audioSource.volume = ProfileStats.masterVolume * ProfileStats.musicVolume / 100;
        initialTime = Time.time;
        offsetTime = -songs[currentSongIndex].beginLoopTime;
        StartCoroutine(beginSongCoroutine());
    }

    IEnumerator beginSongCoroutine()
    {
        phase = 0;
        audioSource.Play();
        debugString = "Current Operation: Beginning play operation";


        yield return new WaitUntil(() => audioSource.time > songs[currentSongIndex].beginLoopTime);
        debugString = "Last Operation: Completed play operation";
        yield return null;
    }

    public void nextSong()
    {
        StartCoroutine(nextSongCoroutine());
    }
    
    IEnumerator nextSongCoroutine()
    {
        phase = 1;
        debugString = "Current Operation: Fading out old song";
        yield return new WaitUntil(() => Math.Abs(measuresPassed) % 4 < 0.01);
        
        debugString = "Current operation: Waiting for audio to end";

        
        backupAudioSource.clip = songs[0].loop;
        backupAudioSource.volume = ProfileStats.masterVolume * ProfileStats.musicVolume / 10000f;
        audioSource.Stop();
        backupAudioSource.Play();
        backupAudioSource.time = songs[currentSongIndex].endLoopTime;

        
        float introMeasures = beatsPassed / songs[currentSongIndex].beatsPerMeasure;
        debugString = "Current operation: Waiting for beats to align \n Intro measures: " + introMeasures;

        yield return new WaitUntil(() => Math.Abs(measuresPassed + introMeasures) % 4 < 0.01);
        currentSongIndex++;
        beatsPassed = -songs[currentSongIndex].beginLoopTime * songs[currentSongIndex].bpm / 60;
        measuresPassed = beatsPassed / songs[currentSongIndex].beatsPerMeasure;
        audioSource.clip = songs[currentSongIndex].loop;

        phase = 0;
        audioSource.Play();
        debugString = "Current operation: Playing new song";


        yield return new WaitUntil(() => audioSource.time > songs[currentSongIndex].beginLoopTime);
        debugString = "Last operation: Played new song";
        yield return null;
    }

    public void skipSegment()
    {
        skipQueue++;
        if (skipCoroutine != null)
        {
            StopCoroutine(skipCoroutine);

        }
        skipCoroutine = StartCoroutine(skipSegmentCoroutine());
        
    }
    
    IEnumerator skipSegmentCoroutine()
    {
        DynamicSong song = songs[currentSongIndex];

        float timeToSkip = 60/song.bpm * song.beatsPerMeasure * 4 * skipQueue;
        debugString = "Current Operation: Skipping " + skipQueue*4 + " measures (" + timeToSkip + " seconds)";
        yield return new WaitUntil(() => Math.Abs(measuresPassed) % 4 < 0.01);

        audioSource.time += timeToSkip;
        debugString = "Last Operation: Skipped " + skipQueue * 4 + " measures (" + timeToSkip + " seconds)";
        skipQueue = 0;
        skipCoroutine = null;
        yield return null;

    }

    public void endPlay()
    {
        
        StartCoroutine(stopSongCoroutine());
    }
    
    IEnumerator stopSongCoroutine()
    {
        phase = 1;
        debugString = "Current Operation: Ending";
        yield return new WaitUntil(() => measuresPassed % 4 < 0.01);
        audioSource.time = songs[currentSongIndex].endLoopTime;
        debugString = "Last Operation: Ended";
        yield return null;
    }

}



[CreateAssetMenu(fileName = "DynamicSong", menuName = "Scriptable Objects/DynamicSong")]
public class DynamicSong : ScriptableObject
{
    public string songName;
    public AudioClip loop;
    public float beginLoopTime;
    public float endLoopTime;
    public int beatsPerMeasure;
    public float beatType;
    public float bpm;


}

