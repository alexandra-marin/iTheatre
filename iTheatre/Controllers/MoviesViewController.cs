using System;
using AppKit;

namespace iTheatre.Views
{
	public partial class MoviesViewController : NSViewController
	{ 		private IMoviesAPI service;
		private AgeCalculator calculator; 		private MoviesViewDataSource ds;
		private MoviesViewDelegate del;

		public MoviesViewController (IntPtr handle) : base (handle)
		{
			service = new MoviesAPI();
			calculator = new AgeCalculator();
		}

		public async override void ViewDidLoad() 		{ 			base.ViewDidLoad();  			var movies = await service.GetNowPlaying();
 			ds = new MoviesViewDataSource(movies);
			del = new MoviesViewDelegate(ds, UpdateAverageAge); 		
			MoviesTable.DataSource = ds; 			MoviesTable.Delegate = del; 		}

		private async void UpdateAverageAge(Movie movie)
		{
			del.BlockSelection();
			AverageAgeLabel.StringValue = "Calculating...";

			if (movie.Cast == null)
			{
				movie.Cast = await service.GetMovieCast(movie.Id);

				foreach (var actor in movie.Cast)
				{
					actor.Birthday = await service.GetBirthday(actor.Id);
				}
			}

			var averageAge = calculator.ReturnAverageAge(movie.Cast, DateTime.Now);
			AverageAgeLabel.StringValue = averageAge.ToString();
			del.UnblockSelection();
		}
	}
}
