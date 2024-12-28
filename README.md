# Pair Picker

## Overview

This repository contains the prototype for a simple card-matching game with code name **Pair Picker** developed as part of an assessment. 

## Project Details

No graphic assets & animation assets is used as the intention is to showcase programming skills. 
Cards visuals are done by Textmeshpro asset. 
Animations are completely handled by code.

### Features

- **Card Flipping and Matching:**
  - Cards flip and match smoothly with animations.
  - Continuous card flipping is supported, allowing users to select new cards while the previous ones are still being compared.
  - Cards are revealed for 0.5 seconds on start of each levels.

- **Card Layouts:**
  - Supports various card layouts. Designers can add more levels by editing Scriptable object used for storing level data.
  - Cards dynamically scale to fit the display area

- **Save/Load System:**
  - Implemented a json based save system to persist the player's progress, so the game state is saved between sessions.
  - Player can continue from last played level.

- **Scoring System:**
  - A basic scoring mechanism tracks the player's progress.
  - No combo system is added .But a hidden score multiplier is there for which the value increses over each level.

- **Sound Effects:**
  - Integrated sound effects for the following actions: card flipping, matching, mismatching, and game over.

- **Cross-Platform Compatibility:**
  - The game is optimized to run on both desktop and android.

### Optimizations

- Game performance is optimized to run smoothly on both CPU and GPU, ensuring a consistent experience across devices.
- No crashes, errors, or warnings are present in the project, ensuring stability.
