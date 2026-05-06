# KUKA Arm Simulation

This project is a Unity-based simulation of a KUKA robotic arm equipped with a gripper and a camera. The arm automatically sorts colored blocks by picking and placing them into designated areas based on their color, demonstrating basic robotics, automation, and computer vision concepts.

## Features
- Simulates a 6-axis KUKA robotic arm with realistic movement
- Functional gripper for picking and placing blocks
- Camera system for color detection and sorting
- Automatic and manual control modes
- Block spawning and color-based sorting
- User interface for controlling and monitoring the simulation

## Demo
**[Download the built version](https://drive.google.com/file/d/15pb26KJ1cmQXRvF5crCmAyVF-gdmzCSW/view?usp=sharing)**

## Screenshots
<!-- Add screenshots of the simulation here -->
![Simulation Screenshot 1](docs/screenshot1.png)
![Simulation Screenshot 2](docs/screenshot2.png)

## Requirements
- Unity Editor **2021.2.0f1** (or compatible with minor adjustments)
- Windows OS recommended
- Dependencies managed via Unity Package Manager (see `Packages/manifest.json`)

## Setup Instructions
1. Clone or download this repository.
2. Open the project in Unity Editor (version 2021.2.0f1 recommended).
3. Open the main scene from `Assets/Scenes/`.
4. Press Play to start the simulation.

## Controls
- **Arm Movement**: Use the UI input fields or on-screen controls to move each joint.
- **Gripper**: Open/close the gripper using the UI or assigned keys.
- **Block Spawning**: Press `Scroll Lock` to spawn a new block.
- **Camera**: Switch between main and secondary camera views via the UI.
- **Start Simulation**: Any key to begin from the start menu.
- **Block Interaction**: Press `Backspace` to apply force to a block (for testing).

## Project Structure
- `Assets/Scripts/` — C# scripts for arm logic, gripper, camera, block behavior, and UI
- `Assets/Animations/` — Animation controllers for arm and gripper
- `Assets/Prefabs/` — Prefab objects for blocks and arm parts
- `Assets/Scenes/` — Main Unity scenes

## Credits
Developed as a university project (2021) by Tian Bornman, BrandonFrade, Kyle van Niekerk.

## License
This project is for educational and demonstration purposes.
