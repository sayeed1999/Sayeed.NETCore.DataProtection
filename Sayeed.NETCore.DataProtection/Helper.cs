﻿using System.Collections;
using System.Reflection;

namespace Sayeed.NETCore.DataProtection
{
    /// <summary>
    /// Global Helper class
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// List of possible keywords to be found in sensative property names.
        /// </summary>
        private string[] sensativeKeywords = new string[]
        {
            "pass",
            "secret",
            "key",
            "pwd",
            "token",
        };

        /// <summary>
        /// Getter method to access current list of sensative keywords.
        /// </summary>
        /// <returns></returns>
        public string[] GetSensativeKeywords() 
            => (string[])this.sensativeKeywords.Clone();

        /// <summary>
        /// The maximum depth upto which the recursion loop will enter. The default value is set to 10.
        /// </summary>
        private int maxDepthToRecursivelyIterate = 10;

        /// <summary>
        /// Getter method to access current max depth of recursion loop.
        /// </summary>
        /// <returns></returns>
        public int GetMaxDepthToRecursivelyIterate()
            => this.maxDepthToRecursivelyIterate;

        /// <summary>
        /// Use this constructor to begin with all default configurations.
        /// </summary>
        public Helper()
        {

        }

        /// <summary>
        /// Use this constructor to only customize a your own set of sensative keywords to hide.
        /// </summary>
        /// <param name="sensativeKeywords"></param>
        public Helper(string[] sensativeKeywords)
        {
            this.sensativeKeywords = sensativeKeywords;
        }


        /// <summary>
        /// Use this constructor to only customize max depth of recursion loop.
        /// </summary>
        /// <param name="maxDepthToRecursivelyIterate"></param>
        public Helper(int maxDepthToRecursivelyIterate)
        {
            this.maxDepthToRecursivelyIterate = maxDepthToRecursivelyIterate;
        }

        /// <summary>
        /// Use this constructor to begin with your custom set of secret keywords to hide and maximum depth of recursion loop of your choice, and replaced value to null.
        /// </summary>
        /// <param name="sensativeKeywords"></param>
        /// <param name="maxDepthToRecursivelyIterate"></param>
        public Helper(string[] sensativeKeywords, int maxDepthToRecursivelyIterate)
        {
            this.sensativeKeywords = sensativeKeywords;
            this.maxDepthToRecursivelyIterate = maxDepthToRecursivelyIterate;
        }

        /// <summary>
        /// Iterates over any C# object, finds if any property name contains any sensative keyword, hides the property value.
        /// The object type must be a class, record, or any pre-defined type. Anonymous object is not supported.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="secretFields"></param>
        /// <param name="maxDepth"></param>
        /// <returns></returns>
        public object HideSensativeProperties(object entity)
        {
            HideSecretFieldsRecursively(entity, 0);

            return entity;
        }

        private void HideSecretFieldsRecursively(object entity, int currentDepth)
        {
            if (entity == null || currentDepth >= this.maxDepthToRecursivelyIterate) return;

            Type objectType = entity.GetType();

            if (objectType != typeof(string) && entity is IEnumerable enumerable)
            {
                foreach (var item in enumerable)
                {
                    HideSecretFieldsRecursively(item, currentDepth + 1);
                }
            }
            else if (objectType != typeof(string))
            {
                PropertyInfo[] properties = objectType.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    bool isHidden = false;
                    foreach (var secret in this.sensativeKeywords)
                    {
                        if (property.Name.ToLower().Contains(secret.ToLower()))
                        {
                            property.SetValue(entity, null);
                            isHidden = true;
                            break;
                        }
                    }
                    if (isHidden) continue;

                    object propertyValue = property.GetValue(entity);
                    HideSecretFieldsRecursively(propertyValue, currentDepth + 1);
                }
            }
        }

    }
}
