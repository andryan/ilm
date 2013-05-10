=== EZSprite ===

Kelly Wright
http://wrightkelly.blogspot.com/
kellywright413@gmail.com (bugs, comments, questions, etc.)


== Description ==

EZSprite provides a simple solution for 2D sprite animation managment. Use the provided Atlas Maker to easily create 
an atlas then open up the EZSprite Animator and start animating in seconds. Works with Character Controllers, Rigidbodies, 
GUI elements and more. Comes with a low-poly plane for even more optimization. Compatible with C# and Java.


== How To Use ==

- Create An Atlas
- Add EZSprite Animator
- Using EZSprite Animator
- Playing Animations

-- Create An Atlas --
Creating an atlas is as simple as selecting the textures you wish to combine (or their folder), opening the 
EZSprite Atlas Maker in the Window tab, clicking Add Selected, then New Atlas. The Atlas Maker will allow you to save a 
corresponding Material which is setup to function in a 2D environment. Once the Atlas Maker is done, the Material can be 
used in the EZSprite Animator.

-- Add EZSprite Animator --
In the GameObject tab, select EZSprite Animator. This will add all the neccesary components for the script to function. 
If you don’t have an object selected, it will add a 2-tri plane which has been provided to replace the default Unity plane. 

-- Using EZSprite Animator --
Once the Animator has been added, select Add Animation and select your atlas Material. 

The first thing you will want to set is the grid, this will split your Texture up into frames. The dimensions of the grid 
should match the dimensions of your atlas (though some weird effects can be gained otherwise.)

From this point you can double-click in the grid to add frames to your current animation. Single-clicking will change the 
current frame, which can be used to set the default frame of a sprite. Frames in the current animation will show up in the 
right table. From here they can be previewed, rearranged, and deleted.

Change the frame rate and wrap mode of individual animations at the top of the table. You can test your animation in the editor
using the Animators built-in player. 

To add or remove an animation, click the + and - respectively.

The inspector will display basic information about each animation, as well as allow you to change the default wrap mode. 
You can also set whether an animation will start on play or not.

-- Playing Animations --
The Sprite Animator works in much the same way as the built-in Animation component. Simply get a Sprite Animator reference, 
then use the Play function, which has three methods of use.

Example:

SpriteAnimator spriteAnimator = transform.GetComponent<SpriteAnimator>();

method 1:

spriteAnimator.Play(); //This will play the first animation.

method 2:

spriteAnimator.Play(1); //Enter the index number of the animation (this example will play the second animation.)

method 3:

spriteAnimator.Play("“run"”); //Enter the exact name of the animation you want to play.

method 4: (Java)

transform.SendMessage("JPlay", "run"); //SendMessage directly to the transform, without referencing the SpriteAnimator.


At anytime you can use the Stop function to stop the current animation on whatever frame it is on.

Example: spriteAnimator.Stop();

For Java users, SendMessage() will work for Stop, as well an any of the functions below.

== Miscellaneous Functions ==

public void Pause(): Pauses the animation without reverting to the first frame.

public string Playing(): Returns the name of the current animation.

public int GetAnimationIndex(string requestedAnimationName): Takes in an animation name and returns it's index number.

public string GetAnimationName(int requestedAnimationIndex): Takes in an index number and returns the animation's name.

public bool isPlaying: Returns true if an animation is currently playing.

== Versioning ==

Update v1.1
- Adjusted asset store images.
- Removed a line from SpriteAnimator_Inspector that would sometimes give an unnecessary warning.
- Fixed the rotation of the atlasPlane that was set on import.

Update v1.2
- Changed the atlas algorithm, now it will draw the textures in order.
- When creating an atlas, textures must now be the same size. This will make atlases more compatable with the animator.
- Added buttons to allow rearranging of textures in the atlas maker.
- Added more tooltips, mostly to do with the new atlas algorithm.

Update v1.3
- Added Java support via SendMessage("JPlay", "animation name");
- Fixed general errors from the 3.5 update.
- Added several useful functions to SpriteAnimator.
- Added a 'Miscellaneous Functions' and 'Special Thanks' section to the readme.
- The demo project has been removed from this patch due to issues with 3.5, expect a new project in the future.

Update v1.4
- Added an "isPlaying" accessor.

== Special Thanks ==
Christopher 'Jack' Nilssen
Dark Acre Games
dark-acre.com

Juan Manuel Palacius
virtualimaginarium@gmail.com
@jmp_imaginarium

Darryl Spratt

Chris Banks

== In Closing ==

Thank you for purchasing EZSprite and happy animating.
Feel free to contact me if you have any questions, concerns, or compliments. ;)