using System;

namespace Angene.Essentials
{
    /// <summary>
    /// ScreenPlay interface - marker interface for ScreenPlay scripts.
    /// Use the partial interfaces below to opt into specific lifecycle phases.
    /// </summary>
    public interface IScreenPlay
    {
        void Start() { }
        void Cleanup() { }
        void Render() { }
        void Update(double dt) { }
        void LateUpdate(double dt) { }
        void OnMessage(IntPtr msgPtr) { }
        void OnDraw() { }
    }
}