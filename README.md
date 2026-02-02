# HW4
## Devlog
### Model View Control Pattern
I believe that in this project, the GameController class represents the control side of the pattern, and the Bird/Player class represents the view side of the pattern. This is because the GameController class is where the ScoreChanged delegate, OnScoreChanged event, Audiotrigger delegate, and AudioTrigger events are assigned, meanwhile the player class accesses these by calling an instance of these events, and passing the necessary argument through. For example, the delegate AudioTrigger has a paramater AudioSource "audioSource." The Player class calls either TriggerDeathExplosionSound or TriggerPointSound, and passes through the argument _deathExplosionSound or _pointSound, which is assigned in a serialized field. In the game controller, both methods subscribe to the OnAudioTrigger event.

### Singleton and Events System
In my code I created a singleton in the GameController, which allows it to be publically accessed as a singular instance. In doing so, I am able to call and instance of the GameController in the player class, which allows my event system to function properly. An example of this is when I called GameOverTrigger. On this line, I am detecting whether the player collided with a hazard, through the method OnCollisionEnter2D. From here I am able to access the singleton from an entirely seperate player class, using the method GameOverTrigger to activate an event in the GameController class that ends the game by destroying the player bird, and communicating to the rest of the class that the game has ended through a boolean called gameOver.

## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites
- [Old School Shonen SFX](https://heltonyan.itch.io/retroanimesfx) - sound effects
