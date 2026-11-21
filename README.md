# WALKING SIMULATOR
_**Names:**_ Marc Amo & Víctor Cárdenas

_**Engine:**_ Unity 6 (6000.4.6f1)

## HOW TO OPEN IT
Open the repository folder with Unity 6000.4.6f1, open `Assets/Scenes/FinalScene.unity` and press Play.

## SCENE DESCRIPTION AND PROGRESSION (A -> B)
The scene is a 3rd person walking simulator. 

The main objective is to follow the main path and find the 12 hidden coins by exploration and guided by sound. To achieve this, we have configured the final object as an "Auditory Beacon" using a looping Audio Source with a fully 3D Spatial Blend (1.0) and a Linear Volume Rolloff curve, allowing the player to orient themselves spatially towards the objective.

## MIXER STRUCTURE AND ROUTING
We created a hierarchically structured Audio Mixer to maintain total control of frequencies and volumes, ensuring that no sound masks another.

### Master

  _**Music**_ (General 2D soundtrack)

  _**Ambience**_ (General wind and volumetric lake ambience)

  _**SFX**_ (Sound effects)

    SFX_Cars

    SFX_Breathing

    SFX_Footsteps

  _**UI**_ (Interface sounds)

## SNAPSHOTS AND DYNAMIC FILTERS
The project features 3 main Snapshots:

_**Gameplay:**_ Default state (filters open at 22000 Hz).

_**Pause Menu:**_ When pausing the game, the mixer changes to this snapshot ignoring the time scale and it applies a Simple Lowpass effect to the SFX and Ambience groups (cutting high frequencies around 1000Hz) without completely muting the game. Additionally, the menu has Sliders connected by code to adjust the volume of each group.

_**Underwater:**_ Triggered by a Box Collider located in the water area. A script detects the player's collision and transitions to this snapshot, which applies a more aggressive Lowpass (400Hz) to the Master group to simulate immersion.

## SOUND EFFECTS (SFX) AND SPATIALIZATION

_**Keyframe-based SFX:**_ The player's footsteps are triggered through Animation Events synchronized with the walking/running animation.

_**3D Spatial Ambiental SFX:**_ The parked cars use a Spatial Blend of 1.0 with no Doppler effect (since they are static), with a Linear Rolloff configured to attenuate the sound as the player moves away, enriching the environment.

_**Ambience & Music:**_ Played in 2D (Spatial Blend 0.0) so they act as a stereo sonic blanket that does not depend on the camera's position.

## PLAYER INPUT (LOOP MECHANIC)
To fulfill the requirement of looping volume and pitch modification based on user input, we implemented a running breathing/wind system. The audio is set to 'Loop'. When the player holds down the Shift key (Run), the Mathf.Lerp function smoothly increases the volume and raises the Pitch of the Audio Source to simulate effort and speed. 
Upon releasing the key, the values smoothly return to their resting state.

## The Gold Coin Challenge
There are 12 Gold Coins scattered throughout the map. Can you find them all?

### The Main Path: 
8 coins are placed along the main road you just need to follow the pavement and keep your ears open!

### The Hidden Four: 
The remaining 4 coins are off the beaten path and will require some extra exploration.

## Hints for the Hidden Coins:
If you’re struggling to find the final ones, keep these clues in mind:

**_The Lake:_** *Listen for the gentle lapping of waves.*

**_The Waterfall:_** *Follow the roar of the falling water.*

**_The Cliffside:_** *Near a small precipice, you’ll spot a red car parked below.*

**_The Overlook:_** *From the cliffside, look across the river toward the two houses and the barn nearby—the final coin is waiting there.*
