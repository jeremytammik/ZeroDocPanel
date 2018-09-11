#region Namespaces
using System;
using System.Collections.Generic;
using System.IO;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace ZeroDocPanel
{
  public class Availability 
    : IExternalCommandAvailability
  {
    public bool IsCommandAvailable(
      UIApplication a, 
      CategorySet b )
    {
      return true;
    }
  }

  [Transaction( TransactionMode.Manual )]
  [Regeneration( RegenerationOption.Manual )]
  class App : IExternalApplication
  {
    public const string Caption = "Zero Doc Panel";
    public const string Caption2 = "Zero Doc Button";

    static string _path 
      = System.Reflection.Assembly
        .GetExecutingAssembly().Location;

    public Result OnStartup( 
      UIControlledApplication a )
    {
      PushButtonData d = new PushButtonData( 
        Caption2, Caption2, _path, 
        "ZeroDocPanel.Command" );

      d.AvailabilityClassName 
        = "ZeroDocPanel.Availability";

      RibbonPanel p = a.CreateRibbonPanel( Caption );

      PushButton b = p.AddItem( d ) as PushButton;

      b.ToolTip 
        = "This is the zero doc panel button tooltip";

      //b.AvailabilityClassName 
      //  = "ZeroDocPanel.Availability";

      return Result.Succeeded;
    }

    public Result OnShutdown( 
      UIControlledApplication a )
    {
      return Result.Succeeded;
    }
  }
}
