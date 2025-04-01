# Game Name

## Elevator Pitch

*Loop Factory is a fast paced game for elementary students, players can grab, assemble, and ship out orders all while learning the fundamentals of for and while loops through a fun hands-on gameplay!*

## Influences (Brief)

- *OverCooked*:
  - Medium: *Game*
  - Explanation: *The game works to take in ingredients to build a larger item like a meal, and in a similar matter out while loop belt will take in components to produce a final item.*
- *How its Made*:
  - Medium: *Television*
  - Explanation: *The show involves them going to the different production factories, within the scenes you can see the conveyor belts move the products as they go through each step.*
- *HellDivers 2*:
  - Medium: *Games*
  - Explanation: *In the game there is a mechanic where you have to input a certain order of keys to be able to use stratagems.*

## Core Gameplay Mechanics (Brief)
- *Pick up and carry the item over to the conveyor belts*
- *Shipment address must be correctly imputed to complete round*
- *If the wrong item is placed, health will be lost*
- *After you complete the round, an end of round screen appears*

# Learning Aspects

## Learning Domains

*Any and all of the disciplines and learning domains for this subject.*

## Target Audiences

- *Anyone new to loops that haven’t yet learned to identify how each of the loops work.*
- *Anyone that might want a game to help them refresh their memory on them.*
- *Novice programmers with a little prior programming knowledge.*
- *Should be appropriate for younger kids and adults who are young at heart.*

## Target Contexts

*This game can be used during classes, or in computer labs, especially in entry level coding courses where users are new to loops.*

## Learning Objectives

*Remember, Learning Objectives are NOT simply topics. They are statements of observable behavior that a learner can do after the learning experience. You cannot observe someone "understanding" or "knowing" something.*

- *Implementing Loops: The player can correctly apply for and while loops to collect and ship ingredients*
- *Controlling Loop Execution: The player can change loop behavior based on game objectives (e.g., stop when a condition is met)*
- *Loop Condition Evaluation: The player can determine when a loop should stop running depending on the state of the conveyor or ingredients.*

## Prerequisite Knowledge

*What do they need to know prior to trying this game?*

- *Prior to the game, players need to be able understanding basic programming concepts*
- *Prior to the game, players need to be able understanding factory or warehouse workflow*

## Assessment Measures

*Describe how the learning will be assessed, e.g., pre/post multiple-choice test, or SAT, or some other instrument.*

- *Given a loop condition, be able to identify which loop type matches.*
- *Given a loop type, be able to write a possible objective that displays the loop.*

# What sets this project apart?

*Give some reasons why this game is not like every other game out there. Whether the learning objective is unique, the gameplay mechanics are new, or what. You should persuade the reader that your game is novel and worthy of development. Consider arguments that would be persuasive to a Venture Capitalist, Teacher, or Researcher. These might be focused on learning needs, too.*

- *Real-World Application of Loops in Automation*
- *Bridging CS Education and Industry Needs*
- *Gamified Problem-Solving with Immediate Feedback*
- *Unique Factory Simulation Theme*

# Player Interaction Patterns and Modes

## Player Interaction Pattern

*How people play your game, how many players are involved at once, how they interact with the system works, etc.*

- *This game is played as a solo game. Players utilize WSAD to move their character around the map, then when they want to pick up an item they will press E. And when they finally finish their objective they need to use the four arrow keys in a given pattern that they have to correctly type out.*

## Player Modes

- *Single Player: You continuously work to win rounds until the player loses the game.*

# Gameplay Objectives

- *Managing Pre-Made Loops (Conveyor Belts) to Automate Production*:
    - Description: *Players will interact with pre-existing conveyor belts (loops) to ensure materials move correctly through different production stages. They must adjust parameters, such as speed, starting/stopping conditions, and branching paths, to maintain efficiency*
    - Alignment: *This aligns with "Implementing Loops" by helping players recognize how loops function in an automated system, even if they are not coding them directly. Players will interact with and modify loop behavior in a factory simulation.*
- *Controlling Loop Execution to Avoid Bottlenecks*:
    - Description: *Players must adjust when and how conveyor belts (loops) activate, using mechanisms like sensors, gates, and timers to avoid jams, wasted resources, or slow production times.*
    - Alignment: *This aligns with "Controlling Loop Execution" by requiring players to strategically manage when loops run or pause, similar to using break and continue statements in programming.*

