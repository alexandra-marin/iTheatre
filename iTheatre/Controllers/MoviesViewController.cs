using System;
using AppKit;

namespace iTheatre.Views
{
	public partial class MoviesViewController : NSViewController
	{ 		private IMoviesAPI service;
		private AgeCalculator calculator; 
		public MoviesViewController (IntPtr handle) : base (handle)
		{
			service = new MoviesAPI();
			calculator = new AgeCalculator();
		}

		public async override void ViewDidLoad() 		{ 			base.ViewDidLoad();  			var movies = await service.GetNowPlaying();
 			var ds = new MoviesViewDataSource(movies); 			MoviesTable.DataSource = ds; 			MoviesTable.Delegate = new MoviesViewDelegate(ds, UpdateAverageAge); 		}

		private async void UpdateAverageAge(Movie movie)
		{
			AverageAgeLabel.StringValue = "Calculating...";

			if (movie.Cast == null)
			{
				movie.Cast = await service.GetMovieCast(movie.Id);

				foreach (var actor in movie.Cast)
				{
					if (actor.Birthday == default(DateTime))
						actor.Birthday = await service.GetBirthday(actor.Id);
				}
			}

			var averageAge = calculator.ReturnAverageAge(movie.Cast, DateTime.Now);

			AverageAgeLabel.StringValue = averageAge.ToString();
		}
	}
}
