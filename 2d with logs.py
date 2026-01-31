# 2D scene test with logs
from Angene.Main import painter
import time

from Angene.Main import engine as main

# --- Game Scene for Main Window ---
class GameScene:
    def Start(self):
        self.x = 50
        print("[GameScene] Started")
    
    def Update(self, dt):
        # Move rectangle horizontally
        self.x += 100 * dt
        if self.x > 400:  # wrap around for demo
            self.x = 0
    
    def OnDraw(self, r):
        r.clear(painter.RGB(30, 30, 30))
        r.draw_rect(int(self.x), 100, 200, 100, painter.RGB(200, 50, 50))
        r.draw_text(60, 50, "Main Game Window", painter.RGB(255, 255, 255))

# --- Log Scene for Console/Debug Window ---
class LogScene:
    def Start(self):
        self.logs = []
        self.last_log_time = time.time()
        self.tick_count = 0
        print("[LogScene] Started")
    
    def Update(self, dt):
        # Add a timestamped log every second
        now = time.time()
        if now - self.last_log_time >= 1.0:
            self.tick_count += 1
            # Use simple string
            log_text = f"Tick {self.tick_count}"
            self.logs.append(log_text)
            
            # Keep only last 10 logs
            if len(self.logs) > 10:
                self.logs.pop(0)
            
            self.last_log_time = now
            print(f"[LogScene] {log_text}")
    
    def OnDraw(self, r):
        r.clear(painter.RGB(20, 20, 20))
        r.draw_text(10, 10, "Debug Log", painter.RGB(255, 255, 0))
        
        y = 40
        for log in self.logs:
            r.draw_text(10, y, log, painter.RGB(200, 200, 200))
            y += 20

# Create windows
print("Creating windows...")
game_window = main.Window("Main Game", 500, 400)
log_window = main.Window("Debug Log", 400, 300)
wina = main.Window("a", 300, 400)

# Assign scenes
game_window.set_scene(GameScene())
log_window.set_scene(LogScene())
wina.set_scene(LogScene())

# Run
print("Starting engine...")
main.run(target_fps=60)