namespace Inanna.LibraryContext.Application.Features;

public interface IProjectionsRepository<TProjection> where TProjection : IProjection
{
    /// <summary>
    ///     Method to start querying the database
    /// </summary>
    /// <returns>Non tracking collection of projection for querying</returns>
    public Task<IQueryable<TProjection>> Query();

    /// <summary>
    ///     Creates a new projection instance in the database
    /// </summary>
    /// <param name="projection">A projection to create</param>
    public Task Create(TProjection projection);

    /// <summary>
    ///     Updates an existing projection instance in the database by projection id. Projection should exist in the database
    /// </summary>
    /// <param name="projection">A projection to update</param>
    public Task Update(TProjection projection);

    /// <summary>
    ///     Reads an existing projection and returns it as non tracking
    /// </summary>
    /// <param name="projectionId">The id of a projection to read</param>
    /// <returns>A non tracking projection instance</returns>
    public Task<TProjection> Read(object projectionId);

    /// <summary>
    ///     Deletes an existing projection by id
    /// </summary>
    /// <param name="projectionId">The id of a projection to delete</param>
    public Task Delete(object projectionId);
}