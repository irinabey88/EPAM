using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interface.Interfaces;

namespace BLL.DataReceiver
{
    /// <summary>
    /// Get list of data from TXT file
    /// </summary>
    public class TxtFileReceiver : IDataReceiver<string>
    {
        private readonly string _fileName;

        /// <summary>
        /// Provides instance of <see cref="TxtFileReceiver"/>
        /// </summary>
        /// <param name="fileName">File name</param>
        public TxtFileReceiver(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            this._fileName = fileName;
        }

        /// <summary>
        /// Get list of data from TXT file
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetData()
        {
            return System.IO.File.ReadAllLines(this._fileName, Encoding.UTF8);
        }
    }
}
