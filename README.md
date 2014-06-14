Unity2D Test-Bed
=================

Adam Passey's test bed for Unity2D components.

***Importing***

Clone this repository locally with `git clone git@github.com:adampassey/unity-2d-test-bed.git` and use import the
package into Unity with `Assets` > `Import Package` > `Custom Package`. Select the [Package](https://github.com/adampassey/unity-2d-test-bed/blob/master/Package.unitypackage) 
and only import the component(s) you will be using. The *Usage scripts show implementation and are not needed.

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
  
  //  when the player wins, fire an event
  //  passing this (as the sender) to the
  //  receiving object
  public void Win() {
    Events.Fire("player-wins", this);
  }
}

```

GameOverScreen.cs
```C#
using AdamPassey.Event;

public class GameOverScreen : MonoBehavior {
  
  //  start listening for the "player-dies" and "player-wins" events
  public void Start() {
    Events.When("player-dies", DisplayGameOverScreen);
    Events.When("player-wins", DisplayStatsScreen);
  }
  
  //  will get called when "player-dies" event is fired
  //  requires EventContext as argument
  public void DisplayGameOverScreen(EventContext e) {
    //  ... do something
  }
  
  //  will get called when "player-wins" event is fired
  //  inspects sender- watch out, sender can be null
  public void DisplayStatsScreen(EventContext e) {
    if (e.sender != null) {
      Debug.Log(e.sender); // will print "Object (Component)"
      //  ... do something to/with sender
    }
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

***Contribution***

Contribute by forking, creating a feature branch, and opening a pull-request. 

***Contact***

Adam Passey

http://adampassey.com
