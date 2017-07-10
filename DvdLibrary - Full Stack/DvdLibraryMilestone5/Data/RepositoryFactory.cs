using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DvdLibraryMilestone5.Data.Repositories;
using DvdLibraryMilestone5.Models;

namespace DvdLibraryMilestone5.Data
{
    public class RepositoryFactory
    {
        public static IDvdRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new DVDRepositoryADO();

                case "EntityFramework":
                    return new DvdRepositoryEF();

                case "SampleData":
                    return new DvdRepositoryMock();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}