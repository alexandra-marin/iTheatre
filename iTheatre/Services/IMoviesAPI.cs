using System.Threading.Tasks;

namespace iTheatre
{
	public interface IMoviesAPI
	{
		Task<Movie> GetMovie(string query);
		Task<Movie> GetMovieCast(string query);
	}
}