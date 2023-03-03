# **Quetzal**

## _Game Design Document_

---

##### **Copyright notice / author information / boring legal stuff nobody likes**

## Colaborators: Team "LEGENDS"

#### Gabriel Rodríguez De Los Reyes

#### Iker García Germán

#### Rodrigo Núñez Magallanes

#### Enrique Cabrera Aguilar

#### Alejandro Arouesty Galván

#### Pablo Banzo Prida

## Instructors:

#### Esteban Castillo Juarez

#### Gilberto Echeverría Furió

#### Octavio Navarro Hinojosa

## _Index_

---

1. [Index](#index)
2. [Game Design](#game-design)

   1. [Summary](#summary)
   2. [Idea Pitch](#idea-pitch)
   3. [Game Genre](#game-genre)
   4. [Gameplay](#gameplay)
   5. [Mindset](#mindset)
   6. [RPG Elements](#rpg-elements)
   7. [Game Mechanics and Rules](#game-mechanics-and-rules)
   8. [Stats](#stats)

3. [Technical](#technical)
   1. [Screens](#screens)
   2. [Controls](#controls)
   3. [Mechanics](#mechanics)
4. [Level Design](#level-design)
   1. [Themes](#themes)
      1. Ambience
      2. Objects
         1. Ambient
         2. Interactive
      3. Challenges
   2. [Game Flow](#game-flow)
5. [Development](#development)
   1. [Abstract Classes](#abstract-classes--components)
   2. [Derived Classes](#derived-classes--component-compositions)
6. [Graphics](#graphics)
   1. [Illustrations](#illustrations)
   2. [Visual References](#visual-references)
   3. [Style Attributes](#style-attributes)
   4. [Graphics Needed](#graphics-needed)
7. [Sounds/Music](#soundsmusic)
   1. [Style Attributes](#style-attributes-1)
   2. [Sounds Needed](#sounds-needed)
   3. [Music Needed](#music-needed)
8. [Schedule](#schedule)

## _Game Design_

---

### **Summary**

A Mayan general's son must use his wits, strength, and the power of the gods to defeat the Spanish invaders and protect his people.

Navigate treacherous dungeons to find the Mayan god who will grant you the power to defeat the invaders and prove yourself worthy of their power.

### **Idea Pitch** !

In this game, you play as the son of one of the most important Mayan generals of the time. Trained to be a skilled warrior, you now face the threat of Spanish conquistadors who want to take everything from you: your resources, your friends, your family, and even your religion. Despite the fact that the Spanish have superior weaponry, he seeks the help of the gods to gain an advantage in battle. When your brother is murdered by a Spanish conquistador, you must channel your anger and frustration into defeating the invaders and protecting your people.

You must travel through treacherous dungeons to find the Mayan god who will grant you the power to defeat the invaders. These dungeons are full of traps, puzzles, and enemies that will test your skills as a warrior. You will need to use your wits and strength to overcome these challenges and prove yourself worthy of the god's power.

Along the way, you will face setbacks and obstacles, but you must persevere and continue to overcome yourself in order to avenge your brother's death. You will meet other characters that can either help you or hinder your progress, and you must choose your allies wisely.

As you progress through the game, you'll unlock new abilities and upgrades that will make you stronger and better equipped to take on the Spanish conquistadors. With each victory, you will get closer to your ultimate goal of defeating the enemy and saving your people.

Can you harness the power of the gods and become the hero of this story?

### **Game Genre** !

Genre: Fantasy RPG Rouge-like Game
This game combines the elements of a fantasy role-playing game with the challenge of a rogue-like game, allowing players to explore a variety of dungeons and battle against dangerous enemies.

The player will have the chance to choose powerful weapons and gear, use clever tactics to defeat enemies, and discover the amazing world.

This game combines the elements of a fantasy role-playing game with the challenge of a rogue-like game, allowing players to explore a variety of dungeons and battle against dangerous enemies. The player will have the chance to choose powerful weapons and gear, use clever tactics to defeat enemies, and discover the amazing world

### **Gameplay**

In order to develop a fluent game we decided to construct a scenario in which our main character needs to explore new places in order to fulfill its mission. To do so, we would create a spawning world, pero PvP is not active in which you can explore and get to know the story in more depth. In this first area, the camera would be placed in a top-down perspective that allows the character to explore in any direction. Once in this world, the player is going to be able to find a dungeon where the real PvP starts. Inside the dungeon the perspective would be side-on to help the payer understand he entered a completely different space. This dungeon would force you to keep exploring through it by not allowing you to exit unless you die.

This system works in such a way that the more time and enemies you kill inside the dungeon, the more levels and equipment you gain. This dungeon would be randomly generated to motivate players to play it again, and see what has changed. The more time you spend on the dungeon, the harder it will get, keeping the game interesting. Inside the dungeon there will be items that boost certain stats in a specific way, like a sword that increases the damage a character makes. Once this dungeon is played several times the player will be rewarded with a special ability.

At this moment, when you leave the dungeon the game will tell you that you are ready to go and fight the final boss. This boss will be a very strong enemy that will require a lot of skill to defeat. Once you defeat the boss, you will be able to go back to the main world and explore it; as well as going back to the dungeon to try to find new and better items. If you die against the boss, you will lose your power and need to go back to the dungeons to get it back. This way the player will think twice before ending the final battle, and encourage him to keep exploring the world.

### **Mindset**

What kind of mindset do you want to provoke in the player? Do you want them to feel powerful, or weak? Adventurous, or nervous? Hurried, or calm? How do you intend to provoke those emotions?

### **RPG Elements** !

The RPG elements that will be used in this game are the following:

**Story**: Just as said in the elevator pitch. You are the son of a powerfull mayan general. Spanish conquest is just begging, and you aid for the gods of your religion to destroy your enemies.

**Setting**: Mexico, Mayan Riviera in the 1500s.

**Exploration**: You start by the village of where you were born, and move through the place to find resources. Most importantly you found the entrance for a dungeon where you suppose the mayan gods are waiting for the chosen one.

**Quests**: The main quest is to defeat the main boss. But you will find yourself with multiple side quests for leveling up your chararacter. Such quests have to do with going in the dungeons to recieve items to defeat the boss.

**Items**:

- Pickaxe: Used to mine resources.
- Axe: Used to cut trees.

**Weapons**:

- Knife: Used to fight enemies in short range.
- Spear: Used to fight enemies in medium range.
- Blowgun: Used to fight enemies from a distance.

**Interface**

- _Health bar_: Shows the amount of health the player has.
- _Time_: Shows the time inside the game.
- _Map_: Shows the map of the world.

**Graphics**

| **Overworld** | **Dungeon** | **Boss Fight** |
| :-----------: | :---------: | :------------: |
|    - Trees    |   - Mobs    |     - Boss     |
|    - Rocks    |   - Items   |    -Effects    |
|    - House    |             |                |

### **Game Mechanics and Rules** !

The game will be a 2D game, with a top-down perspective in the main world and a side-on perspective in the dungeon. The game will alow you to explore in the main world and fight in the dungeon. The game will be a RPG, with a lot of items and stats that will alow you to customize your character. Each item would specific stats, and how good these items are would depend on the luck of the player. The game will be a Rogue-like, with a randomly generated dungeon that will alow you to keep playing the game and finding new items.

### **Stats** !

The stats that will alow to diferentiate the characters wil be the following:

- Health (HP): The amount of damage a character can take before dying.
- Attack (ATK): The amount of damage a character can do per hit to an enemy.
- Defense (DEF): The amount of damage a character can take per hit from an enemy.
- Agility (AGI): How fast can the character move and dodge.
- Mana Points (MP): The amount of damage the character deals with a special attack.
- Luck (LCK): The chance of getting better or worst items.

## _Technical_

---

### **Screens**

1. Title Screen
   1. Options
2. Level Select
3. Game
   1. Inventory
   2. Assessment / Next Level
4. End Credits

_(example)_

### **Controls**

How will the player interact with the game? Will they be able to choose the controls? What kind of in-game events are they going to be able to trigger, and how? (e.g. pressing buttons, opening doors, etc.)

### **Mechanics**

Are there any interesting mechanics? If so, how are you going to accomplish them? Physics, algorithms, etc.

## _Level Design_

---

_(Note : These sections can safely be skipped if they&#39;re not relevant, or you&#39;d rather go about it another way. For most games, at least one of them should be useful. But I&#39;ll understand if you don&#39;t want to use them. It&#39;ll only hurt my feelings a little bit.)_

### **Themes**

1. Forest
   1. Mood
      1. Dark, calm, foreboding
2. Objects
   1. _Ambient_
      1. Fireflies
      2. Beams of moonlight
      3. Tall grass
   2. _Interactive_
      1. Wolves
      2. Goblins
      3. Rocks
3. Castle
   1. Mood
      1. Dangerous, tense, active
   2. Objects
      1. _Ambient_
         1. Rodents
         2. Torches
         3. Suits of armor
      2. _Interactive_
         1. Guards
         2. Giant rats
         3. Chests

_(example)_

### **Game Flow**

1. Player starts in forest
2. Pond to the left, must move right
3. To the right is a hill, player jumps to traverse it (&quot;jump&quot; taught)
4. Player encounters castle - door&#39;s shut and locked
5. There&#39;s a window within jump height, and a rock on the ground
6. Player picks up rock and throws at glass (&quot;throw&quot; taught)
7. … etc.

_(example)_

## _Development_

---

<!-- ### **Abstract Classes / Components**

1. BasePhysics
   1. BasePlayer
   2. BaseEnemy
   3. BaseObject
2. BaseObstacle
3. BaseInteractable

_(example)_ -->

<!-- ### **Derived Classes / Component Compositions**

1. BasePlayer
   1. PlayerMain
   2. PlayerUnlockable
2. BaseEnemy
   1. EnemyWolf
   2. EnemyGoblin
   3. EnemyGuard (may drop key)
   4. EnemyGiantRat
   5. EnemyPrisoner
3. BaseObject
   1. ObjectRock (pick-up-able, throwable)
   2. ObjectChest (pick-up-able, throwable, spits gold coins with key)
   3. ObjectGoldCoin (cha-ching!)
   4. ObjectKey (pick-up-able, throwable)
4. BaseObstacle
   1. ObstacleWindow (destroyed with rock)
   2. ObstacleWall
   3. ObstacleGate (watches to see if certain buttons are pressed)
5. BaseInteractable
   1. InteractableButton

_(example)_ -->

## _Graphics_

---

### **Illustrations** !

At least 3 drawings that you make about your game: The main character, the design for the game logo, a sketch of the main game scene (with UI elements).
Optionally add maps, level designs, etc.

### **Visual References** !

At least 3 screenshots of similar games you are based on. If your game is a completely original idea, you can list other material that may be related (music, films, books, etc.)

### **Style Attributes**

What kinds of colors will you be using? Do you have a limited palette to work with? A post-processed HSV map/image? Consistency is key for immersion.

What kind of graphic style are you going for? Cartoony? Pixel-y? Cute? How, specifically? Solid, thick outlines with flat hues? Non-black outlines with limited tints/shades? Emphasize smooth curvatures over sharp angles? Describe a set of general rules depicting your style here.

Well-designed feedback, both good (e.g. leveling up) and bad (e.g. being hit), are great for teaching the player how to play through trial and error, instead of scripting a lengthy tutorial. What kind of visual feedback are you going to use to let the player know they&#39;re interacting with something? That they \*can\* interact with something?

### **Graphics Needed**

1. Characters
   1. Human-like
      1. Goblin (idle, walking, throwing)
      2. Guard (idle, walking, stabbing)
      3. Prisoner (walking, running)
   2. Other
      1. Wolf (idle, walking, running)
      2. Giant Rat (idle, scurrying)
2. Blocks
   1. Dirt
   2. Dirt/Grass
   3. Stone Block
   4. Stone Bricks
   5. Tiled Floor
   6. Weathered Stone Block
   7. Weathered Stone Bricks
3. Ambient
   1. Tall Grass
   2. Rodent (idle, scurrying)
   3. Torch
   4. Armored Suit
   5. Chains (matching Weathered Stone Bricks)
   6. Blood stains (matching Weathered Stone Bricks)
4. Other
   1. Chest
   2. Door (matching Stone Bricks)
   3. Gate
   4. Button (matching Weathered Stone Bricks)

_(example)_

## _Sounds/Music_

---

### **Style Attributes**

Again, consistency is key. Define that consistency here. What kind of instruments do you want to use in your music? Any particular tempo, key? Influences, genre? Mood?

Stylistically, what kind of sound effects are you looking for? Do you want to exaggerate actions with lengthy, cartoony sounds (e.g. mario&#39;s jump), or use just enough to let the player know something happened (e.g. mega man&#39;s landing)? Going for realism? You can use the music style as a bit of a reference too.

Remember, auditory feedback should stand out from the music and other sound effects so the player hears it well. Volume, panning, and frequency/pitch are all important aspects to consider in both music _and_ sounds - so plan accordingly!

### **Sounds Needed**

1. Effects
   1. Soft Footsteps (dirt floor)
   2. Sharper Footsteps (stone floor)
   3. Soft Landing (low vertical velocity)
   4. Hard Landing (high vertical velocity)
   5. Glass Breaking
   6. Chest Opening
   7. Door Opening
2. Feedback
   1. Relieved &quot;Ahhhh!&quot; (health)
   2. Shocked &quot;Ooomph!&quot; (attacked)
   3. Happy chime (extra life)
   4. Sad chime (died)

_(example)_

### **Music Needed**

1. Slow-paced, nerve-racking &quot;forest&quot; track
2. Exciting &quot;castle&quot; track
3. Creepy, slow &quot;dungeon&quot; track
4. Happy ending credits track
5. Rick Astley&#39;s hit #1 single &quot;Never Gonna Give You Up&quot;

_(example)_

## _Schedule_

---

_(define the main activities and the expected dates when they should be finished. This is only a reference, and can change as the project is developed)_

1. develop base classes
   1. base entity
      1. base player
      2. base enemy
      3. base block
2. base app state
   1. game world
   2. menu world
3. develop player and basic block classes
   1. physics / collisions
4. find some smooth controls/physics
5. develop other derived classes
   1. blocks
      1. moving
      2. falling
      3. breaking
      4. cloud
   2. enemies
      1. soldier
      2. rat
      3. etc.
6. design levels
   1. introduce motion/jumping
   2. introduce throwing
   3. mind the pacing, let the player play between lessons
7. design sounds
8. design music

_(example)_
