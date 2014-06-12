Unity2D Test-Bed
=================

Adam Passey's test bed for soon-to-be-released Unity2D components.

***Current Components***

**AudioSources**

Provides a way to attach multiple `AudioClip`'s to a single GameObject without having to attach
multiple `AudioSource` components.

*Usage:* Attach the `AudioSource`'s components to your GameObject and drag `AudioClip`'s into 
the 'Audio Clips' array in the inspector. Reference these clips in your code with:

```C#
using AdamPassey.Audio;

private AudioSources audioSources;

//  example using enumerated type
enum Sounds {
  Smack,
  Hit,
  Jump
}

//  retrieve the AudioSources component on Start()
public void Start() {
  audioSources = gameObject.GetComponent<AudioSources>();
}

//  play sounds
public void Update() {
  
  if (Input.GetKeyDown(KeyCode.A)) {
    audioSources.PlayOnce((int)Sounds.Smack);
  }
  
  if (Input.GetKeyDown(KeyCode.B)) {
    audioSources.PlayOnce((int)Sounds.Hit);
  }
  
  if (Input.GetKeyDown(KeyCode.C)) {
    audioSources.Play((int)Sounds.Smack);
  }
  
  if (Input.GetKeyDown(KeyCode.D)) {
    audioSources.Stop((int)Sounds.Smack);
  }
  
  if (Input.GetKeyDown(KeyCode.E)) {
    audioSources.PlayScheduled((int)Sounds.Jump, 4);
  }
}

```

***Importing***

Clone this repository locally with `git clone git@github.com:adampassey/unity-2d-test-bed.git` and use import the
package into Unity with `Assets` > `Import Package` > `Custom Package`. Select only the component(s) you
will be using. The *Usage scripts show implementation and are not needed.

***Contribution***

Contribute by forking, creating a feature branch, and opening a pull-request. 

***Contact***

Adam Passey

http://adampassey.com
