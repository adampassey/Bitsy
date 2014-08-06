Bitsy
=================

A collection of itsy-bitsy [Unity](http://unity3d.com/) components written by [Adam Passey](http://adampassey.com). Take a look at some of these components in action by visiting the [example page](http://adampassey.github.io/bitsy/Example/).

***Importing***

Clone this repository locally with `git clone git@github.com:adampassey/bitsy.git` and import the
package into Unity with `Assets` > `Import Package` > `Custom Package`. Select the [Package](https://github.com/adampassey/bitsy/blob/master/Package.unitypackage) 
and only import the component(s) you will be using. The *Usage scripts show implementation and are not needed.

***Current Components***

**Inventory (Grid-Based)**

The `Inventory` component is a drag-and-drop grid-based inventory. Attach an inventory to any `GameObject` by attaching
the `Inventory` component. Set the `GUI Size`, `inventory size`, `item offset` (padding around inventory GUI), and `Tilesize` (the
size of each tile).

Once the inventory is attached, it can be opened and closed easily:

```C#
using AdamPassey.Inventory;

public class SomeGameObject {
	
	private Inventory inventory;
	
	//	retrieve the inventory
	public void Awake() {
		inventory = gameObject.GetComponent<Inventory>();
	}
	
	//	open and close the inventory
	public void Update() {
		if (Input.GetKeyDown(KeyCode.I)) {
			if (inventory.IsVisible()) {
				inventory.Hide();
			} else {
				inventory.Show();
			}
		}
	}
	
	//	add a GameObject to the inventory
	public void AddGameObjectToInventory(GameObject obj) {
		inventory.AddObject(obj);
	}
	
	//	add an object at location 1, 1
	public void AddGameObjectToSpeficicSpotInInventory(GameObject obj) {
		inventory.AddObject(new InventoryPosition(1, 1), obj);
	}
}
```

All items that can be rendered in the `Inventory` should have an `InventoryItem` component
attached. This component defines the image that will be rendered, the name (for tooltips), and
description.

By default the `Inventory` allows for left-click drag-and-drop functionality. Right-clicking
an item in the inventory will drop it. Items can also be clicked by dropping them anywhere outside
of the inventory window. Transferring items between different inventory windows is also supported.

---

**Persistence**

The persistence package helps with the saving and loading of data through `Data Container`'s. Data that goes into these containers must be serializable, so serializable alternatives to `Vector3` and `GameObject` have been created for use. Also included in this package is an initial `GameObjectDataContainer` for saving the position of `GameObject`'s in a scene.

Using the built-in `GameObjectDataContainer` to save `GameObject`'s is straightforward:
```C#
// assuming you have a list of GameObject's
List<GameObject> list;

//  create the data container
GameObjectDataContainer dataContainer = new GameObjectDataContainer();

//  iterate through your list, create SerializableGameObject's, 
//  and add them to the DataContainer
for (GameObject go in list) {
	SerializableGameObject serializable = new SerializableGameObject(go);
	dataContainer.Add(serializable);
}

//  save this container with this filename
Persister.Save<GameObjectDataContainer>("game-objects", dataContainer);
```

You can also use this package to load data:
```C#
//  load the data container through the persister
GameObjectDataContainer dataContainer = Persister.Load<GameObjectDataContainer>("game-objects", new GameObjectDataContainer());

//  if it's not null, we've got data!
if (dataContainer != null) {
	//  create GameObject's from the SerializedGameObjects
	for (SerializableGameObject s in dataContainer.GetData()) {
		GameObject go = (GameObject) GameObject.Instantiate(somePrefab, s.position.ToVector3(), Quaternion.identity);
	}
}
```

You can also create custom data containers to use:
```C#
//  define the Data Container, annotate as Serializable
[System.Serializable]
public class NameDataContainer : DataContainer {
	public string name;
}

// use this container to save data
NameDataContainer dataContainer = new NameDataContainer();
dataContainer.name = "Adam";
Persister.Save<NameDataContainer>("name", dataContainer);
```

---


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

**Animation Sync**

The Animation Sync component isn't meant to replace the Unity Pro feature of animation layer syncing, but it is meant
to alleviate re-creating the state machines and transitions between animations. When this component is attached to
a Game Object, it will watch for animation state changes. If a new clip is played on the parent object, it will 
propagate this clip to all children objects.

If the children of the parent object change, all children animators will need to be reloaded. Do this by running:

```C#
public void Start() {
	//	keep this cached
	AnimationSync animationSync = gameObject.GetComponent<AnimationSync>();
}

public void SomeChildObjectAdded() {
	//	update the child animators
	animationSync.ReloadChildAnimators();
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

**Timer**

Using the timer allows you to determine if a specific amount of time has passed. Usage:

```C#
using AdamPassey.Timer;

private Timer timer;

public void Start() {
	timer = new Timer();
}

public void Update() {
	if (timer.TimeHasPassed(10)) {
		Debug.Log("10 seconds has passed.");
	}
}
```

---

**Circular Parallax (no scripting required)**

Although not a traditional Parallax, the Circular Parallax script creates a "night star" effect, where the image rotates around the camera, at a given offset. This script uses a Sprite Renderer to act as the background.

*Usage:* Create a game object that will act as the background. This object can use any type of renderer: `SpriteRenderer`, 
`MeshRenderer`, etc. This object will act as the rotating background. Create a new empty game object and attach the 
`Circular Parallax` script to it. Drag the previously created game object with a `Renderer` component into the `Material Object` field.

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
correctly fit the main camera bounds. Drag this object into the `Material Object` field in the `Parallax` component.

Adjust the `speed` on the Parallax object to achieve the desired effect. The `speed` attribute is expected to be between
`0.1 - 0.9` with `0.1` representing objects far in the distance and `0.9` representing closer objects.

---

**Moving Parallax (no scripting required)**

The moving Parallax is meant to help achieve the effect of a moving background (even when the camera is still). This 
effect works great with clouds, or sky-like materials. Use this component in the same way as the other Parallax scripts:
Merely attach a `Moving Parallax` component to an object, and drag and drop an object with a material into the
`Material Object` field. Adjust the speed to your liking.

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
