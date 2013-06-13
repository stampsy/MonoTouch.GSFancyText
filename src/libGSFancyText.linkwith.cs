using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libGSFancyText.a", LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true)]
