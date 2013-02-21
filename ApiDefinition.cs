using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GrannySmith
{
    [BaseType (typeof (NSObject))]
    interface GSFancyText {     
        [Export ("initWithMarkupText:styleDict:width:maxHeight:")]
        IntPtr Constructor (string text, [NullAllowed] NSMutableDictionary styleDict, float width, float maxHeight);
        
        [Export ("initWithMarkupText:")]
        IntPtr Constructor (string text);
        
        [Export ("initWithParsedStructure:")]
        IntPtr Constructor (GSMarkupNode structure);
        
        [Export ("lambdaBlocks", ArgumentSemantic.Retain)]
        NSMutableDictionary LambdaBlocks { get; set; }
        
        [Export ("style", ArgumentSemantic.Retain)]
        NSMutableDictionary Style { get; set; }
        
        [Export ("text", ArgumentSemantic.Retain)]
        string Text { get; set; }
        
        [Export ("width")]
        float Width { get; set; }
        
        [Export ("maxHeight")]
        float MaxHeight { get; set; }
        
        [Export ("appendStyleSheet:")]
        void AppendStyleSheet (string newStyleSheet);

        [Export ("parseStructure")]
        GSMarkupNode ParseStructure ();
      
        [Export ("parsedResultTree")]
        GSMarkupNode ParsedResultTree ();
        
        [Export ("generateLines")]
        NSMutableArray GenerateLines ();
        
        [Export ("lines")]
        NSMutableArray Lines { get; }
        
        [Export ("pureText")]
        string PureText ();
        
        [Export ("contentHeight")]
        float ContentHeight { get; }
        
        [Export ("contentWidth")]
        float ContentWidth { get; }
        
        [Export ("defineLambdaID:withBlock:")]
        void DefineLambda (string lambdaID, Action<RectangleF> drawingBlock);
        
        [Export ("nodeWithID:")]
        GSMarkupNode NodeWithID (string nodeID);
        
        [Export ("nodesWithClass:")]
        NSArray NodesWithClass (string className);
        
        [Static]
        [Export ("parseStyleAndSetGlobal:")]
        NSMutableDictionary ParseStyleAndSetGlobal (string styleSheet);
        
        [Static]
        [Export ("globalStyle")]
        NSMutableDictionary GlobalStyle ();
        
        [Static]
        [Export ("parsedStyle:")]
        NSMutableDictionary ParsedStyle (string style);
        
        [Static]
        [Export ("newParsedStyle:")]
        NSMutableDictionary NewParsedStyle (string style);
        
        [Static]
        [Export ("parsedMarkupString:withStyleDict:")]
        GSMarkupNode ParsedMarkupString (string markup, NSDictionary styleDict);

        [Static]
        [Export ("newParsedMarkupString:withStyleDict:")]
        GSMarkupNode NewParsedMarkupString (string markup, NSDictionary styleDict);
        
        [Static]
        [Export ("fontWithName:size:weight:style:")]
        UIFont FontWithName (string name, float size, string weight, string style);
        
        [Static]
        [Export ("availableFonts")]
        string AvailableFonts ();
        
        [Static]
        [Export ("createFontKeyForDict:")]
        void CreateFontKeyForDict (NSMutableDictionary dict);
        
        [Export ("drawInRect:")]
        void Draw (RectangleF rect);

        [Export ("changeAttribute:to:on:withName:")]
        void ChangeAttribute (string name, NSObject value, GSFancyTextReferenceType type, [NullAllowed] string referenceName);

        [Export ("addStyles:on:withName:")]
        void AddStyles (NSMutableDictionary styles, GSFancyTextReferenceType type, [NullAllowed] string name);

        [Export ("applyClass:on:withName:")]
        void ApplyClass (string className, GSFancyTextReferenceType type, [NullAllowed] string name);

        [Export ("changeStylesToClass:on:withName:")]
        void ChangeStylesToClass (string className, GSFancyTextReferenceType type, [NullAllowed] string name);

        [Export ("changeNodeToText:forID:")]
        void ChangeNodeToText (string text, string nodeId);

        [Export ("changeNodeToStyledText:forID:")]
        void ChangeNodeToStyledText (string styledText, string nodeId);
        
        [Export ("appendStyledText:toID:")]
        void AppendStyledText (string text, string nodeId);
        
        [Export ("removeID:")]
        void RemoveNode (string nodeId);

        [Static]
        [Export ("addObject:intoDict:underKey:")]
        void AddObject (NSObject o, NSMutableDictionary dict, string key);
        
        [Static]
        [Export ("cleanStyleDict:")]
        void CleanStyleDict (NSMutableDictionary dict);     
    }

    [BaseType (typeof (UIView))]
    interface GSFancyTextView {
        [Export ("initWithFrame:fancyText:")]
        IntPtr Constructor (RectangleF frame, GSFancyText fancyText);
        
        [Export ("fancyText", ArgumentSemantic.Retain), NullAllowed]
        GSFancyText FancyText { get; set;  }
        
        [Export ("contentHeight")]
        float ContentHeight { get;  }
        
        [Export ("matchFrameHeightToContent")]
        bool MatchFrameHeightToContent { get; set;  }
        
        [Export ("matchFrameWidthToContent")]
        bool MatchFrameWidthToContent { get; set;  }
        
        [Export ("updateDisplay")]
        void UpdateDisplay ();
        
        [Export ("setFrameHeightToContentHeight")]
        void SetFrameHeightToContentHeight ();
        
        [Export ("setFrameWidthToContentWidth")]
        void SetFrameWidthToContentWidth ();
        
        [Export ("updateAccessibilityLabel")]
        void UpdateAccessibilityLabel ();
    }

    [BaseType (typeof (NSObject))]
    interface GSMarkupNode {
        [Export ("data", ArgumentSemantic.Retain)]
        NSMutableDictionary Data { get; set;  }
        
        [Export ("children", ArgumentSemantic.Retain)]
        NSMutableArray Children { get; set;  }
        
        [Export ("isContainer")]
        bool IsContainer { get; set;  }
        
        [Export ("IDMap", ArgumentSemantic.Retain)]
        NSMutableDictionary IDMap { get; set;  }
        
        [Export ("classesMap", ArgumentSemantic.Retain)]
        NSMutableDictionary ClassesMap { get; set;  }
        
        [Export ("parent")]
        GSMarkupNode Parent { get; set;  }
        
        [Export ("appendChild:")]
        void AppendChild (GSMarkupNode node);
        
        [Export ("appendSubtree:underNode:")]
        void AppendSubtree (GSMarkupNode subtreeRoot, GSMarkupNode node);
        
        [Export ("newDepthFirstOrderDataArray")]
        NSArray NewDepthFirstOrderDataArray ();
        
        [Export ("childNodeWithID:")]
        GSMarkupNode ChildNode (string nodeID);
        
        [Export ("childrenNodesWithClassName:")]
        NSArray ChildrenNodes (string className);
        
        [Export ("firstChild")]
        GSMarkupNode FirstChild ();
        
        [Export ("cutFromParent")]
        void CutFromParent ();
        
        [Export ("dismissAllChildren")]
        void DismissAllChildren ();
        
        [Export ("resetChildToText:")]
        void ResetChildToText (string text);
        
        [Export ("applyAndSpreadStyles:removeOldStyles:")]
        void ApplyAndSpreadStyles (NSMutableDictionary styles, bool removeOldStyles);
        
        [Export ("displayTree")]
        string DisplayTree ();
    }
}

