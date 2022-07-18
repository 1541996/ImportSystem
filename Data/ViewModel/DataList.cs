﻿using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModel
{
    public class Status
    {
        public string Name { get; set; }
        public string XMLName { get; set; }
        public string Abbr { get; set; }
    }

    public static class FixedData
    {
        public static bool StatusList(string status = null, string extension = null)
        {
            bool check = false;
            List<Status> pmblist = new List<Status> {
                new Status
                {
                   Name = "Approved",
                   XMLName = "Approved"
                },
                new Status
                {
                   Name = "Failed",
                   XMLName = "Rejected"
                },
                new Status
                {
                   Name = "Finished",
                   XMLName = "Done"
                },
                
           };

            if(extension == SettingConfig.CSVExtension)
            {
                check = pmblist.Where(a => a.Name == status).Any();             
            }
            else if(extension == SettingConfig.XMLExtension)
            {
                check = pmblist.Where(a => a.XMLName == status).Any();              
            }

            return check;
        }

        public static string GetStatus(string status = null, string extension = null)
        {
            var unifiedStatus = "";
            List<Status> pmblist = new List<Status> {
                new Status
                {
                   Name = "Approved",
                   XMLName = "Approved",
                   Abbr = "A"
                },
                new Status
                {
                   Name = "Failed",
                   XMLName = "Rejected",
                   Abbr = "R"
                },
                new Status
                {
                   Name = "Finished",
                   XMLName = "Done",
                   Abbr = "D"
                },

           };
            if (extension == SettingConfig.CSVExtension)
            {
                var check = pmblist.Where(a => a.Name == status).FirstOrDefault();
                if (check != null)
                {
                    unifiedStatus = check.Abbr;
                }
            }
            else if (extension == SettingConfig.XMLExtension)
            {
                var check = pmblist.Where(a => a.XMLName == status).FirstOrDefault();
                if (check != null)
                {
                    unifiedStatus = check.Abbr;
                }
            }
           
            return unifiedStatus;
        }
    }

}
