using System.Collections.ObjectModel;
using System.Management.Automation;
using PowerScraper.Core.Scraping.DataStructure.Collection;
using PowerScraper.Core.Scraping.Module;
using PowerScraper.Core.Utility;
using PowerScraper.Core.Utility.OS;

namespace PowerScraper.Core.ExtractionTooling.Powershell;

public static class ObjectParser
{
    public static void ParsePsObjectsAndAddItemsToNode(
        Collection<PSObject> psObjects, List<PropertyItem> propertyItems, CollectionTree collectionNode)
    {
        // var autoKey = new NumberKey();
        foreach (var psObject in psObjects)
        {
            // var iteration = autoKey.Next();
            if (psObject.Properties.Count() != propertyItems.Count)
                throw new Exception("The number of properties in the PSObject should be equal to the number of propertyObjects");

            foreach (var (psObj, propItem) in psObject.Properties.Zip(propertyItems, (psObj, propItem) => (psObj, propItem)))
            {
                string value = psObj.Value?.ToString() ?? "null";

                if (propItem.ValueContainsBytes)
                {
                    try
                    {
                        value = UnitConversion.ConvertBytesToGreatestUnit(Convert.ToInt64(psObj.Value));
                    }
                    catch (FormatException e)
                    {
                        ExitMessage.Write(
                            $"A scraper-file (*Scraper.cs) has a wrong boolean value for " +
                            $"the field {nameof(PropertyItem.ValueContainsBytes)} on a PropertyObject" +
                            $" which caused the program to try to convert a string to an Int64.",
                            e);
                    }
                }

                if (psObjects.Count > 1)
                    collectionNode.ItemSequence.Add(new Item(propItem.PropertyDisplayName, value));
                else
                    collectionNode.AddItem(propItem.PropertyDisplayName, value);
            }
        }
    }
}