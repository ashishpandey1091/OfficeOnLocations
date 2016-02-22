using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace DataAshishPandey.Models
{
    public class Office
    {
      
        [ScaffoldColumn(false)]
        public int officeID { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string companyName { get; set; }
       
        [Display(Name = "Contact")]
        public int contact { get; set; }

        [Display(Name = "emailID")]
        public string emailID { get; set; }
        
        [Display(Name = "Number of Employees")]
        public int numberOfEmployees { get; set; }

        [Display(Name = "Departments")]
        public string departments { get; set; }

        [Display(Name = "Branch Name")]
        public string branchName { get; set; }

        [ScaffoldColumn(true)]
        public int? LocationID { get; set; }

        public virtual Location Location { get; set; }
        public List<Location> officeSets { get; set; }

        public static List<Office> ReadAllFromCSV(string filepath)
        {
            List<Office> lst = File.ReadAllLines(filepath)
                                        .Skip(1)
                                        .Select(v => Office.OneFromCsv(v))
                                        .ToList();
            return lst;
        }

        public static Office OneFromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Office item = new Office();

            int i = 0;
            item.branchName = Convert.ToString(values[i++]);
            item.LocationID = Convert.ToInt32(values[i++]);
            item.companyName = Convert.ToString(values[i++]);
            item.emailID = Convert.ToString(values[i++]);
            item.contact = Convert.ToInt32(values[i++]);
            item.departments = Convert.ToString(values[i++]);      
            item.numberOfEmployees = Convert.ToInt32(values[i++]);

            return item;
        }

    }

}