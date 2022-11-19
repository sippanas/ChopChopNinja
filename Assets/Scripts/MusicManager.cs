using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private TextMeshProUGUI SongText;

    [SerializeField]
    private List<AudioClip> songs;

    void Start()
    {
        PlayNextSong();
    }

    public void PlayNextSong()
    {
        AudioClip currentSong = null;
        foreach(AudioClip song in songs)
        {
            if(song == source.clip)
            {
                currentSong = song;
            }
        }

        var nextSong = songs[(songs.IndexOf(currentSong) + 1) % songs.Count];

        source.clip = nextSong;
        SongText.text = $"{source.clip.name}";
        source.Play();
    }
}
