using ISSTest.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSTest.Core.Repository
{
    public class Repository : IRepository
    {
        private const string JSONPATH = @"C:\temp\iss\";
        private const string JSONFILE = @"IssData.json";

        public Repository()
        {
            if (!Directory.Exists(JSONPATH))
                Directory.CreateDirectory(JSONPATH);
        }

        /// Check if json file exist.
        /// </summary>
        /// <returns></returns>
        public bool CheckIfJsonFilesExist()
        {
            return File.Exists(JSONPATH + JSONFILE);
        }

        /// <summary>
        /// Get all issModels from json file
        /// </summary>
        /// <returns></returns>
        private List<IssModel> GetAllIssModelsFromJsonFile()
        {
            List<IssModel> issList = new List<IssModel>();
            bool fileExist = CheckIfJsonFilesExist();
            if (fileExist)
            {
                string json = File.ReadAllText(JSONPATH + JSONFILE);
                issList = JsonConvert.DeserializeObject<List<IssModel>>(json);
            }
           
            return issList;

        }

        public List<IssModel> SaveIss(IssModel issModel)
        {
            List<IssModel> issList = null;
            try
            {
                issList = GetAllIssModelsFromJsonFile();
                issList.Add(issModel);
                using (StreamWriter file = File.CreateText(JSONPATH + JSONFILE))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, issList);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
           
            return issList;
        }

        public List<IssModel> GetAll()
        {
            return GetAllIssModelsFromJsonFile();
        }
    }
}
