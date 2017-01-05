using System;
using AppKit;
using Foundation;

namespace iTheatre
{
	public class MoviesViewDelegate : NSTableViewDelegate
	{
		private const string CellIdentifier = "MovieCell";

		private MoviesViewDataSource dataSource;
		private Action<Movie> action;

		public MoviesViewDelegate(MoviesViewDataSource dataSource, Action<Movie> action)
		{
			this.dataSource = dataSource;
			this.action = action;
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
				view.Editable = false;
			}

			view.StringValue = dataSource.Movies[(int)row].Title;

			return view;
		}

		public override void SelectionDidChange(NSNotification notification)
		{
			action(dataSource.Movies[(int)(notification.Object as NSTableView).SelectedRow]);
		}
	}
}