# Procedures/Actions

*Users can pick up and place items, and walk around throughout the open floor areas.*

# Rules

*What resources are available to the player that they make use of?  How does this affect gameplay? How are these resources finite?*

- *If a player puts an incorrect item on the While Loop belt they lose a portion of health*
- *If a player puts a correct item on the While Loop belt it is accepted*
- *When all the necessary items have been added to produce one of the main items it will be spit out from the other side of the While Loop belt.*
- *Players can only put fully built items on the For Loop belt*
- *Players will have an index for all of the possible items that can spawn on the belt with their names for identification*
- *Players can only pick up one item at a time*
- *Limited time to complete the task*


# Objects/Entities

*What other things are in the world that you need to design? These may or may not directly translate to actual objects and classes.*

- *Character Sprite*
- *A variety of items parts that can build various vehicles*
- *Fully built vehicle items*
- *3 Working conveyor belts (While, For, and Item Spawner)*
- *Address shipment screen*
- *Factory background Scene*

## Core Gameplay Mechanics (Detailed)

- *Conveyor Belt  Mechanics*: *The conveyor belt system is the backbone of Loop Factory, serving as the primary method for transporting items through the automation process. Players will place items onto the conveyor belts, which move them toward processing stations or shipment areas. The belts operate continuously, simulating real-world production lines, and players must strategically design their layouts to optimize efficiency. Items placed on the wrong belts or sent in the incorrect order may cause workflow disruptions, forcing players to debug their automation setup.
The conveyor belts interact with other game elements, such as sorting machines, item processors, and shipment stations, making their placement crucial to a successful automation loop. Players must understand how for and while loops work to automate item movement effectively. For example, a for loop might be used to ensure a set number of items reach a processing station before moving to the next step, while a while loop could control continuous item flow based on specific conditions, such as waiting for a shipment order to be completed.*
- *Item Processing and Delivery*: *In Loop Factory, item shipping and delivery rely on structured loop logic to ensure that products are processed and sent correctly. The for loop is responsible for handling the delivery process, ensuring that shipments only go out when a specified condition is met. For example, a delivery truck will not dispatch until it has collected the required number of packages—such as waiting for three completed orders before proceeding. This enforces batch processing, teaching players how iteration works in real-world automation and logistics.
The while loop, on the other hand, controls item production and assembly by monitoring raw materials on the conveyor belt. Before a product can be completed, the loop waits until all necessary components have arrived at the assembly station. For instance, if the goal is to produce a car, the while loop ensures that the belt has received four tires, four doors, and one engine before triggering assembly. This mechanic reinforces the concept of waiting for conditions to be satisfied before executing an action, mirroring how while loops function in programming.*
- Interactive Item Handling & Error Recovery: While automation is key, players will also have direct control over item pickup and placement. Players can manually grab an item and carry it to a designated location, such as a processing belt or shipment belt. This mechanic introduces an interactive element that allows for strategic decision-making, enabling players to intervene when errors occur or optimize their system on the fly.
This mechanic becomes especially important when shipment belts require specific conditions to function—for example, a belt may only activate after receiving exactly three packages. If a player places the wrong item on a belt, they immediately lose health, the belt halts its operation, and alarms blare throughout the factory. The belt is temporarily paused until the player debugs the issue by removing the incorrect item. Once the wrong item is removed, the alarms stop, the belt resumes its function. The round only concludes when all orders have been fulfilled, ensuring players remain engaged in real-time problem solving throughout the session.

    
## Feedback

*Explicitly describe what visual/audio/animation indicators there are that give players feedback on their progress towards their gameplay objectives (and ideally the learning objectives).*

- *Items going into while loop will show if they are correct based on what color the tunnel flushes (green correct, red incorrect) and will give SFX sounds like a ding or err noise.*
  - *Players will also see an increase in the number of item parts they have collected based on a screen above the while loop belt.*
- *When they correctly ship all items they will all change into packaged shipping boxes and go out the belt, calling the end of round screen.*
- *There will be an index button that will pull up a screen pausing the game, so that they can take their time looking at all of the item images and know the names for each of them.*

# Story and Gameplay

## Presentation of Rules

