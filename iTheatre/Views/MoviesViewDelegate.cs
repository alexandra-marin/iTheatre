using System;
using AppKit;
using Foundation;

namespace iTheatre
{
	public class MoviesViewDelegate : NSTableViewDelegate
	{
		private const string cellIdentifier = "MovieCell";

		private MoviesViewDataSource dataSource;
		private Action<Movie> action;
		private bool working;

		public MoviesViewDelegate(MoviesViewDataSource dataSource, Action<Movie> action)
		{
			this.dataSource = dataSource;
			this.action = action;
		}

		public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
		{
			NSTextField view = (NSTextField)tableView.MakeView(cellIdentifier, this);
			if (view == null)
			{
				view = new NSTextField()
				{
					Identifier = cellIdentifier,
					BackgroundColor = NSColor.Clear,
					Bordered = false,
					Editable = false,
				};
			}

			var movie = dataSource.Movies[(int)row];
			view.StringValue = movie.Title;

			return view;
		}

		public override void SelectionDidChange(NSNotification notification)
		{
			var index = (int)(notification.Object as NSTableView).SelectedRow;
			var movie = dataSource.Movies[index];

			action(movie);
		}

		public override bool ShouldSelectRow(NSTableView tableView, nint row)
		{
			return !working;
		}

		public void BlockSelection()
		{
			working = true;
		}

		public void UnblockSelection()
		{
			working = false;
		}
	}
}