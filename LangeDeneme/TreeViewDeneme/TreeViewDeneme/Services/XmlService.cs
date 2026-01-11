using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TreeViewDeneme.Services.Interfaces;

namespace TreeViewDeneme.Services
{
    
    ///<summary>
    /// Provides XML serialization and deserialization services for generic types.
    /// Supports saving and loading objects, including collections and nested classes, to and from XML files.
    /// </summary>
    public class XmlService : IXmlService
    {
        /// <summary>
        /// Loads an object of type <typeparamref name="T"/> from the specified XML file.
        /// Handles collections, nested classes, and simple properties.
        /// </summary>
        /// <typeparam name="T">The type of object to load. Must be a class with a parameterless constructor.</typeparam>
        /// <param name="filePath">The path to the XML file.</param>
        /// <returns>An instance of <typeparamref name="T"/> populated with data from the XML file.</returns>
        /// <exception cref="Exception">Thrown if the XML file cannot be read or contains no data.</exception>
        public T LoadXml<T>(string filePath) where T : class
        {
            Type type = typeof(T);

            DataSet dataSet = new DataSet();
            try
            {
                dataSet.ReadXml(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading XML file: {ex.Message}", ex);
            }
            if (dataSet.Tables.Count == 0)
            {
                throw new Exception("No data found in the XML file.");
            }
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var properies = type.GetProperties();
            // Create an instance of T
            T instance = Activator.CreateInstance<T>();

            foreach (var item in properies)
            {
                var table = dataSet.Tables.Cast<DataTable>()
                    .FirstOrDefault(t => t.TableName.Equals(item.Name, StringComparison.OrdinalIgnoreCase));

                if (table != null)
                {
                    // If property is a collection, assign list of child objects
                    if (item.PropertyType.IsGenericType &&
                        typeof(System.Collections.IEnumerable).IsAssignableFrom(item.PropertyType) &&
                        item.PropertyType.GetGenericArguments().Length == 1)
                    {
                        var elementType = item.PropertyType.GetGenericArguments()[0];
                        var listType = typeof(List<>).MakeGenericType(elementType);
                        // Replace this line:
                        //var list = (System.Collections.IList)Activator.CreateInstance(listType);

                        // With this for ObservableCollection support:
                        var observableCollectionType = typeof(System.Collections.ObjectModel.ObservableCollection<>).MakeGenericType(elementType);
                        var list = (System.Collections.IList)Activator.CreateInstance(observableCollectionType);

                        foreach (DataRow row in table.Rows)
                        {
                            var child = Activator.CreateInstance(elementType);
                            foreach (var prop in elementType.GetProperties())
                            {
                                if (table.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                                {
                                    prop.SetValue(child, Convert.ChangeType(row[prop.Name], prop.PropertyType));
                                }
                            }
                            list.Add(child);
                        }
                        item.SetValue(instance, list);
                    }
                    // If property is a class, assign first row as object
                    else if (item.PropertyType.IsClass && item.PropertyType != typeof(string))
                    {
                        if (table.Rows.Count > 0)
                        {
                            var child = Activator.CreateInstance(item.PropertyType);
                            foreach (var prop in item.PropertyType.GetProperties())
                            {
                                if (table.Columns.Contains(prop.Name) && table.Rows[0][prop.Name] != DBNull.Value)
                                {
                                    prop.SetValue(child, Convert.ChangeType(table.Rows[0][prop.Name], prop.PropertyType));
                                }
                            }
                            item.SetValue(instance, child);
                        }
                    }
                    // Otherwise, assign value directly
                    else if (table.Rows.Count > 0 && table.Columns.Contains(item.Name) && table.Rows[0][item.Name] != DBNull.Value)
                    {
                        item.SetValue(instance, Convert.ChangeType(table.Rows[0][item.Name], item.PropertyType));
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Saves the specified object of type <typeparamref name="T"/> to an XML file.
        /// Handles collections, nested classes, and simple properties.
        /// </summary>
        /// <typeparam name="T">The type of the object to save.</typeparam>
        /// <param name="filePath">The path to the XML file to write.</param>
        /// <param name="data">The object to serialize to XML.</param>
        /// <exception cref="Exception">Thrown if the XML file cannot be written.</exception>
        public void SaveXml<T>(string filePath, T data)
        {
            Type type = typeof(T);
            DataSet dataSet = new DataSet();

            var properties = type.GetProperties();

            foreach (var item in properties)
            {
                var propType = item.PropertyType;

                // Handle collections (ObservableCollection, List, etc.)
                if (propType.IsGenericType &&
                    typeof(System.Collections.IEnumerable).IsAssignableFrom(propType) &&
                    propType.GetGenericArguments().Length == 1 &&
                    propType != typeof(string))
                {
                    var elementType = propType.GetGenericArguments()[0];
                    var table = new DataTable(item.Name);

                    // Add columns for each property of the element type
                    foreach (var prop in elementType.GetProperties())
                    {
                        table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    }

                    var collection = item.GetValue(data) as System.Collections.IEnumerable;
                    if (collection != null)
                    {
                        foreach (var element in collection)
                        {
                            var row = table.NewRow();
                            foreach (var prop in elementType.GetProperties())
                            {
                                var value = prop.GetValue(element);
                                row[prop.Name] = value ?? DBNull.Value;
                            }
                            table.Rows.Add(row);
                        }
                    }
                    dataSet.Tables.Add(table);
                }
                // Handle class properties (not string)
                else if (propType.IsClass && propType != typeof(string))
                {
                    var table = new DataTable(item.Name);
                    foreach (var prop in propType.GetProperties())
                    {
                        table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    }

                    var value = item.GetValue(data);
                    if (value != null)
                    {
                        var row = table.NewRow();
                        foreach (var prop in propType.GetProperties())
                        {
                            var propValue = prop.GetValue(value);
                            row[prop.Name] = propValue ?? DBNull.Value;
                        }
                        table.Rows.Add(row);
                    }
                    dataSet.Tables.Add(table);
                }
                // Handle simple properties
                else
                {
                    // Use a table named after the type if not already present
                    DataTable table;
                    if (!dataSet.Tables.Contains(type.Name))
                    {
                        table = new DataTable(type.Name);
                        dataSet.Tables.Add(table);
                    }
                    else
                    {
                        table = dataSet.Tables[type.Name];
                    }

                    if (!table.Columns.Contains(item.Name))
                    {
                        table.Columns.Add(item.Name, Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType);
                    }
                }
            }

            // Add a row for simple properties if any
            var mainTable = dataSet.Tables.Cast<DataTable>().FirstOrDefault(t => t.TableName == type.Name);
            if (mainTable != null && mainTable.Rows.Count == 0)
            {
                var row = mainTable.NewRow();
                foreach (var item in properties)
                {
                    var propType = item.PropertyType;
                    if (!(propType.IsClass && propType != typeof(string)) &&
                        !(propType.IsGenericType && typeof(System.Collections.IEnumerable).IsAssignableFrom(propType) && propType != typeof(string)))
                    {
                        var value = item.GetValue(data);
                        row[item.Name] = value ?? DBNull.Value;
                    }
                }
                mainTable.Rows.Add(row);
            }

            try
            {
                dataSet.WriteXml(filePath, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error writing XML file: {ex.Message}", ex);
            }
        }
    }
}
