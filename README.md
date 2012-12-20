MonoTouch.GSFancyText
=====================

This is a MonoTouch binding for [GSFancyText](https://github.com/hulu/GrannySmith/tree/master/GSFancyText) by Hulu.  
GSFancyText is a rich text drawing library for iOS.

Example
==========

First define the styles using a CSS-like string:

    var stylesheet = ".green {color:#00ff00; font-weight:bold} .gray {color:gray; font-weight:bold}";
    GSFancyText.ParseStyleAndSetGlobal (stylesheet);

Then create a GSFancyText object with a markup string:

    var fancyText = new GSFancyText ("<span class=green>Hulu</span> <span class=gray>Plus</span>");

Then you can directly draw this in a customized view:

    fancyText.drawInRect (rect);

Or create a GSFancyTextView object to display it

    var fancyView = new GSFancyTextView (frame, fancyText);
    
**You can find more examples in [GSFancyTextView documentation](https://github.com/hulu/GrannySmith/wiki/GSFancyText).**
