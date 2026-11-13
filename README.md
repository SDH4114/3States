# 3States

A 2D puzzle-platformer about a drop of water that ends up in a cave.

## About

You play as a drop of water. To get through the cave, it can switch between three states:

- **Water** – the default state.
- **Gas** – moves freely in all directions.
- **Ice** – can break ice walls.

Switch between the states, solve each level and find the way out. Levels also have keys, doors and a timer to deal with.

This is an old project, kept here as is.

## Download

Ready-to-play builds for Windows and macOS are on the [Releases](../../releases) page.

## Controls

| Key | Action |
| --- | --- |
| 1 / 2 / 3 | Change state |
| R | Restart |
| Esc | Close the game |

**Water:** `A` `D` move left/right, `Space` moves up, `E` water down.
**Gas:** `W` `A` `S` `D` move up/left/down/right.
**Ice:** `A` `D` move left/right, breaks ice walls.

**Keys and doors:**
- Green key opens the green door.
- Red key starts the timer; if it runs out, the red door closes.

## Build from source

Requires Unity **2022.3.55f1**. Open the repository folder in Unity Hub and let it import the project.

Large assets (images, audio, models) are stored with [Git LFS](https://git-lfs.com), so install it before cloning:

```bash
git lfs install
git clone https://github.com/SDH4114/3States.git
```

## Project structure

- `Assets/` – scenes, scripts, sprites, audio
- `Packages/`, `ProjectSettings/` – Unity package manifest and project settings
