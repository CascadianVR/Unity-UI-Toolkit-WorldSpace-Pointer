# Unity-WorldSpaceUIPointer
**An example of a simple world space UI pointer for Unity Engine, meant to be used with the newer UI Toolkit framework.
**I was suprised when I found that there is very little to no resources on how to do this online. There's lots of ways to do this but it's not well documented and there are some very specific settings you need on your UIToolkit documents to get these all working properly.

## Setup
1. Add the WorldSpaceUIPointer.cs script to your Unity project
2. Make sure your world space UIDocuments are setup as follows:
3. Each document needs it's own "Panel Settings" asset. If they share, the input will only work on one panel for some reason.
3. Panel Settings Render Mode must be set to "World Space"
4. Panel Settings Collider Update Mode generally should be left at "Match 3-D bounding box"
<br/><br/>

### Contact
Website: [https://cascadian.coffee/](https://cascadian.coffee/)
<br/>
Discord: cascadian
