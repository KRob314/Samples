using CinemaGames.Data.Infrastructure;
using CinemaGames.Data.Repositories;
using CinemaGames.Entities;
using CinemaGames.Web.Infrastructure.Core;
using CinemaGames.Web.Models;
using CinemaGames.Web.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;
using AutoMapper;

namespace CinemaGames.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/moviesubmission")]
    public class MovieSubmissionController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<MovieSubmission> _movieSubmissionRepo;

        public MovieSubmissionController(IEntityBaseRepository<MovieSubmission> movieSubmissionRepo, IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork) 
            :base(_errorsRepository, _unitOfWork)
        {
            _movieSubmissionRepo = movieSubmissionRepo;
        }

        //[AllowAnonymous]
        //[Route("latest")]
        //public HttpResponseMessage Get(HttpRequestMessage request)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        var movies = _movieSubmissionRepo.GetAll().OrderByDescending(m => m.ReleaseDate).Take(6).ToList();

        //        IEnumerable<MovieViewModel> moviesVM = Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(movies);

        //        response = request.CreateResponse<IEnumerable<MovieViewModel>>(HttpStatusCode.OK, moviesVM);

        //        return response;
        //    });
        //}

        [Route("details/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var movieSubmission = _movieSubmissionRepo.GetSingle(id);

                MovieSubmissionViewModel movieVM = Mapper.Map<MovieSubmission, MovieSubmissionViewModel>(movieSubmission);

                response = request.CreateResponse<MovieSubmissionViewModel>(HttpStatusCode.OK, movieVM);

                return response;
            });
        }

        //[AllowAnonymous]
        //[Route("{page:int=0}/{pageSize=3}/{filter?}")]
        //public HttpResponseMessage Get(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        //{
        //    int currentPage = page.Value;
        //    int currentPageSize = pageSize.Value;

        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        List<Movie> movies = null;
        //        int totalMovies = new int();

        //        if (!string.IsNullOrEmpty(filter))
        //        {
        //            movies = _movieSubmissionRepo
        //                .FindBy(m => m.Title.ToLower()
        //                .Contains(filter.ToLower().Trim()))
        //                .OrderBy(m => m.ID)
        //                .Skip(currentPage * currentPageSize)
        //                .Take(currentPageSize)
        //                .ToList();

        //            totalMovies = _movieSubmissionRepo
        //                .FindBy(m => m.Title.ToLower()
        //                .Contains(filter.ToLower().Trim()))
        //                .Count();
        //        }
        //        else
        //        {
        //            movies = _movieSubmissionRepo
        //                .GetAll()
        //                .OrderBy(m => m.ID)
        //                .Skip(currentPage * currentPageSize)
        //                .Take(currentPageSize)
        //                .ToList();

        //            totalMovies = _movieSubmissionRepo.GetAll().Count();
        //        }

        //        IEnumerable<MovieViewModel> moviesVM = Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(movies);

        //        PaginationSet<MovieViewModel> pagedSet = new PaginationSet<MovieViewModel>()
        //        {
        //            Page = currentPage,
        //            TotalCount = totalMovies,
        //            TotalPages = (int)Math.Ceiling((decimal)totalMovies / currentPageSize),
        //            Items = moviesVM
        //        };

        //        response = request.CreateResponse<PaginationSet<MovieViewModel>>(HttpStatusCode.OK, pagedSet);

        //        return response;
        //    });
        //}

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, MovieSubmissionViewModel viewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    MovieSubmission newMovieSubmission = new MovieSubmission();
                    newMovieSubmission.UpdateMovieSubmission(viewModel);

                    _movieSubmissionRepo.Add(newMovieSubmission);
                    _unitOfWork.Commit();

                    // Update view model
                    viewModel = Mapper.Map<MovieSubmission, MovieSubmissionViewModel>(newMovieSubmission);
                    response = request.CreateResponse<MovieSubmissionViewModel>(HttpStatusCode.Created, viewModel);
                }

                return response;
            });
        }

        //[HttpPost]
        //[Route("update")]
        //public HttpResponseMessage Update(HttpRequestMessage request, MovieViewModel movie)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;

        //        if (!ModelState.IsValid)
        //        {
        //            response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var movieDb = _movieSubmissionRepo.GetSingle(movie.ID);
        //            if (movieDb == null)
        //                response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid movie.");
        //            else
        //            {
        //                movieDb.UpdateMovie(movie);
        //                movie.Image = movieDb.Image;
        //                _movieSubmissionRepo.Edit(movieDb);

        //                _unitOfWork.Commit();
        //                response = request.CreateResponse<MovieViewModel>(HttpStatusCode.OK, movie);
        //            }
        //        }

        //        return response;
        //    });
        //}

        //[MimeMultipart]
        //[Route("images/upload")]
        //public async Task<HttpResponseMessage> PostAsync(HttpRequestMessage request, int movieId)
        //{
        //    HttpResponseMessage response = null;

        //    var movieOld = _movieSubmissionRepo.GetSingle(movieId);
        //    if (movieOld == null)
        //        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid movie.");
        //    else
        //    {
        //        var uploadPath = HttpContext.Current.Server.MapPath("~/Content/images/movies");

        //        var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);

        //        // Read the MIME multipart asynchronously 
        //        await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

        //        string _localFileName = multipartFormDataStreamProvider
        //            .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();

        //        // Create response
        //        FileUploadResult fileUploadResult = new FileUploadResult
        //        {
        //            LocalFilePath = _localFileName,

        //            FileName = Path.GetFileName(_localFileName),

        //            FileLength = new FileInfo(_localFileName).Length
        //        };

        //        // update database
        //        movieOld.Image = fileUploadResult.FileName;
        //        _movieSubmissionRepo.Edit(movieOld);
        //        _unitOfWork.Commit();

        //        response = request.CreateResponse(HttpStatusCode.OK, fileUploadResult);
        //    }

        //    return response;
        //}
    }
}