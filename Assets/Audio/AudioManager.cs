using UnityEngine.Audio;
using System;
using UnityEngine;

// This script acts as an audio manager for our game.
// It holds a list of music and SFX with various properties that can be adjusted per audio clip, such as volume, pitch, and the ability to loop.
// When the game starts, this script and the AudioManager gameObject will create an audiosource for each of the audio clips in the list with the relevant settings.
// These audiosources can then be called from other scripts and start or stop playing with a single line of code when needed.

public class AudioManager : MonoBehaviour
{

    public Sounds[] soundlist; // An array that will contain all of our audio files, music and SFX.

    public static AudioManager instance;

    public bool TimeRunningOut = false;

    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sounds s in soundlist) // For each sound in our array, the AudioManager will create an audio source at the start of our game.
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop; // All of these are just populating our audiosource component with the correct data, such as the volume or pitch we had input for our audio file.
        }
    }

    void Start()
    {
        Play("MainMenuTheme"); // At the start the MainMenuTheme will play.
    }

    public void Play (string name) // This function plays the specified audiosource when called upon by another script.
    {
        Sounds s = Array.Find(soundlist, Sounds => Sounds.name == name); // Loops through the soundlist array until it finds the sepcified audiosource.
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!"); // Logs to the console if the specified audiosource is not found due to a typo.
            return;
        }

        s.source.Play(); // Plays the specified audiosource.
    }

    public void StopPlaying (string name) // This function is the same as above except it will stop playing the specified audiosource.
    {
        Sounds s = Array.Find(soundlist, Sounds => Sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

}
