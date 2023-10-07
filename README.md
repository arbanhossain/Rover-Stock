# Perseverance Re-Imagined

## Short Description:
Web based virtual reality experiences that encapsulate entire missions are rare. Our goal is to fill that void and provide an immersive experience of the entire journey of the Perseverance rover. Through our solution “Perseverance Re-imagined”, we aim to create an educational and engaging experience for high school and middle school students teaching them about the orbital maneuvers from earth to mars, Perseverance mission, Mars geology, and the rover’s scientific experiments. 

## Long Description:
Perseverance, nicknamed Percy, is a car -sized Mars rover designed to explore the Jezero crater on Mars as part of NASA's Mars 2020 mission to explore Mars further. To visualize the entire mission, we developed an immersive and educational web-based virtual reality (VR) game that combines step by step experiences of visualizing the orbital trajectory of spacecraft from Earth to Mars, operating NASA's Perseverance rover, exploring Mars alongside Perseverance and Ingenuity.
<br>
### Museum
Our adventure begins in an interactive museum containing Perseverance and relevant attractions. A voice assistant will guide the player throughout the entire tour, sparking curiosity about the mission and the perseverance rover. The museum also exhibits potential landing sites that were initially chosen such as Jezero Crater, NE Syrtis, and Columbia Hills. Once the user exits the museum, users can experience the orbital maneuver with user selected time lapse.

### Hohmann Transfer:
During the orbital trajectory section, the orbital hohmann transfer for the perseverance rover is generated using GMAT, and the relevant Trajectory Correction Maneuvers (TCMs) are described for the user. The user can play around with the orbit, reverse and zoom in to observe the spacecraft and interact with the scene as they please. We meticulously recreated the cruise spacecraft of the Mars 2020 mission using Blender, keeping accuracy with available pictures of the spacecraft that contained the rover payload.

### Mars Exploration
Now, we shift our focus to the martian surface. The spacecraft has successfully landed, and the scene transitions to the dusty, rust-colored landscape of Mars. Its wheels churning up the Martian soil, it begins its scientific mission, drilling into rocks, and exploring the terrain. Meanwhile, above the Martian surface, the tiny Ingenuity helicopter takes to the skies, demonstrating powered flight on another planet for the first time and capturing breathtaking aerial views. 

On the Martian surface, the player is provided with 
  1. The stunning visual of the Ingenuity helicopter’s maiden flight, humanity’s first successful flight on an extraterrestrial planet. 
  2. The player is then guided by the voice assistant to collect rock samples to be broadcasted back to Earth. 
  3. The experience ends with a faithful recreation of a solar eclipse due to Mars's moon Phobos.
In all of these interactive sessions, the players are fed accurate information fetched from open source repositories of NASA. Moreover, we also show a live weather report on NASA  using Mars weather API on our project website, which is an interesting way for youth to appreciate natural cycles in other worlds.

### Terrain Creation
We recreated the landing site using Blender and height maps from NASA’s Mars Hi-RISE Trek to give a faithful recreation of the Jezero crater. Moreover we created the spacecraft of the Mars 2020 mission that carried the Perseverance rover and Ingenuity helicopter through the martian atmosphere and performed the orbital trajectory maneuvers required for the Hohmann transfer.

### WebVR Implementation
We used a unity package named WebXR Exporter and Unity WebXR Plugin to deploy the VR experience to our website. The player control is given by using WebXRCameraSet, to enable seamless webXR implementation with all VR platforms. The input for all movement controls were transferred to WebGL using our own scripts, and implemented AssemblyDefinitions to utilize unofficial unity packages to enable OpenXR Namespace. 

