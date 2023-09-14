using SelfiesAWookies.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Selfies.Infrastructures.Repositories
{
    /// <summary>
    /// Use it to define class is a repository
    /// </summary>
    public interface IRepository
    {
      IUnitOfWork IUnitOfWork { get; }
    }
}
