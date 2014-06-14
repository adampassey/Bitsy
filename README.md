Unity2D Test-Bed
=================

Adam Passey's test bed for soon-to-be-released Unity2D components.

***Current Components***

**Events**

The Events system provides a way to fire and receive events between game objects without
requiring references between each other.

*Usage:* Import `AdamPassey.Event` and use the static `Events` class to send and receive events. Examples of two 
different game objects, listening to, and firing events:

Actor.cs
```C#
//  make sure you're using this package
using AdamPassey.Event;

public class Actor : MonoBehavior {

  //  when the player dies, fire an event
  public void Die() {
    Events.Fire("player-dies");
    //  ... do other things
  }
}

```

GameOverScreen.cs
```C#
using AdamPassey.Event;

public class GameOverScreen : MonoBehavior {
  
  //  start listening for the "player-dies" event
  public void Start() {
    Events.When("player-dies", DisplayGameOverScreen);
  }
  
  //  will get called when "player-dies" event is fired
  public void DisplayGameOverScreen() {
    //  ... do something
  }
}

```

---

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
package into Unity with `Assets` > `Import Package` > `Custom Package`. Select the [Package](https://github.com/adampassey/unity-2d-test-bed/blob/master/Package.unitypackage) 
and only import the component(s) you will be using. The *Usage scripts show implementation and are not needed.

***Contribution***

Contribute by forking, creating a feature branch, and opening a pull-request. 

***Contact***

Adam Passey

http://adampassey.com
