using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
[RequireComponent(typeof(AudioSource))]
public class DynamicMusicSystem : MonoBehaviour
{
    public static DynamicMusicSystem instance;
    [SerializeField] protected List<DynamicSong> songs;
    protected AudioSource audioSource;
    protected float beatsPassed;
    protected float measuresPassed;
    protected int currentSongIndex;
    protected int phase = -1;
    [SerializeField] protected TextMeshProUGUI debugText;
    protected string debugString;
    protected int skipQueue = 0;
    protected Coroutine skipCoroutine = null;
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
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
            beatsPassed += Time.deltaTime * songs[currentSongIndex].bpm / 60;
            measuresPassed += Time.deltaTime * songs[currentSongIndex].bpm / 60 / songs[currentSongIndex].beatsPerMeasure;
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
        beatsPassed = 0;
        currentSongIndex = 0;
        audioSource.clip = songs[0].loop;
        StartCoroutine(beginSongCoroutine());
    }

    IEnumerator beginSongCoroutine()
    {
        phase = -1;
        audioSource.Play();
        debugString = "Current Operation: Beginning play operation";
        yield return new WaitUntil(() => audioSource.time > songs[currentSongIndex].beginLoopTime);
        phase = 0;
        debugString = "Last Operation: Completed play operation";
        yield return null;
    }

    void nextSong()
    {

    }

    void lastSong()
    {

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
        debugString = "Current Operation: Skipping " + skipQueue*4 + " beats (" + timeToSkip + " seconds)";
        yield return new WaitUntil(() => measuresPassed % 4 < 0.01);

        audioSource.time += timeToSkip;
        debugString = "Last Operation: Skipped " + skipQueue * 4 + " beats (" + timeToSkip + " seconds)";
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

