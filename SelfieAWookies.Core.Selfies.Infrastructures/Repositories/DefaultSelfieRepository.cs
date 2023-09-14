using Microsoft.EntityFrameworkCore;
using SelfieAWookies.Core.Domain;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;
using SelfiesAWookies.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace SelfieAWookies.Core.Selfies.Infrastructures.Repositories
{
    public class DefaultSelfieRepository : ISelfieRepository
    {
        #region fields
        private readonly SelfiesContext _context= null ;
        #endregion

        #region Constructor
        public DefaultSelfieRepository(SelfiesContext context)
        {
            this._context = context ;
        }

      
        #endregion

        #region public methods
        public ICollection<Selfie> GetAll(int wookieId)
        {
            //return this._context.Selfies.Include(item => item.Wookie).ToList();
            var query = this._context.Selfies.Include(item => item.Wookie).AsQueryable();

            if (wookieId > 0)
            {
                query = query.Where(item => item.WookieId == wookieId);
            }
             
            return query.ToList();
        }   
        #endregion

        #region properties
        public IUnitOfWork IUnitOfWork => this._context;
        #endregion

        public Selfie AddOne(Selfie item)
        {
            return this._context.Selfies.Add(item).Entity;
        }

        public Picture AddOnePicture(string url)
        {
            return this._context.Pictures.Add(new Picture()
            {
                Url = url,
            }).Entity;
        }
    }
}
