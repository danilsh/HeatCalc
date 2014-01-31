using System;
using HeatCalc.HeatLoss;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;

namespace HeatCalc.IO
{
    interface IFileService
    {
        Building GetBuilding(String fileName);
        void StoreBuilding(Building building, String fileName);
    }

    class FileService : IFileService
    {
        public Building GetBuilding(String fileName)
        {
            XDocument doc;
            using (var reader = XmlReader.Create(fileName))
            {
                doc = XDocument.Load(reader);
            }
            var root = doc.Element("HeatCalcDocument");
            if (root == null) return null;
            var version = (root.Attribute("Version") ?? new XAttribute("Version", "")).Value;
            if (version != "1.0") return null; // TODO: Автоматическая конвертация из предыдущих версий
            return root.Elements("Building").Take(1).Select(LoadBuilding).FirstOrDefault();
        }

        public void StoreBuilding(Building building, String fileName)
        {
            var doc = new XDocument
                (
                    new XDeclaration("1.0", "UTF-8", "yes"),
                    new XElement
                        (
                            "HeatCalcDocument",
                            new XAttribute("Version", "1.0"),
                            SaveBuilding(building)
                        )
                );
            var settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "    "
                };
            using (var writer = XmlWriter.Create(fileName, settings))
            {
                doc.Save(writer);
            }
        }

        #region Functions storing Building tree to XML
        private static XElement SaveCladdingLayer(CladdingLayer layer)
        {
            return new XElement
                (
                    "CladdingLayer",
                    new XAttribute("Name", layer.Name),
                    new XAttribute("ThermalConductivity", layer.ThermalConductivity),
                    new XAttribute("Thickness", layer.Thickness)
                );
        }

        private static XElement SaveCladdingPart(CladdingPart part)
        {
            var ret = new XElement
                (
                    "CladdingPart", 
                    new XAttribute("Name", part.Name),
                    new XAttribute("Area", part.Area)
                );
            part.Layers.ForEach(wl => ret.Add(SaveCladdingLayer(wl)));
            return ret;
        }

        private static XElement SaveAperture(Aperture aperture)
        {
            return new XElement
                (
                    "Aperture",
                    new XAttribute("Name", aperture.Name),
                    new XAttribute("HeatTransferCoefficient", aperture.HeatTransferCoefficient),
                    new XAttribute("Area", aperture.Area)
                );
        }

        private static XElement SaveCladding(Cladding cladding)
        {
            var ret = new XElement
                (
                    "Cladding",
                    new XAttribute("Name", cladding.Name)
                );
            cladding.Parts.ForEach(wp => ret.Add(SaveCladdingPart(wp)));
            cladding.Apertures.ForEach(a => ret.Add(SaveAperture(a)));
            return ret;
        }

        private static XElement SaveZone(Zone zone)
        {
            var ret = new XElement
                (
                    "Zone",
                    new XAttribute("Name", zone.Name),
                    new XAttribute("Volume", zone.Volume),
                    new XAttribute("AirExchange", zone.AirExchange)
                );
            zone.Claddings.ForEach(c => ret.Add(SaveCladding(c)));
            return ret;
        }

        private static XElement SaveBuilding(Building building)
        {
            var ret = new XElement
                (
                    "Building",
                    new XAttribute("Name", building.Name),
                    new XAttribute("InternalTemperature", building.InternalTemperature),
                    new XAttribute("ExternalTemperature", building.ExternalTemperature)
                );
            building.Zones.ForEach(z => ret.Add(SaveZone(z)));
            return ret;
        }
        #endregion

        #region Functions loading Building tree from XML
        private static CladdingLayer LoadCladdingLayer(XElement element)
        {
            try
            {
                return new CladdingLayer
                    (
                        double.Parse(element.Attribute("ThermalConductivity").Value, CultureInfo.InvariantCulture), 
                        double.Parse(element.Attribute("Thickness").Value, CultureInfo.InvariantCulture)
                    )
                    {
                        Name = element.Attribute("Name").Value
                    };
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static CladdingPart LoadCladdingPart(XElement element)
        {
            try
            {
                var ret = new CladdingPart
                    (
                        double.Parse(element.Attribute("Area").Value, CultureInfo.InvariantCulture)
                    )
                    {
                        Name = element.Attribute("Name").Value
                    };
                foreach (var wl in element.Elements("CladdingLayer").Select(LoadCladdingLayer).Where(wl => wl != null))
                {
                    ret.Layers.Add(wl);
                }
                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static Aperture LoadAperture(XElement element)
        {
            try
            {
                return new Aperture
                    (
                        double.Parse(element.Attribute("HeatTransferCoefficient").Value, CultureInfo.InvariantCulture),
                        double.Parse(element.Attribute("Area").Value, CultureInfo.InvariantCulture)
                    )
                    {
                        Name = element.Attribute("Name").Value
                    };
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static Cladding LoadCladding(XElement element)
        {
            try
            {
                var ret = new Cladding { Name = element.Attribute("Name").Value };
                foreach (var wp in element.Elements("CladdingPart").Select(LoadCladdingPart).Where(wp => wp != null))
                {
                    ret.Parts.Add(wp);
                }
                foreach (var a in element.Elements("Aperture").Select(LoadAperture).Where(a => a != null))
                {
                    ret.Apertures.Add(a);
                }
                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static Zone LoadZone(XElement element)
        {
            try
            {
                var ret = new Zone
                    (
                        double.Parse(element.Attribute("Volume").Value, CultureInfo.InvariantCulture),
                        double.Parse(element.Attribute("AirExchange").Value, CultureInfo.InvariantCulture)
                    )
                    {
                        Name = element.Attribute("Name").Value
                    };
                foreach (var c in element.Elements("Cladding").Select(LoadCladding).Where(c => c != null))
                {
                    ret.Claddings.Add(c);
                }
                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static Building LoadBuilding(XElement element)
        {
            try
            {
                var ret = new Building
                    (
                        double.Parse(element.Attribute("ExternalTemperature").Value, CultureInfo.InvariantCulture),
                        double.Parse(element.Attribute("InternalTemperature").Value, CultureInfo.InvariantCulture)
                    )
                    {
                        Name = element.Attribute("Name").Value
                    };
                foreach (var z in element.Elements("Zone").Select(LoadZone).Where(z => z != null))
                {
                    ret.Zones.Add(z);
                }
                return ret;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
