using System;
using AppKit;

namespace iTheatre
{
	public class MoviesViewDelegate : NSTableViewDelegate
	{
		private const string CellIdentifier = "MovieCell";

		private MoviesViewDataSource DataSource;

		public MoviesViewDelegate(MoviesViewDataSource datasource)
		{
			this.DataSource = datasource;
		}

		public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
		{
			NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);
			if (view == null)
			{
				view = new NSTextField();
				view.Identifier = CellIdentifier;
				view.BackgroundColor = NSColor.Clear;
				view.Bordered = false;
				view.Selectable = false;
				view.Editable = false;
			}

			view.StringValue = DataSource.Movies[(int)row].Title;

			return view;
		}
	}
}