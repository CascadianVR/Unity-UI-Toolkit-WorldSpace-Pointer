# Unity World Space UI Toolkit Pointer
![Unity](https://img.shields.io/badge/Unity-6000.3%2B-black)
![License](https://img.shields.io/github/license/CascadianVR/Unity-WorldSpaceUIPointer)

A lightweight custom raycaster for interacting with Unity UI Toolkit
UIDocuments in world space.

Unlike Unity's default UI input handling, this allows you to send pointer
events to world-space UI panels using:

- Mouse raycasts
- VR controller pointers
- Custom input systems
- Physics-based pointers

Built for Unity 6+ and the new UI Toolkit runtime workflow.

## Features

✅ UI Toolkit world-space interaction  
✅ Works with UIDocument  
✅ Compatible with Unity Input System  
✅ No Canvas required  
✅ Works with VR and non-VR projects (just need to change from mouse input)

## **Setup**
1. Add the WorldSpaceUIPointer.cs script to your Unity project
2. Make sure your world space UIDocuments are setup as follows:
3. Each document needs it's own "Panel Settings" asset. If they share, the input will only work on one panel for some reason.
3. Panel Settings Render Mode must be set to "World Space"
4. Panel Settings Collider Update Mode generally should be left at "Match 3-D bounding box"
<br/><br/>

## **Contact**
Website: [https://cascadian.coffee/](https://cascadian.coffee/)
<br/>
Discord: cascadian
