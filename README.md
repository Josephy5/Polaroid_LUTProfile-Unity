![image_016_0001](https://github.com/user-attachments/assets/6b34e86b-e44d-486b-98d8-56b330e6d68c)

# Polaroid LUT Profile
![Unity Version](https://img.shields.io/badge/Unity-2021.3%36LTS%2B-blueviolet?logo=unity)
![Unity Pipeline Support (Built-In)](https://img.shields.io/badge/BiRP_❌-darkgreen?logo=unity)
![Unity Pipeline Support (URP)](https://img.shields.io/badge/URP_✔️-blue?logo=unity)
![Unity Pipeline Support (HDRP)](https://img.shields.io/badge/HDRP_❌-darkred?logo=unity)

A Polaroid LUT profile/Volume Profile and Script for Unity URP (2022.3.20f1) that I made for Serious Point Games as a request that I recieved from
one of my leads. Primarily uses Unity's provided post processing effects, so it could be used outside of the stated unity version and 
URP pipeline (HDRP), but is untested.

## Features
- Polaroid LUT/Camera Filter

## Installation
1. Download Polaroid.asset and load it into an unity project.
2. Create a volume game object and load the volume profile in the volume component (or set your existing volume game object with the Polaroid Volume profile).
3. Enable post processing on your camera.
4. (Optional) Set a layer for the volume game object and camera to only show the polaroid visual on that camera.

## Credits/Assets used
The links below are videos that go over the values in each section like saturation, etc to recreate the look.
But not everything is transferable from lightroom, so the values used in the profile are done in a way to be as close
to what is shown in the video.
[Youtube Video Reference#1](https://www.youtube.com/watch?v=D57G3lxi8gI)
[Youtube Video Reference#2](https://www.youtube.com/watch?v=79KQoiHnRhk)
