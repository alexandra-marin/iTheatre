using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTheatre
{
	public interface IMoviesAPI
	{
		Task<Movie> GetMovie(string query);
		Task<List<Actor>> GetMovieCast(string query);
	}
}