using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace WPDMS.iOS
{
	public partial class CallHistoryController : UITableViewController
	{
		public List<String> PhoneNumbers { get; set; }
		static NSString callHistoryCellId = new NSString ("CallHistoryCell");

		public CallHistoryController (IntPtr handle) : base (handle)
		{

			TableView.RegisterClassForCellReuse (typeof(UITableViewCell), callHistoryCellId);
			TableView.Source = new CallHistoryDataSource (this);
			PhoneNumbers = new List<string> ();
		}
		class CallHistoryDataSource : UITableViewSource
		{
			CallHistoryController controller;

			public CallHistoryDataSource (CallHistoryController controller)
			{
				this.controller = controller;
			}

			// Returns the number of rows in each section of the table
			public override nint RowsInSection (UITableView tableView, nint section) //changed from whats documented "int" to "nint" as this is unified template
			{
				return controller.PhoneNumbers.Count;
			}
			//
			// Returns a table cell for the row indicated by row property of the NSIndexPath
			// This method is called multiple times to populate each row of the table.
			// The method automatically uses cells that have scrolled off the screen or creates new ones as necessary.
			//
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (CallHistoryController.callHistoryCellId);

				int row = indexPath.Row;
				cell.TextLabel.Text = controller.PhoneNumbers [row];
				return cell;
			}
		}
	}
}
