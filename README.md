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

**Game Object Pool**

The Game Object Pool instantiates game objects and makes it easy to retrieve them without using expensive `Instantiate` calls.

*Usage:* Create an instance of the `GameObjectPool`, and retrieve items from it using `Get()`.

Gun.cs
```C#
using AdamPassey.Pool;

public class Gun : MonoBehavior {
  
  public GameObject bulletPrefab;
  public int maxBulletCount;
  
  private GameObjectPool<Bullet> gameObjectPool;
  
  void Start() {
	//	Instantiate the Game Object Pool and use a Coroutine to 
	//	instantiate all the items in the pool
    gameObjectPool = new GameObjectPool<Bullet>(bulletPrefab, maxBulletCount);
	StartCoroutine(gameObjectPool.CreatePool());
	
  }
  
  public void Shoot() {
    Bullet bullet = gameObjectPool.Get();
    if (bullet != null) {
      //  ... do something with bullet
    }
  }
}
```

Bullet.cs
```C#
public class Bullet : MonoBehavior {
  
  public void OnCollisionEnter2D(Collision2D collision) {
    
    //  do not use Destroy(), instead just deactivate the 
    //  object. This lets it remain in the pool.
    gameObject.SetActive(false);
  }
}
```

---

**Circular Parallax (no scripting required)**

Although not a traditional Parallax, the Circular Parallax script creates a "night star" effect, where the image rotates around the camera, at a given offset. This script uses a Sprite Renderer to act as the background.

*Usage:* Create an empty game object and attach a `Sprite Renderer` component. This object will act as the rotating background. Create a new empty game object and attach the `Circular Parallax` script to it. Drag the previously created game object with a `Sprite Renderer` component into the `Sprite Renderer Object` field.

Adjust the rotation speed as well as the offset (to the main camera) on the `Circular Parallax` component as needed.

---

**Parallax (no scripting required)**

The Parallax script allows you to easily add Parallax backgrounds to your scene that will move at the desired speed(s).
This script achieves this effect by manipulating the offset and position of a repeated texture. In the example provided, the Parallax script is using a Quad which contains a material with a wrapped texture.

*Usage:* Import an image asset and set the `Texture Type` to `Texture`. Also set the `Wrap Mode` to `Repeat`. Create a 
new material by selecting `Assets` -> `Create` -> `Material`. Select the appropriate texture and the desired tiling.

The Parallax script adjusts the texture offset on the `x` axis, and the position of the rendered texture on the `y` axis,
while keeping the Parallax object in sync with the main camera. Depending on the desired effect, you should only need
to set the tiling on the `x` axis. 

In your scene create an empty game object and attach thet `Parallax` script. Create an object that renders a material
(in the example provided a Quad was used). Attach your material to this object and adjust the size and tiling to 
correctly fit the main camera bounds. Drag this object into the `Texture Object` field in the `Parallax` component.

Adjust the `speed` on the Parallax object to achieve the desired effect. The `speed` attribute is expected to be between
`0.1 - 0.9` with `0.1` representing objects far in the distance and `0.9` representing closer objects.

---

**GameState**

The simple GameState script makes it easy to set and retrieve state.

```C#
//	set the state to paused
GameState.SetState(GameState.States.Paused);

//	set the state to running
GameState.SetState(GameState.States.Running);

//	use convenience methods in Update()
void Update() {
	if (!GameState.IsRunning()) {
		return;
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
