// *******************************************************************************
//  Title:			EventHandlers.cs
//  Description:	EventHandlers for MediaRenamer
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using MediaRenamer.Movies;
using MediaRenamer.Series;

namespace MediaRenamer.Common
{
    public delegate void ScanProgressHandler(int pos, int max);
    public delegate void ListMovieHandler(Movie m);
    public delegate void ListEpisodeHandler(Episode ep);
}