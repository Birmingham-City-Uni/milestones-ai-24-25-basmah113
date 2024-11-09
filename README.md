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

**Week 8 Feedback (Milestone 2)**
- **Feedback:** PENDING
- **Action Taken:** PENDING


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

**References:**


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
- **Summary:** Focused on organizing the GitHub repository and preparing for Milestone 1. Dr. Carlo provided guidance on best examples for GitHub project structure and logbook maintenance. I also discussed my Game Idea with Dr.Carlo and he gave me feedback on the further improvements which needs to be completed. 
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

**Week 8: Milestone II Feedback – W/C 11th November 2024**

Pending
