using System;
using System.Collections.Generic;
using AppKit;

namespace iTheatre
{
	public class MoviesViewDataSource : NSTableViewDataSource
	{
		private List<Movie> movies;

		public Movie this[int i]
		{
			get
			{
				return movies[i];
			}
		}

		public MoviesViewDataSource(List<Movie> movies)
		{
			this.movies = movies;
		}

		public override nint GetRowCount(NSTableView tableView)
		{
			return movies.Count;
		}
	}
}