*The game introduces mechanics through an interactive tutorial level, ensuring players learn by doing. Players start with a simple conveyor belt, tapping to activate it and observing how loops automate movement. Next, they encounter obstacles and speed controls, learning to adjust conveyor efficiency. They then interact with sensor-based conveyors, understanding how loops execute based on conditions. A sorting challenge follows, teaching players to control splitters and direct products efficiently. Finally, they enter a free play section, experimenting with settings to complete a small order. This hands-on, step-by-step approach ensures gradual learning, immediate feedback, and engagement without overwhelming players.*

## Presentation of Content

*The title screen will have a button to go to a tutorial where they will go through a super simplistic run through of a round. Players will get to see how they can move, how they can pick up and put down items, and how they can produce a vehicle so they can learn the core mechanics of the game before they start. The tutorial will pause with small instructions like “Your player moves with WASD, walk around to the highlighted area”.*

## Story (Brief)

*The Summary or TL;DR version of below*

*You’re a junior robot engineer working in the LOOP FACTORY where everything is built with code! Today is your first day, and your job is to manage shipments using loops. With only loops to help you, can you keep up with the chaos and make it to the top?*

## Storyboarding

In Loop Factory, players take on the role of a junior robot engineer starting their first day in a chaotic, code-driven manufacturing plant. The game opens with a wide shot of the factory floor—conveyor belts whirring, robotic arms zipping around, and Supervisor Bot greeting the player with a holographic message: "Everything here runs on code—loops are the name of the game!" The player is introduced to basic for-loops as they automate a simple task: placing five crates onto a conveyor belt. Each line of code directly corresponds to a visual action, reinforcing the code-to-reality connection. As the game progresses, complexity increases with nested loops, where players must pack multiple items into multiple boxes, demonstrating how actions repeat within actions. A visual grid of boxes and looping animations clearly shows loop nesting in action. Midway through, the factory descends into chaos when an infinite loop is triggered (when the player puts the wrong item on a conveyor belt) alarms blare, crates overflow, and the conveyor belts freeze. The screen displays faulty code in red, challenging players to debug and restore order. This introduces key programming dynamics like error handling and control flow. Upon completing all orders, the player is rewarded with a promotion sequence: rising on a glowing platform, receiving a new badge, and unlocking a new zone with advanced challenges like while-loops and conditional logic. The game visually and interactively teaches coding principles through escalating tasks, code-driven machinery, and real-time feedback, creating an immersive and educational gameplay loop.

![image](./Assets/storyboard.png)

# Assets Needed

## Aethestics

This game takes place in a factory setting, it is entirely designed in pixel 2D art. It has music and SFX to create a factory environment with machine noises, moving belts, just to show it is a functioning factory. Each round will start out relaxing and calm, the game will continue as such unless the player is close to losing then the ambiance will change to a more nervous and rushed vibe. It will put pressure on the player to show the stress and how careful they have to be as they continue to be able to play on.

## Graphical

- Characters List
  - *Robot character that user plays as*
- Textures:
  - *Machine/Conveyor belt:*
    - *Polished chrome for robotic arms*
    - *Rusted iron for outdated units*
  - *Item texture:*
    - *Crate surfaces (wood, metal, plastic)*
	  - *Barcode stickers or shipment labels*
- Environment Art/Textures:
  - *Metallic Floor Panels*
  - *Moving tread texture with industrial rubber grip*
  - *Large riveted metal sheets*
  - *Retro-futuristic texture: blinking lights and buttons*
  - *Shipment area:*
    - *Clean, white-tiled or metal area*
    - *Glowing “3/3 Packages Received” indicators*
  - *Debug Zone*
	  - *Glitched tile texture (pixelated or fragmented)*
	  - *Error symbols embedded in the surface (e.g., ⚠️ or ! loops)*


## Audio


*Game region/phase/time are ways of designating a particularly important place in the game.*

- Music List (Ambient sound)
  - *Game Play w/ High health:* *Calm fun music, randomized whirring machine noises in background*
  - *Game Play w/ Low Health:*: *Faster Background music, it’s louder*
  
*Game Interactions are things that trigger SFX, like character movement, hitting a spiky enemy, collecting a coin.*

- Sound List (SFX)
  - *Wrong Item on While Loop Belt:* *Buzzer Noise, Belt Breaking noise*
  - *Shipping out items:* *Tape Ripping, Whooshing noise (like wind)*


# Metadata

* Template created by Austin Cory Bart <acbart@udel.edu>, Mark Sheriff, Alec Markarian, and Benjamin Stanley.
* Version 0.0.3
