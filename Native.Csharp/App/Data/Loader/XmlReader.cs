using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Native.Csharp.App.Data.Loader
{
    public class XmlReader
    {
        protected DataSet GetData(params string[] tables)
        {
            return null;
        }
        public DataSet[] LoadAll()
        {
            List<DataSet> dataSets = new List<DataSet>();
            try
            {
                DirectoryInfo dataFolder = new DirectoryInfo(Common.AppDirectory);

                foreach (FileInfo file in dataFolder.GetFiles("*.xml"))
                {
                    dataSets.Add(Load(file));
                }
            } catch(ArgumentNullException)
            {

            }
            return dataSets.ToArray();
        }

        /// <summary>
        /// 从文件中读取出DataSet
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private DataSet Load(FileInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException("file");
            }

            

            try
            {
                DataSet result = new DataSet();
                StreamReader reader = new StreamReader(file.FullName, Encoding.UTF8);
                result.ReadXml(reader);
                reader.Close();

                return result;
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            catch (DirectoryNotFoundException)
            {
                return null;
            }
        }
    }
}
