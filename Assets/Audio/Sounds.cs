using UnityEngine.Audio;
using UnityEngine;

// This script is a custom class that allows us to control what data is stored for each piece of audio in our game.
// For example, we want the ability to control the volume of individual tracks so we can keep the background music slightly quieter than our SFX.
// Additionally we want music tracks like our MainMenuTheme to be able to loop but we don't necessarily need our SFX to loop.

[System.Serializable]
public class Sounds 
{

    public string name; // What we want to name the audio clip.

    public AudioClip clip; // Reference to the individual audio file.

    [Range(0f, 1f)]
    public float volume; // This allows us to adjust the volume of the audio file
    [Range(.1f, 3f)]
    public float pitch = 1f; // // This allows us to adjust the pitch of the audio file

    public bool loop; // This allows us to toggle whether a particular audio file should loop or not.

    [HideInInspector]
    public AudioSource source; // A hidden public variable we can use to call when we want to play a specific audiosource.

}
