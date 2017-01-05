using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppKit;

namespace iTheatre.Views
{
	public partial class MoviesViewController : NSViewController
	{ 		private IMoviesAPI service; 		private List<Movie> movies;

		public MoviesViewController (IntPtr handle) : base (handle)
		{
		}

		public async override void ViewDidLoad() 		{ 			base.ViewDidLoad();  			service = new MoviesAPI();  			await BuildMovies();  			var ds = new MoviesViewDataSource(movies); 			MoviesTable.DataSource = ds; 			MoviesTable.Delegate = new MoviesViewDelegate(ds); 		}  		private async Task BuildMovies() 		{ 			movies = await service.GetNowPlaying(); 		}
	}
}
