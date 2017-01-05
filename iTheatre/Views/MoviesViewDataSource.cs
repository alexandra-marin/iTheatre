using System;
using System.Collections.Generic;
using AppKit;

namespace iTheatre
{
	public class MoviesViewDataSource : NSTableViewDataSource
	{
		public List<Movie> Movies;

		public MoviesViewDataSource(List<Movie> movies)
		{
			Movies = movies;
		}

		public override nint GetRowCount(NSTableView tableView)
		{
			return Movies.Count;
		}
	}
}