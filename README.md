[![Open in Visual Studio Code](https://classroom.github.com/assets/open-in-vscode-2e0aaae1b6195c2367325f4f02e2d04e9abb55f0b24a779b69b11b9e10269abc.svg)](https://classroom.github.com/online_ide?assignment_repo_id=16106446&assignment_repo_type=AssignmentRepo)

Basmah Arif | Module CMP6206 Artificial Intelligence for Games | Student ID: 21159823


## Overview

This file contains the development of an Artificial Intelligence Game project created using Unity and Visual Studio. The game focuses on implementing AI agents, advanced gameplay mechanics such as Boss Battles and Finite State Machines. It includes descriptions of the game's structure, development progress, technologies used and instructions for setup and contributions. 

## Description of the Game

The game is a Level 1 Boss Battle where the protagonist, a human warrior, battles a Dracula, who appears to be very powerful/terrifying vampire leader. Dracula appears as a slightly larger, more imposing figure in this dramatic battle, towering over the human warrior to signify the difficult task that lies ahead. There will be Dracula's bat minions who are AI-controlled agents that the human player must carefully combat while avoiding waves of them. The gameplay will become more difficult as a result of these bat agents spawning periodically throughout the battle. As Dracula's faithful slaves, the bats attack the player from every angle, requiring them to continuously strike a balance between attack and defence. The player must carefully dodge the harm caused by the bats in addition to using direct battle to exhaust his health in order to beat Dracula. Both Dracula and the bats' behaviours will be controlled by different Finite State Machines (FSMs), which will make their actions dynamic and difficult. While Dracula will have several states, including Idle, Attack, and Retreat, the bats will gather around the player and do damage occasionally in response to health thresholds and distance checks. Both the player and the enemy will have health checks in the game. The player's and Dracula's health bar will drop when they sustain damage. Throughout the game level, power-ups will be positioned strategically to give players the chance to regain their health at certain times. The game will become increasingly challenging as Dracula's health declines, increasing the strain in the closing seconds of the fight as the AI system carefully controls the bat agents' behaviour and spawning. The Game will also distance-based attacks including Close Range and Mid to Long Range. In Close Range, if the player gets too close in distance to Dracula, he will use devastating melee strikes, including strong bites. In Mid to Long Range, if the player stays farther away, the Dracula will resort to ranged attacks such as sending out waves of bats. 

## Game Mechanics

1. Main Character: A Human Warrior who uses weapons to fight off Dracula and his Bat Minions.
  
2. Dracula (Main Boss): The Ultimate Boss is a large, strong vampire king. His attacks are deadline and his size increases his reach and strength. He will fight in phases, growing more violent as his health decreases.
  
3. Bat Minions (AI Agents): The AI-Controlled bats will be spawning throughout the level. They are the player's constant threat and act as additional enemies. AI logic will determine their behaviour (including attack patterns) and frequency of spawning, resulting in a dynamic battlefield.
  
4. Finite State Machines:
  
 - Dracula: Dracula will be able to move between the following states: Idle, Attack, Summon Minions, Damage, and Retreat. This will make battles unpredictable and interesting.
 
 - Bats: Bats will interact with the player and determine their attack patterns using an FSM.
 
5. Health Checks: When an enemy or player sustains harm, their health declines. Throughout the fight, strategically placed power-ups will be available to restore health.
   
6. Distance Checks: AI Agents will decide how frequently to attack depending on how far away they are from the player, making positioning in the game more tactically challenging.
   
7. Damage System:  A well-balanced mechanism that determines the amount of damage caused by the player and enemies according to attack type and proximity.

## Background/Motivation

The game has been inspired by my childhood interest with vampires, especially the mythical Dracula. Because of their mysterious nature, life expectancy, and sinister charm, vampires have always captivated me. My decision to create my game on a boss fight with Dracula was driven by this obsession. My goal is to draw players into a gothic, spooky setting that relies on this immortal mythos by include vampires and bats. In order to further establish Dracula as a terrifying opponent, it has been decided to make him somewhat larger than human warrior, which leaves the player feeling powerless and in fear. I choose to concentrate on Finite State Machines (FSMs) for the AI behaviour because I want to provide an engaging and difficult experience. Since FSMs enable more complex opponent behaviour, boss battles become unpredictable and fascinating. In order to balance the game's difficulty level and provide the player with feedback on their performance, I'm also including health and distance checks. By attacking the player at crucial times when they are most exposed, the AI agents (bats) will be vital in raising the tension. These agents will be called out by Dracula at certain health thresholds, which is closely related to his combat plan.


## UML Class Diagram 

![uml diagram](https://github.com/user-attachments/assets/4e32ec0c-f36d-4cce-b31a-90673dc6e065)


## Development Specification

**Player**

![Player](https://github.com/user-attachments/assets/54ac54a4-0102-430e-a247-db84238bb119)


**Boss Dracula**

![Dracula Boss](https://github.com/user-attachments/assets/957f6cce-c773-4126-acd7-921380b1f567)


**Map Layout**

The map features a central river dividing open battle zones and dense forest areas, creating natural obstacles and strategic points for AI pathfinding and ambushes in the Dracula boss battle. 

**Gameplay Implications:**

- **Strategic Movement:** The river, forested areas and rocks make navigation and combat strategic so the player and AI agents can carefully move around obstacles.

- **Pathfinding Complexity:** The combination of walkable and non-walkable areas provides a challenging environment for pathfinding, especially when further implementations of algorithms like A* will be used to navigate around obstacles.
  
- **Ambush and Defense:** The trees and rocks offer tactical ambush spots for bats, while the open areas and river crossings become high-stakes zones for confrontations with Dracula.

![Map Layout](https://github.com/user-attachments/assets/b865999b-38b2-4c4a-a31b-db1da8fc97e5)


**Initial Progress by Week 8**

Below is the initial progress of the gameplay which shows the player facing off against the Dracula boss character in an open environment. 

![Progress](https://github.com/user-attachments/assets/9af2995b-3de2-4a67-9771-5b4d96d3d54a)


## Technologies Used

- Visual Studio: https://https//code.visualstudio.com/ (Code Development)
  
- Unity: https://unity.com/ (Game Engine used for development)
  
- GitHub: (Version control and collaboration)
  
- C#: (Programming Languages for scripting and game mechanics)

  
## Tutor Feedback Reflection

**Week 3 Feedback**
- **Feedback:** Add more detailed descriptions in README and organize project folders better. Also start implementing AI Agents in the Game, detailing their actions/roles and determine how to manage the frequency of damaging the Main Boss of my game.
- **Action Taken:** Updated README with clearer descriptions, folder structure, and added weekly logbook for reflection. Started planning AI Agents for my game. I roughly designed the Dracula Boss as the main character and implemented bat agents to act as enemies. These bat agents will be spawned at intervals, with their actions revolving around attacking the main character. I also began planning their behaviors using finite state machines (FSM), focusing on their damage-dealing frequency and how they will coordinate with the Main Boss (Dracula) to create a challenging gameplay experience. Incorporated health and distance checks to manage how often the AI Agents damage the Main Boss, ensuring the game balance and player engagement.

**Week 4 Feedback (Milestone 1)**
- **Feedback:** I have been awarded 5.00 marks for my first milestone for GitHub Repro. The feedback which I received was to link the GitHub Project within the repository, as it was externally done. 
- **Action Taken:** I had a discussion with Dr.Carlo to invite me to the BCU organization so I can link my Project accurately within the repository. Then after I had access, I added the projects to my repository. I also worked on my Pull Request Code reviews in the github repository and also I made sure to fix the issue with my CI /CD Build Issue in the repository. 

**Week 9 Feedback (Milestone 2)**
- **Feedback:** I have been awarded 5.00 marks for my second milestone for GitHub Repro. I have briefly discussed with Dr.Carlo about the Boids which I should use in my GameScene and he has suggested me that Spawning & Flocking Bats will be easier for me.
- **Action Taken:** I am going to further implement my GameScene with Behaviour Trees and Boids so next week I can get further feedback from Dr.Carlo and improve furthermore. 

**Week 10 Feedback**
- **Feedback:** During Week 10, I discussed about my concerns regarding few elements in my game scene. Dr.Carlo provided detailed feedback on implementing boids in my game scene. He suggested refining the flocking behaviour for the bats to make their movement more natural and immersive. He emphasized the importance of aligning the boids' movement with the game’s environment and ensuring that the flock responds dynamically to player actions, such as scattering or regrouping when the player is nearby.
- **Action Taken:** Following the feedback, I worked on implementing the boids' flocking behaviour using Unity's steering behaviour principles. I enhanced the bats’ movement by tweaking parameters like alignment, cohesion and separation, ensuring the flock moved cohesively while maintaining individual agent autonomy. Additionally, I integrated spawning mechanics for the boids, allowing bats to appear dynamically based on the player’s location in the game scene.

**Week 12 Feedback (Milestone 3)**
- **Feedback:** I have been awarded 5.00 marks for my third milestone for the GitHub repository. Dr. Carlo reviewed my current progress and suggested further enhancing the game by integrating additional AI features, such as more complex behaviour trees and dynamic obstacle interactions before the bootcamp review. I also asked him few questions related to Unity packages for usage in my Project. 
- **Action Taken:** Building on the feedback, I started refining the Behaviour Trees to create more advanced and realistic bat AI behaviours. This includes introducing state transitions where the bats can alternate between passive flocking, attacking and retreating based on the player’s proximity and actions. Additionally, I began working on dynamic obstacle interactions, allowing bats to adjust their paths to avoid collisions dynamically.

**BootCamp Feedback:**


## Folders / Structures

Basmah_Arif_21159823

- [bin] (contains compiled binaries)

- [code] (contains source code)

- imgs (contains projects images and visual assets)

- [labs] (contains lab workshops from week to week, documenting the progress of lectures)

- .gitignore (contains untracked files to ignore in Git such as Build files, logs)

- [Readme] (this file contains documentation)

- [video] (this file will contain gameplay and project demo videos with h264/aac however not yet implemented)


## Installation

Clone the repository to your local machine: 

git clone https://github.com/Birmingham-City-Uni/milestones-ai-24-25-basmah113.git

Open the project in Unity. 

Build and run the application.


## Visual Studio

TODO:

Download Visual Studio from the "https://visualstudio.microsoft.com/downloads/"

Run the installer

Selected recommended workloads (C++)

Open Visual Studio from application folder


## Development Methodology

- I have used GitHub Projects Agile methodology to track my tasks and progress.
  
- Regular use of GitHub Issues for feature tracking and task assignment.

**Quality Assurance**

- I will be using code linting for consistency and bug prevention

- CI/CD setup in GitHub to ensure smooth integration and testing.
  
- Regular code reviews by automated tests to validate the codebase. 

## Contributing

1. Git hub repository
   
2. Check out a new Feature branch: git checkout -b myrepository
 
3. Commit changes: git commit -am 'basmah113'
  
4. Push to the branch: git push origin my-repository
  
5. Submit a pull request :D


**Contributors**
- Basmah Arif - Lead Developer


## Weekly Logbook
Throughout my time in studying, this weekly logbook will document the skills, methodologies, and achievements I acquire and accomplish during my Semester 1 Artificial Intelligence Module. I will record this information on a week-to-week basis, offering detailed insights into the tasks I undertake. Moreover, I will highlight how these tasks contribute to expanding my expertise in my role as an Artificial Intelligence Developer. 

## September 2024

**Week 1: Introduction of the module – W/C 23rd September 2024**
- **Summary:** Introduction to the AI module and assessment guide. Dr.Carlo gave us an overview of the project and past students' examples. Initial setup for organizing files and GitHub repository.
- **Progress:** Created project folder structure and started the logbook. Completed the lab on vectors in Unity and Linear Regression along with decision trees.
- **Reflection:** Felt confident after organizing files and completed the Labs. 
- **Next Steps:** Continue refining the project idea and complete further labs.


**Week 2: Lab workshops & Idea of the Game – W/C 30th September 2024**
- **Summary:** Learned about Finite State Machines and worked on labs for Dot Cross Product and FSM. Continued researching ideas for my game project.
- **Progress:** Completed labs, began drafting the game design. Decided to build a boss battle game.
- **Reflection:** Labs were manageable but Game idea needs more research.
- **Next Steps:** Refine game concept and create initial layout.


## October 2024

**Week 3: Updating GitHub, Presentation & Preparation for Milestone 1 – W/C 7th October 2024**
- **Summary:** Focused on organizing the GitHub repository and preparing for Milestone 1. Dr.Carlo provided guidance on best examples for GitHub project structure and logbook maintenance. I also discussed my Game Idea with Dr.Carlo and he gave me feedback on the further improvements which needs to be completed. 
- **Progress:** Organized the repository, added weekly logs, and created GitHub issues for task tracking. Began brainstorming the Dracula boss battle AI mechanics and incorporated feedback from Dr. Carlo.
- **Reflection:** Felt more confident after structuring the repository. Tutor feedback was helpful in refining the game concept and mechanics.
- **Next Steps:** Implement AI mechanics for the Dracula boss, including bat agent spawning and damage logic.


**Week 4: Milestone 1 Feedback & Implementation of Game – W/C 14th October 2024**
- **Summary:** Received full marks on the GitHub repository with feedback from Dr.Carlo. Started with Week 4 Lab workshops along with my Game implementation.
- **Progress:** I started creating Pull Requests with code reviews in my repository along with linking my Project within the repository as it was externally done before. I also updated the README weekly logs and feedback along with implementation of Game scene with Pathfinding AI Grid.
- **Reflection:** The feedback which I had received was already completed on the same day. I also completed Lab workshops and started the Pathfinding implementation within my game scene.
- **Next Steps:** Further work on my Game and its mechanics with AI agent behaviours.

**Week 5: Started Implementing Game Scene  – W/C 21st October 2024**
-	**Summary:** Initiated the development of the game scene, focusing on foundational aspects like the layout, player movement and initial AI setup.
-	**Progress:** This week, I implemented the basic environment for the game, laying out the path where the player would navigate. I began integrating AI components for the first iteration of Pathfinding, creating grid-based navigation to guide the AI agents along designated paths. This involved setting up an initial AI framework and configuring the movement boundaries.
-	**Reflection:** Setting up the game scene was challenging, especially ensuring the layout aligned with the mechanics and the planned AI movements. Despite the complexity, I managed to establish a clear structure for the AI to operate within. Working on the scene’s design provided insight into necessary adjustments for smoother gameplay flow.
-	**Next Steps:** Further refine the AI navigation by adding obstacles for agents to interact with and improve the pathfinding grid's efficiency. Continue working on additional game mechanics and AI behaviour customization.

**Week 6: Implemented Pathfinding and Enhanced AI Agent Behaviours – W/C 28th October 2024**
-	**Summary:** Completed the Pathfinding implementation for the game’s AI and started focusing on more agent behaviours to simulate realistic movement and reactions.
-	**Progress:** Successfully integrated Pathfinding with Unity’s AI system, allowing agents to dynamically navigate the grid while avoiding obstacles. I worked on fine-tuning AI agent behaviours, making them responsive to player actions and environmental changes. This included implementing basic obstacle avoidance and exploring various algorithms to ensure the AI agents could adapt to changes in the player’s path.
-	**Reflection:** Integrating Pathfinding was a significant milestone, as it allowed for dynamic movement and interactivity with the player. Fine-tuning the AI behaviours required experimentation with different configurations to achieve realistic responses. The AI now interacts better within the game environment, adding an element of challenge and immersion.
-	**Next Steps:** Begin testing and optimizing the AI behaviours for efficiency and smooth gameplay. 


## November 2024

**Week 7: Worked on Game Project & Prepared for Milestone II – W/C 04th November 2024**
-	**Summary:** Focused on refining the game mechanics and responding to feedback from Milestone I. Worked on polishing the AI Pathfinding, further enhancing the player interaction experience and addressing previous feedback.
-	**Progress:** This week, I revisited the feedback from Milestone I, implementing recommended changes to improve the game’s overall quality. Enhancements included refining the Pathfinding AI grid and improving the response time of AI agents to player actions. I also documented these changes in the repository and updated my weekly logs. Additionally, I started preparing for Milestone II by creating a detailed plan for showcasing the current progress and the core functionalities implemented so far.
-	**Reflection:** Implementing these changes made the game flow more naturally and added a layer of polish to the AI mechanics. Preparing for Milestone II also helped me assess the progress and areas that need further development.
-	**Next Steps:** Continue refining the game mechanics and AI behaviours based on feedback from Milestone II. 

**Week 8: Milestone II Submission – W/C 11th November 2024**
-	**Summary:** Submitted Milestone II submission and learned about steering behaviours in this week’s lab. Dr.Carlo suggested focusing on implementing boid behaviours for bats in my game, particularly focusing on flocking and spawning mechanics.
-	**Progress:** Completed the lab on steering behaviours and flocking, where I implemented basic bird flocking behaviours and explored how to adapt this technique for my bats in the game. I also integrated boid mechanics into my game scene and began experimenting with spawning logic for the bats. Additionally, I documented the updated feedback in my repository and started refining AI agent movement in my game.
-	**Reflection:** The steering behaviours lab provided a great foundation for understanding flocking and cohesive movement in AI agents. Applying this to my bats in the game added a dynamic layer to their behaviour, making them feel more realistic and interactive. Feedback from Dr. Carlo guided me to better structure the spawning mechanics.
-	**Next Steps:** Refine the flocking mechanics for the bats and finalize their spawning behaviour. Start integrating these updates into the overall gameplay loop and ensure their interactions align with the player’s actions.

**Week 9: Boid Mechanics and Game Scene Enhancements – W/C 18th November 2024**
-	**Summary:** This week focused on boid mechanics and their implementation in AI. I also worked extensively on the game scene, enhancing Pathfinding, navigation and behaviour trees for both bats and other AI agents.
-	**Progress:** In the lab, I learned about the fundamentals of boid steering and movement, focusing on behaviours like cohesion, separation and alignment. These principles were then applied to improve the bats’ flocking behaviours in my game. Additionally, I refined the behaviour trees in Unity to add more reactive AI interactions and started testing how the bats’ movements influence player engagement. The Pathfinding AI grid was optimized further, ensuring smoother transitions and fewer glitches.
-	**Reflection:** Diving deeper into boid mechanics helped me refine the bats’ behaviours, making them more fluid and cohesive. Integrating these updates into the game scene added more complexity to the gameplay while maintaining a sense of realism. Behaviour trees required careful planning to ensure logical decision-making for the AI.
-	**Next Steps:** Continue refining the behaviour trees and boid mechanics while ensuring they align with the game’s overarching goals. Begin testing how these updates affect gameplay difficulty and player immersion.

**Week 10: Reinforcement Learning with ML Agents – W/C 25th November 2024**
-	**Summary:** Focused on reinforcement learning through ML agents in Unity and implemented elements of the hummingbird lab into my game. Continued working on the game scene to integrate reinforcement learning concepts.
-	**Progress:** Completed the ML agents hummingbird lab, where I learned how to train agents using reinforcement learning. I began adapting these concepts to my game by experimenting with dynamic player interactions. For example, I started testing how AI agents could dynamically respond to player actions, such as chasing or evading based on specific reinforcement criteria. Additionally, I refined the Pathfinding system, ensuring seamless integration with these behaviours. I also continued updating my repository and logbook to document these changes.
-	**Reflection:** The ML agents lab was challenging as it introduced a new layer of intelligence to the AI agents. Applying reinforcement learning concepts to my game required additional experimentation, but the results were promising in creating more reactive and intelligent agents. This week also reinforced the importance of testing and iterating to achieve desired outcomes.
-	**Next Steps:** Build upon reinforcement learning principles to create smarter AI behaviours. Focus on ensuring all AI interactions feel cohesive within the game environment.


## December 2024

**Week 11: Neural Networks and Milestone III Preparation – W/C 2nd December 2024**
-	**Summary:** This week, we got introduced to neural networks, focusing on the Smart Kart lab, while continuing to implement Unity ML agents from the previous week. Additionally, I began preparing for Milestone III by consolidating the progress made so far.
-	**Progress:** Completed the Smart Kart neural network lab, which provided valuable insights into creating goal-oriented AI agents. I continued refining the hummingbird implementation to further explore reinforcement learning in Unity ML agents. In the game scene, I focused on integrating neural network concepts to improve AI decision-making. Furthermore, I started preparing for Milestone III by compiling updated documentation, creating a summary of the AI mechanics implemented and outlining the next stages of development.
-	**Reflection:** Learning about neural networks was both challenging and exciting, as it opened up possibilities for more advanced AI behaviours in the game. Preparing for Milestone III helped me reflect on the progress made so far and identify areas that require further improvement. The integration of neural networks into the game added a level of depth to the AI, making it more responsive and intelligent.
-	**Next Steps:** Finalize preparations for Milestone III, ensuring all documentation is ready. Continue iterating on the game scene to polish AI behaviours and interactions.

**Week 12: Genetic Techniques and Milestone III – W/C 9th December 2024**
-	**Summary:** This week, we explored genetic techniques in AI, focusing on how evolutionary algorithms can be applied to optimize decision-making and agent behaviours. I continued refining my game scene, implementing additional AI features such as enhanced bat flocking and dynamic interactions. Additionally, I finalized and submitted Milestone III, incorporating feedback from previous weeks and demonstrating the improvements made to the AI mechanics.
-	**Progress:** Completed the lab on genetic techniques, which provided insights into using evolutionary algorithms to optimize agent behaviour. I started exploring how these techniques could improve decision-making in the Behaviour Trees of my AI agents. In the game scene, I implemented further enhancements to the bats' behaviour, allowing them to dynamically adapt to player actions and environmental triggers. I also refined the spawning system to make it more efficient and cohesive. These updates were documented and showcased in the Milestone III submission.
-	**Reflection:** Learning about genetic techniques expanded my understanding of optimization in AI, particularly in creating adaptive behaviours for agents. Applying these concepts to my project was challenging but rewarding, as it improved the realism and depth of the bat AI. Milestone III provided an opportunity to consolidate my progress and demonstrate how feedback and new concepts have been integrated into the project.
-	**Next Steps:** Begin implementing additional game features, such as environmental triggers and advanced player interactions, in preparation for the final submission. 

**Week 13: BootCamp Session & Project Implementation for Submission – W/C 16th December 2024**
-	**Summary:** Pending
-	**Progress:** Pending
-	**Reflection:** Pending
-	**Next Steps:** Pending

**Week 14: – W/C 23rd December 2024**
-	**Summary:** Pending
-	**Progress:** Pending
-	**Reflection:** Pending
-	**Next Steps:** Pending

**Week 15: – W/C 30th December 2024**
-	**Summary:** Pending
-	**Progress:** Pending
-	**Reflection:** Pending
-	**Next Steps:** Pending

## References

-Here is the list reordered in alphabetical order:

- Code, C. (n.d.). Create great GAME OVER screen in Unity UI - Unity tutorial. [online] Available at: <https://www.youtube.com/watch?v=K4uOjb5p3Io>.
- Code Monkey. (n.d.). How to use Machine Learning AI in Unity! (ML-Agents). [online] Available at: <https://www.youtube.com/watch?v=zPFU30tbyKs>.
- DarkWing (2023). Unity | How to make a simple AI Navigation System - 2023. [online] YouTube. Available at: <https://www.youtube.com/watch?v=HOAPvQONpsU> [Accessed 2 October 2024].
- FAR Gaming (2023). NEW AI Navigation - Unity 2023. [online] YouTube. Available at: <https://www.youtube.com/watch?v=K6bBC0qkImI> [Accessed 2 November 2024].
- Hackl, D. (n.d.). Recreating the FALSE KNIGHT Boss Fight in UNITY using Behavior Trees. [online] Available at: <https://www.youtube.com/watch?v=X7VwAGvAOIw> [Accessed 7 December 2024].
- Iain McManus (2021). Unity AI Tutorial: Finite State Machines. [online] YouTube. Available at: <https://www.youtube.com/watch?v=cwlFbLLR3qc> [Accessed 2 October 2024].
- Jason Weimann (GameDev) (2024). New Unity AI Navigation System - Click To Move & Animation in Unity3d. [online] YouTube. Available at: <https://www.youtube.com/watch?v=sOIQCHNJbCs> [Accessed 9 December 2024].
- Lague, S. (2014). A* Pathfinding (E01: algorithm explanation). [online] www.youtube.com. Available at: <https://www.youtube.com/watch?v=-L-WgKMFuhE>.
- LlamAcademy (2021). NavMesh Basics - Introduction to the NavMeshSurface | AI Series Part 1 | Unity Tutorial. [online] YouTube. Available at: <https://www.youtube.com/watch?v=aHFSDcEQuzQ> [Accessed 2 October 2024].
- LlamAcademy (2023). GOAP Enemy AI FULL IMPLEMENTATION | AI Series 50 | Unity Tutorial. [online] YouTube. Available at: <https://www.youtube.com/watch?v=85kogmzcLXw> [Accessed 2 October 2024].
- opsive (2017). Behavior Tree Basics: What is a Behavior Tree? [online] YouTube. Available at: <https://www.youtube.com/watch?v=PuLuwzgYB4g> [Accessed 20 December 2024].
- Pixabay, n.d. Game Over Sound Effects Search. [online] Available at: <https://pixabay.com/sound-effects/search/game-over/> [Accessed 2 January 2025].
- Pixabay, n.d. Victory Sound Effects Search. [online] Available at: <https://pixabay.com/sound-effects/search/victory/> [Accessed 2 January 2025].
- Pixabay, n.d. Vampire Sound Effects Search. [online] Available at: <https://pixabay.com/sound-effects/search/vampir/> [Accessed 10 December 2024].
- The Messy Coder (2018). Unity Tutorials - create AI Trees with Behaviour Designer. [online] YouTube. Available at: <https://www.youtube.com/watch?v=mPbIx5G8Y1E> [Accessed 20 December 2024].
- Unity Asset Store, n.d. Behavior Bricks. [online] Available at: <https://assetstore.unity.com/packages/tools/visual-scripting/behavior-bricks-74816> [Accessed 2 January 2025].
- Unity Asset Store, n.d. Free Low Poly Swords - RPG Weapons. [online] Available at: <https://assetstore.unity.com/packages/3d/props/weapons/free-low-poly-swords-rpg-weapons-198166> [Accessed 2 January 2025].
- Unity Asset Store, n.d. Free Modular Character - Fantasy RPG Human Male. [online] Available at: <https://assetstore.unity.com/packages/3d/characters/humanoids/humans/free-modular-character-fantasy-rpg-human-male-228952> [Accessed 2 January 2025].
- Unity Asset Store, n.d. Level 1 Monster Pack. [online] Available at: <https://assetstore.unity.com/packages/3d/characters/creatures/level-1-monster-pack-77703> [Accessed 10 December 2024].
- Unity Asset Store, n.d. Low Poly Simple Nature Pack. [online] Available at: <https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153> [Accessed 2 October 2024].
- Unity Asset Store, n.d. Vampire 1. [online] Available at: <https://assetstore.unity.com/packages/3d/characters/vampire-1-236808> [Accessed 2 December 2024].
- Unity Asset Store, n.d. Volumetric Lines. [online] Available at: <https://assetstore.unity.com/packages/tools/particles-effects/volumetric-lines-29160> [Accessed 10 December 2024>.



















