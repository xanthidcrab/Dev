using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewDeneme.Services.Interfaces
{
    /// <summary>
    /// Provides methods for saving and loading objects to and from XML files.
    /// </summary>
    public interface IXmlService
    {
        /// <summary>
        /// Serializes the specified data object to an XML file at the given file path.
        /// </summary>
        /// <typeparam name="T">The type of the data object to serialize.</typeparam>
        /// <param name="filePath">The file path where the XML will be saved.</param>
        /// <param name="data">The data object to serialize and save.</param>
        void SaveXml<T>(string filePath, T data);

        /// <summary>
        /// Deserializes an object of type <typeparamref name="T"/> from the specified XML file.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize. Must be a class.</typeparam>
        /// <param name="filePath">The file path of the XML file to load.</param>
        /// <returns>The deserialized object, or null if deserialization fails.</returns>
        T LoadXml<T>(string filePath) where T : class;
    }
}
