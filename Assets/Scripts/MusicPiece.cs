using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicPiece", menuName = "ScriptableObjects/Music Piece", order = 0)]
public class MusicPiece: ScriptableObject
{
    public AudioClip audioClip;
    // public int sampleRate;

    [Serializable]
    public struct RhythmSample
    {
        public int sample;
        public bool isMain;
    }

    public RhythmSample[] rhythmSamples;
}
