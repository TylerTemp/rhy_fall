using System;
using UnityEngine;
using UnityEngine.Events;

public class MusicManager : MonoBehaviour
{
    #region 配置参数
    [SerializeField] private MusicPiece _musicPiece;
    [SerializeField] private AudioSource _audioSource;
    #endregion

    #region 对外接口
    [field: SerializeField] public UnityEvent<int> MusicPlaySample { get; private set; } = new UnityEvent<int>();
    public int SampleRate { get; private set; }
    public MusicPiece.RhythmSample[] RhythmSamples => _musicPiece.rhythmSamples;
    #endregion

    #region 类的属性
    private double _startTime;
    private double _sampleRate;
    private int _totalSamples;
    #endregion

    private void Awake()
    {
        _audioSource.clip = _musicPiece.audioClip;
        _sampleRate = AudioSettings.outputSampleRate;
        SampleRate = Mathf.RoundToInt((float)_sampleRate);
        float totalSeconds = _musicPiece.audioClip.length;
        _totalSamples = Mathf.CeilToInt((float)(totalSeconds * _sampleRate));
    }

    private void Start()
    {
        _startTime = AudioSettings.dspTime + 0.15f;  // 0.15s用来给 Unity 载入音乐文件到内存
        // Debug.Log(_startTime);
        _audioSource.PlayScheduled(_startTime);
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        double sampleD = (AudioSettings.dspTime - _startTime) * _sampleRate;
        if (sampleD < 0)
        {
            return;
        }

        int sample = Mathf.RoundToInt((float)(sampleD % _totalSamples));
        MusicPlaySample.Invoke(sample);
        Debug.Log(sample / _sampleRate);
    }
}
