using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BetterSpotify.DataAccess.Repository._IRepository;

namespace BetterSpotify.Utilities
{
    public class FileManager
    {
        private static FileManager _instance;
        //private readonly IUnitOfWork _unitOfWork;

        public static FileManager Instance { 
            get
            {
                if(_instance == null)
                {
                    return _instance = new FileManager();
                }
                return _instance;   
            }
        }

        public FileManager()
        {

        }


    }
}
