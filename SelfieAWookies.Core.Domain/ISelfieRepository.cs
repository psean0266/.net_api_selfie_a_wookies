using SelfieAWookies.Core.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Repositories;


namespace SelfieAWookies.Core.Selfies.Domain
{
    /// <summary>
    /// Repository to manage selfies 
    /// </summary>
    public interface ISelfieRepository : IRepository
    {

        /// <summary>
        /// Gets All selfies
        /// </summary>
        /// <returns></returns>
        ICollection<Selfie> GetAll(int wookieId);
        //   3X
        //
        /// <summary>
        /// Add one selfie
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Selfie AddOne(Selfie item);

        /// <summary>
        /// Create new Picture
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Picture AddOnePicture(string url);

        //Picture AddOnePicture(int selfieI, string url);

    }
}
