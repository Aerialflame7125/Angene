"""
Hello! This is an example scene for this game engine, Angene.
Firstly, Angene is a python module. Whenever you want to work with it, import the main engine module:

```python
from Angene.Main import engine
```

This gives you access to core engine features, including creating windows, handling scenes, and more.
You can then create windows and assign scenes to them. A scene is a class that defines the behavior of what happens in that window, including starting logic, updating per frame, and drawing, like so:

```python
class MyScene:
    def Start(self):
        # Initialization logic here
        pass
    
    def Update(self, dt):
        # Update logic here
        pass
    
    def OnDraw(self, r):
        # Drawing logic here
        r.clear(painter.RGB(0, 0, 0))
        r.draw_text(10, 10, "Hello, Angene!", painter.RGB(255, 255, 255))
```

Angene is a lot like Unity in terms of function calls, here are some key functions that act like their Unity counterparts:
- 'Start()' is called upon scene initialization (or script initialization).
- 'Update(dt)' is called every frame, with 'dt' being the delta time since the last frame.
- 'LateUpdate(dt)' is called every frame after 'Update(dt)'.
- 'OnDraw(r)' is called to render the scene, where 'r' is the renderer object.
- 'OnApplicationQuit()' is called when the application is about to close.

Of course there are others, this is just the tip of the iceberg.
You can create multiple windows, each with their own scene and the ability to change scenes at runtime:
```python
window1 = engine.Window("My Game", 800, 600)
window1.set_scene(MyScene())

window2 = engine.Window("Debug Log", 400, 300)
window2.set_scene(LogScene())
```

There is another function call you can get use to the fullest extent for any physical call that happens in the window. You can use 'OnMessage(hwnd, msg, wParam, lParam)' to capture any window messages. This is called in your scene per message recieved from the engine, allowing you to handle low-level window events directly:
```python
from Angene.Main import engine, definitions

def OnMessage(self, hwnd, msg, wParam, lParam):
    if msg == definitions.WM_SETFOCUS:
        print("Window focused!")
        # And do other things i guess.
        pass
```

When you are ready to run the engine, it takes 4 lines of code for initialization: (I promise they aren't long)
```python
engine.init()
window = engine.Window("My new radical and swagtastic game!", 800, 600)
window.set_scene(MyScene())
engine.run()
```

Due to the nature of Angene being a python game engine, there are freedoms and flexibilities that you can take advantage of, but also some drawbacks.
For example, you could use pygame for audio handling or other libraries for physics and networking, but Angene itself holds 2 threads for processes:
- The main thread, which handles window management, rendering, and scene updates.
- The secondary thread, which is used for script management and background tasks.
This means that any blocking operations in your scene's code can freeze the engine, so be cautious with long-running tasks.

Welp, here is an example scene that demonstrates these features, happy coding!
(And thank you for listening to my ted talk)
"""

from Angene.Main import engine, painter
import time

class Scene:
    def Start(self):
        self.x = -100
        print("[ExampleScene] Started")
        exampleCall()

    def Update(self, dt):
        self.x += 150 * dt
        if self.x > 500:
            self.x = -100

    def OnDraw(self, r):
        r.clear(painter.RGB(50, 50, 100))
        r.draw_rect(int(self.x), 150, 100, 100, painter.RGB(100, 200, 100))
        r.draw_text(20, 20, "Example Scene", painter.RGB(255, 255, 255))

def exampleCall():
    print("[ExampleScene.exampleCall] Woah I'm running asyncronously!")

engine.init()
window = engine.Window("Angene Example Scene", 600, 400)
window.set_scene(Scene())
engine.run()
